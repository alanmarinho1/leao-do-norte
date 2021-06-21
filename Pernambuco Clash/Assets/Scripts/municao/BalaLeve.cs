using System;
using inimigo;

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
        }
    }
}