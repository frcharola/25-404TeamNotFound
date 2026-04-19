namespace Formas_Aleatorias_Eventos_Delegados {
    class Controller {
        Model model;
        View view;

        public delegate void AtivacaoInterface(object origem);
        public event AtivacaoInterface AtivarInterface;

        public Controller() {
            view = new View(model);
            model = new Model(view);

            //Ligar o evento da View ao método do Controller, de foram desacoplada
            //porque a View não sabe quem responderá ao evento.
            view.UtilizadorClicouEmNovaForma += UtilizadorClicouEmNovaForma;
            view.PrecisoDeFormas += model.SolicitarListaFormas;
        }
        public void IniciarPrograma() {
            view.AtivarInterface();
        }
        public void UtilizadorClicouEmNovaForma(object fonte, System.EventArgs args) {
            // Implementar...
            model.CriarNovaForma();
        }

    }
}