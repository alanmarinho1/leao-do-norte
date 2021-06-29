using UnityEngine;

namespace loja
{
    public class EspacoMiniMenu : Espaco
    {
        public int opcao;
        public EspacoArma espaco;
        public override void Click()
        {
            Debug.Log("vc clicou para " + opcao);
            if(Loja.Instancia.Comprar(opcao))
                espaco.Gera(opcao);
            else
            {
                Debug.Log("faltou grana cara");
            }
            espaco.Click();
        }

    }
}