using System;
using System.Collections.Generic;
using System.Globalization;

namespace SimInventory
{
    public class Controller
    {
        private readonly Model model;
        private readonly IInventoryView view;

        public Controller(Model model, IInventoryView view)
        {
            this.model = model;
            this.view = view;
            this.model.ProductsChanged += RefreshProducts;
        }

        public void LoadProducts()
        {
            RefreshProducts();
        }

        public void CreateProduct(string name, string priceText, string stockText)
        {
            try
            {
                decimal price = ParseDecimal(priceText);
                int stock = ParseInt(stockText, "O stock deve ser um número inteiro.");

                Product product = model.CreateProduct(name, price, stock);
                view.ShowSuccess("Produto criado com o ID " + product.Id + ".");
                view.ClearInputs();
            }
            catch (InvalidProductException ex)
            {
                view.ShowError(ex.Message);
            }
            catch (FormatException ex)
            {
                view.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                view.ShowError("Ocorreu um erro inesperado: " + ex.Message);
            }
        }

        public void UpdateProduct(string idText, string name, string priceText, string stockText)
        {
            try
            {
                int id = ParseInt(idText, "O ID deve ser um número inteiro.");
                decimal price = ParseDecimal(priceText);
                int stock = ParseInt(stockText, "O stock deve ser um número inteiro.");

                model.UpdateProduct(id, name, price, stock);
                view.ShowSuccess("Produto atualizado com sucesso.");
                view.ClearInputs();
            }
            catch (InvalidProductException ex)
            {
                view.ShowError(ex.Message);
            }
            catch (ProductNotFoundException ex)
            {
                view.ShowError(ex.Message);
            }
            catch (FormatException ex)
            {
                view.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                view.ShowError("Ocorreu um erro inesperado: " + ex.Message);
            }
        }

        public void DeleteProduct(string idText)
        {
            try
            {
                int id = ParseInt(idText, "O ID deve ser um número inteiro.");

                model.DeleteProduct(id);
                view.ShowSuccess("Produto eliminado com sucesso.");
                view.ClearInputs();
            }
            catch (ProductNotFoundException ex)
            {
                view.ShowError(ex.Message);
            }
            catch (FormatException ex)
            {
                view.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                view.ShowError("Ocorreu um erro inesperado: " + ex.Message);
            }
        }

        public Product GetProduct(int id)
        {
            return model.GetProductById(id);
        }

        private void RefreshProducts()
        {
            List<Product> products = model.GetProducts();
            view.DisplayProducts(products);
        }

        private int ParseInt(string value, string errorMessage)
        {
            if (!int.TryParse(value, out int number))
            {
                throw new FormatException(errorMessage);
            }

            return number;
        }

        private decimal ParseDecimal(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new FormatException("O preço deve ser preenchido.");
            }

            value = value.Replace(',', '.');

            if (!decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal number))
            {
                throw new FormatException("O preço deve ser um número decimal válido.");
            }

            return number;
        }
    }
}
