using System;
using inimigo;
using UnityEngine;
using UnityEngine.AI;

namespace municao
{
    public abstract class Bala : MonoBehaviour
    {
        #region campos

        public GameObject alvo;
        public float dano;
        public float penetracao;
        public float velocidadeBase;
        public string tipo;
        public float tempoVida;
        public bool fixo = false;
        protected bool X,Y;
        #endregion

        public abstract void AoAcertar(Inimigo alvo);

        protected void Update()
        {
            if(Tick() || !fixo && alvo == null)
                Destroy(gameObject);
            Redireciona();
            Movimentar();
        }

        protected bool Tick()
        {
            tempoVida -= Time.deltaTime;
            return tempoVida <= 0;
        }

        protected abstract void Redireciona();
        protected void Direciona()
        {
            var local = alvo.transform.position;
            var pos = transform.position;
            X = pos.x > local.x;
            Y = pos.y > local.y;
        }

        protected void Movimento()
        {
            transform.position += new Vector3(velocidadeBase * Time.deltaTime * (X ? -1 : 1),
                velocidadeBase * Time.deltaTime * (Y ? -1 : 1), 0);
        }

        protected abstract void Movimentar();

    }
}