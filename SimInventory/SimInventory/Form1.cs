using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimInventory.Controllers;

namespace SimInventory
{
    public partial class Form1 : Form
    {
        private ProdutoController controller;

        public Form1()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                controller = new ProdutoController();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtPreco.Text, out decimal preco))
                {
                    MessageBox.Show(
                        "O preço deve ser um número válido.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtPreco.Focus();
                    return;
                }

                if (!int.TryParse(txtStock.Text, out int stock))
                {
                    MessageBox.Show(
                        "O stock deve ser um número inteiro válido.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    txtStock.Focus();
                    return;
                }

                controller.CriarProduto(
                    txtNome.Text,
                    txtCategoria.Text,
                    preco,
                    stock
                );

                MessageBox.Show(
                    "Produto criado com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                AtualizarLista();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível concluir a operação.\n\n" + ex.Message,
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void AtualizarLista()
        {
            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = controller.ObterProdutos();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            AtualizarLista();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                controller.EliminarProduto(int.Parse(txtId.Text));

                MessageBox.Show(
                    "Produto eliminado com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                AtualizarLista();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível concluir a operação.\n\n" + ex.Message,
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                controller.EditarProduto(
                    int.Parse(txtId.Text),
                    txtNome.Text,
                    txtCategoria.Text,
                    decimal.Parse(txtPreco.Text),
                    int.Parse(txtStock.Text)
                );

                MessageBox.Show(
                    "Produto atualizado com sucesso.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                AtualizarLista();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível concluir a operação.\n\n" + ex.Message,
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProdutos.Rows[e.RowIndex];

                txtId.Text = row.Cells["Id"].Value.ToString();
                txtNome.Text = row.Cells["Nome"].Value.ToString();
                txtCategoria.Text = row.Cells["Categoria"].Value.ToString();
                txtPreco.Text = row.Cells["Preco"].Value.ToString();
                txtStock.Text = row.Cells["Stock"].Value.ToString();
            }
        }

        private void LimparCampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtCategoria.Clear();
            txtPreco.Clear();
            txtStock.Clear();
            txtNome.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}