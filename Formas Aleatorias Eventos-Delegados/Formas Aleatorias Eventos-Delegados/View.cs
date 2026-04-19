using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas_Aleatorias_Eventos_Delegados
{
    public class View
    {
        private Model model;
        private Form1 janela;

        public event System.EventHandler UtilizadorClicouEmNovaForma;

        public delegate void SolicitacaoListaFormas(ref List<Forma> listadeformas);
        public event SolicitacaoListaFormas PrecisoDeFormas;

        internal View(Model m)
        {
            model = m;
        }

        public void AtivarInterface()
        {
            janela = new Form1();
            janela.View = this;
            // A API WinForms desenha as janelas e botões automaticamente
            janela.ShowDialog();
        }

        public void AtualizarListaDeFormas()
        {
            // Atualizar a lista de formas recebidas do Model
        }

        void DesenharFormas()
        {
            // Criação de uma forma aleatória
            List<Forma> lista = new List<Forma>();
            PrecisoDeFormas(ref lista);
            //Desenhar as formas
        }

        public void CliqueEmNovaForma(object origem, EventArgs e)
        {
            //Ver comentários em Form1.cs: botaoNovaForma_Click
            UtilizadorClicouEmNovaForma(origem, e);
        }
    }
}
