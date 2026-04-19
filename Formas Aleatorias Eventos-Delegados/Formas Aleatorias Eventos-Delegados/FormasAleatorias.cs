using System;

namespace Formas_Aleatorias_Eventos_Delegados {
    class FormasAleatorias {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main() {
            Controller controller = new Controller();
            controller.IniciarPrograma();
        }
    }
}
