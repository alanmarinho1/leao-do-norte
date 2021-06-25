using System;
using inimigo;
using UnityEngine;

namespace municao
{
    public class BalaLeve : Bala
    {
        private void Start()
        {
            tipo = "Leve";
        }

        public override void AoAcertar(Inimigo alvo)
        {
            if (alvo.defesaBase - alvo.Defesa < 5)
                alvo.Defesa = 1;
            //Destroy(gameObject);
        }

        protected override void Redireciona()
        {
            Direciona();
        }
        protected override void Movimentar()
        {
            Movimento();
        }
    }
}