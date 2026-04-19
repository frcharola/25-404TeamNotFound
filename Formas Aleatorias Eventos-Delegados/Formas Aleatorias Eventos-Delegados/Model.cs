using System;
using System.Collections.Generic;

namespace Formas_Aleatorias_Eventos_Delegados {
    class Model {
        private View view;
        List<Forma> formas;
        

        public Model(View v) {
            view = v;
        }

        public void CriarNovaForma() {
            // Alterar a lista de formas
        }

        public void SolicitarListaFormas(ref List<Forma> listadeformas) {
            // Copia a lista "formas" para "listadeformas"
            // usando o estilo de cópia adequado aos dados
            // (provavelmente deep copy e não shallow copy).
            // não deveria simplesmente fazer:
            // listadeforma=formas;
            // porque isso permitira que quem manipulasse as formas
            // da lista fornecida alterasse as do próprio Model
            // visto serem referências.
         }
    }
}
