using UnityEngine;

namespace loja
{
    public class EspacoMiniMenu :MonoBehaviour
    {
        public void ComprarCanhao()
        {
            Loja.Instancia.painelArma.SetActive(false);
            if (!Loja.Instancia.Comprar(1)) return;
            Loja.Instancia.espaco.Gera(1);
            
        }
        public void ComprarMetralhadora(){
            Loja.Instancia.painelArma.SetActive(false);
            if (!Loja.Instancia.Comprar(2)) return;
            Loja.Instancia.espaco.Gera(2);
           }

        public void ComprarMorteiro()
        {
            
            if (!Loja.Instancia.Comprar(3)) return;
            Loja.Instancia.espaco.Gera(3);
            
        }

        public void Evoluir()
        {
            Loja.Instancia.painelEvolucao.SetActive(false);
            if (!Loja.Instancia.Evoluir()) return;
            Loja.Instancia.espaco.Evoluir();
            
        }
    }
}