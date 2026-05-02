using System;
using System.Collections.Generic;
using System.Globalization;
using SimInventory;

namespace AplicacaoDemonstradoraMVC {
    public class View {
        public void ShowWelcome() {
            Console.WriteLine("========================================");
            Console.WriteLine("     Aplicação Demonstradora - MVC");
            Console.WriteLine("========================================");
            Console.WriteLine("Gestão simples de produtos em consola.\n");
        }

        public void ShowMenu() {
            Console.WriteLine("\n-------------- MENU --------------");
            Console.WriteLine("1 - Criar produto");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("3 - Editar produto");
            Console.WriteLine("4 - Eliminar produto");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");
        }

        public string ReadText(string label) {
            Console.Write(label);
            return Console.ReadLine();
        }

        public int ReadInt(string label) {
            Console.Write(label);
            string value = Console.ReadLine();

            if (!int.TryParse(value, out int number)) {
                throw new FormatException("O valor introduzido deve ser um número inteiro.");
            }

            return number;
        }

        public decimal ReadDecimal(string label) {
            Console.Write(label);
            string value = Console.ReadLine();

            value = value.Replace(',', '.');

            if (!decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal number)) {
                throw new FormatException("O valor introduzido deve ser um número decimal válido.");
            }

            return number;
        }

        public void ShowProducts(List<Product> products) {
            Console.WriteLine("\n----------- PRODUTOS -----------");

            if (products.Count == 0) {
                Console.WriteLine("Ainda não existem produtos registados.");
                return;
            }

            foreach (Product product in products) {
                Console.WriteLine($"ID: {product.Id} | Nome: {product.Name} | Preço: {product.Price:0.00} € | Stock: {product.Stock}");
            }
        }

        public void ShowSuccess(string message) {
            Console.WriteLine("\n[SUCESSO] " + message);
        }

        public void ShowError(string message) {
            Console.WriteLine("\n[ERRO] " + message);
        }

        public void ShowInformation(string message) {
            Console.WriteLine("\n[INFO] " + message);
        }

        public void WaitForUser() {
            Console.WriteLine("\nPrima qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
