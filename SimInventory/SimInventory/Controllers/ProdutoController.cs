using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimInventory.Models;

namespace SimInventory.Controllers
{
    internal class ProdutoController
    {
        private ProdutoModel model = new ProdutoModel();

        public List<Produto> ObterProdutos()
        {
            return model.ObterProdutos();
        }

        public void CriarProduto(string nome, string categoria, decimal preco, int stock)
        {
            model.CriarProduto(nome, categoria, preco, stock);
        }

        public Produto EditarProduto(int id, string nome, string categoria, decimal preco, int stock)
        {
            return model.EditarProduto(id, nome, categoria, preco, stock);
        }

        public void EliminarProduto(int id)
        {
            model.EliminarProduto(id);
        }
    }
}
