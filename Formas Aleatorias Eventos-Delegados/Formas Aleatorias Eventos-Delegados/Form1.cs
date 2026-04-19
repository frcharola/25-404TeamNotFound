using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formas_Aleatorias_Eventos_Delegados
{
    public partial class Form1 : Form
    {
        View view;
        public Form1()
        {
            InitializeComponent();
        }

        public View View { get => view; set => view = value; }

        private void botaoNovaForma_Click(object sender, EventArgs e)
        {
            //O Visual Studio cria automaticamente este método botaoNovaForma_Click com a interface visual
            //Mantendo essa ligação, podemos continuar a usar a edição visual
            //Então comunicamos aqui à nossa classe central do componente View o clique no botão.
            //Podíamos igualmente ir a View.Designer.cs associar diretamente
            //this.botaoNovaForma.Click ao método da classe Controller
            //mas isso desativaria a edição visual
            //e faria com que essa ligação entre classes estivesse a ser feita fora do Controller.
            //Por isso, limitamo-nos a comunicara aqui o evento Click à classe central da View
            //que o relançará como o evento UtilizadorClicouEmNovaForma.
            //Isto permite que seja o Controller a associar o destino dele.
            //Não precisávamos de manter os parâmetros, mantivemo-los apenas
            //por uma questão de enriquecer o exemplo, já que não os usámos noutros eventos
            //deste código exemplificativo.
            view.CliqueEmNovaForma(sender, e);
        }
    }
}
