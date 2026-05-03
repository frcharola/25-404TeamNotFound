using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimInventory
{
    public class Model
    {
        private List<Product> products;
        private int nextId;
        private readonly string filePath = "produtos.json";

        public delegate void ProductListChanged();
        public event ProductListChanged ProductsChanged;
       
        public Model()
        {
            products = new List<Product>();
            nextId = 1;
            LoadFromJson();
        }

        public Product CreateProduct(string name, decimal price, int stock)
        {
            ValidateProductData(name, price, stock);

            Product product = new Product(nextId, name.Trim(), price, stock);
            products.Add(product);
            nextId++;

            SaveToJson();
            ProductsChanged?.Invoke();
            return product;
        }

        public List<Product> GetProducts()
        {
            return new List<Product>(products);
        }

        public void LoadProducts()
        {
            LoadFromJson();
            ProductsChanged?.Invoke();
        }

        public Product GetProductById(int id)
        {
            Product product = products.Find(p => p.Id == id);

            if (product == null)
            {
                throw new ProductNotFoundException("Não foi encontrado nenhum produto com o ID indicado.");
            }

            return product;
        }

        public void UpdateProduct(int id, string name, decimal price, int stock)
        {
            ValidateProductData(name, price, stock);

            Product product = GetProductById(id);
            product.Update(name.Trim(), price, stock);

            SaveToJson();
            ProductsChanged?.Invoke();
        }

        public void DeleteProduct(int id)
        {
            Product product = GetProductById(id);
            products.Remove(product);

            SaveToJson();
            ProductsChanged?.Invoke();
        }

        private void SaveToJson()
        {
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private void LoadFromJson()
        {
            if (!File.Exists(filePath))
            {
                products = new List<Product>();
                nextId = 1;
                return;
            }

            string json = File.ReadAllText(filePath);
            products = JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();

            nextId = products.Any() ? products.Max(p => p.Id) + 1 : 1;
        }

        private void ValidateProductData(string name, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidProductException("O nome do produto não pode estar vazio.");
            }

            if (name.Trim().Length < 3)
            {
                throw new InvalidProductException("O nome do produto deve ter pelo menos 3 caracteres.");
            }

            if (price <= 0)
            {
                throw new InvalidProductException("O preço do produto deve ser superior a zero.");
            }

            if (stock < 0)
            {
                throw new InvalidProductException("O stock do produto não pode ser negativo.");
            }
        }
    }
}
