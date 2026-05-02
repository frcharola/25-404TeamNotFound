using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimInventory
{
    public partial class Form1 : Form, IInventoryView
    {
        private readonly Controller controller;

        public Form1()
        {
            InitializeComponent();

            Model model = new Model();
            controller = new Controller(model, this);
            controller.LoadProducts();
        }

        public void DisplayProducts(List<Product> products)
        {
            dgvProducts.DataSource = null;
            dgvProducts.DataSource = products;
            dgvProducts.ClearSelection();
        }

        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ClearInputs()
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            dgvProducts.ClearSelection();
            txtName.Focus();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            controller.CreateProduct(txtName.Text, txtPrice.Text, txtStock.Text);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            controller.UpdateProduct(txtId.Text, txtName.Text, txtPrice.Text, txtStock.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            controller.DeleteProduct(txtId.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null || dgvProducts.CurrentRow.DataBoundItem == null)
            {
                return;
            }

            Product product = (Product)dgvProducts.CurrentRow.DataBoundItem;
            txtId.Text = product.Id.ToString();
            txtName.Text = product.Name;
            txtPrice.Text = product.Price.ToString("0.00");
            txtStock.Text = product.Stock.ToString();
        }
    }
}
