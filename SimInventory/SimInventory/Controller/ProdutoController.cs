using System.Collections.Generic;

namespace SimInventory
{
    // Wrapper controller with Portuguese API used by the WinForms view.
    public class ProdutoController
    {
        private readonly Model model;

        public ProdutoController()
        {
            model = new Model();
        }

        public void CriarProduto(string nome, string categoria, decimal preco, int stock)
        {
            // categoria is not used in the current domain model; kept for compatibility with the view.
            model.CreateProduct(nome, preco, stock);
        }

        public List<Product> ObterProdutos()
        {
            return model.GetProducts();
        }

        public void EliminarProduto(int id)
        {
            model.DeleteProduct(id);
        }

        public void EditarProduto(int id, string nome, string categoria, decimal preco, int stock)
        {
            // categoria is ignored (not present in Product model)
            model.UpdateProduct(id, nome, preco, stock);
        }
    }
}
