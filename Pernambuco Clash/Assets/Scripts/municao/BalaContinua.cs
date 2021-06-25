using System;
using inimigo;
using UnityEngine;

namespace municao
{
    public class BalaContinua :Bala
    {
        private float x, y;
        private void Start()
        {
            tipo = "continua";
            var pos = alvo.transform.position;
            var local = transform.position;
            var dis = Vector3.Distance(pos, local);
            var dx = (float)Math.Sqrt(Math.Pow(pos.x - local.x,2));
            var dy = (float)Math.Sqrt(Math.Pow(pos.y - local.y,2));
            if (dx < 0.5f)
            {
                x = 0f;
                y = 1f;
                return;
            }

            if (dy < 0.5f)
            {
                x = 1f;
                y = 0f;
                return;
            }

            x = -dx * velocidadeBase / dis;
            y = -dy * velocidadeBase/ dis;
        }

        public override void AoAcertar(Inimigo alvo){}

        protected override void Redireciona(){}
        protected override void Movimentar()
        {
            transform.position += new Vector3(x, y, 0) * Time.deltaTime;
        }
    }
}