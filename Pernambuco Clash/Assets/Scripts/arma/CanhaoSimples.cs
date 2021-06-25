using System.Linq;
using mundo;
using municao;
using UnityEngine;

namespace arma
{
    public class CanhaoSimples : Canhao
    {
        protected override void Dispara()
        {
            var go = Instantiate(balaPrefab);
            go.transform.position = transform.position;
            BalaDeCanhao(go);
        }

        protected override void AoAtirar(){}
        protected override void AoMudarAlvo(){}
        protected override void AoMelhorar(){}
    }
}