using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace SimInventory.Models
{
    internal class ProdutoModel
    {
        private List<Produto> produtos = new List<Produto>();
        private string ficheiro = "produtos.json";

        public ProdutoModel()
        {
            Carregar();
        }

        public List<Produto> ObterProdutos()
        {
            return produtos;
        }

        public Produto CriarProduto(string nome, string categoria, decimal preco, int stock)
        {
            Validar(nome, categoria, preco, stock);

            var produto = new Produto
            {
                Id = produtos.Count == 0 ? 1 : produtos.Max(p => p.Id) + 1,
                Nome = nome,
                Categoria = categoria,
                Preco = preco,
                Stock = stock
            };

            produtos.Add(produto);
            Guardar();

            return produto;
        }

        public Produto EditarProduto(int id, string nome, string categoria, decimal preco, int stock)
        {
            Validar(nome, categoria, preco, stock);

            var produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
                throw new Exception("Não foi encontrado nenhum produto com o ID indicado.");

            produto.Nome = nome;
            produto.Categoria = categoria;
            produto.Preco = preco;
            produto.Stock = stock;

            Guardar();

            return produto;
        }

        public void EliminarProduto(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
                throw new Exception("Não foi encontrado nenhum produto com o ID indicado.");

            produtos.Remove(produto);
            Guardar();
        }

        private void Validar(string nome, string categoria, decimal preco, int stock)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("O nome do produto é obrigatório.");

            if (string.IsNullOrWhiteSpace(categoria))
                throw new Exception("A categoria do produto é obrigatória.");

            if (preco < 0)
                throw new Exception("O preço do produto não pode ser negativo.");

            if (stock < 0)
                throw new Exception("O stock do produto não pode ser negativo.");
        }

        private void Carregar()
        {
            if (!File.Exists(ficheiro))
                return;

            var json = File.ReadAllText(ficheiro);

            produtos = JsonConvert.DeserializeObject<List<Produto>>(json) ?? new List<Produto>();
        }

        private void Guardar()
        {
            var json = JsonConvert.SerializeObject(produtos, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(ficheiro, json);
        }
    }
}
