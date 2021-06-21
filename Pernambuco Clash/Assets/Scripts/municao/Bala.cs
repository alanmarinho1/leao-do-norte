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

        #endregion

        public abstract void AoAcertar(Inimigo alvo);

        protected void Update()
        {
            var local = alvo.transform.position;
            var pos = transform.position;
            var movimento = Vector3.zero;
            if (pos.x > local.x)
                movimento.x = 1 *Time.deltaTime * velocidadeBase;
            else if (pos.x < local.x)
                movimento.x = -1*Time.deltaTime * velocidadeBase;
            if (pos.y > local.y)
                movimento.y = 1*Time.deltaTime * velocidadeBase;
            else if (pos.y < local.y)
                movimento.y = -1*Time.deltaTime * velocidadeBase;

            transform.position += movimento;
        }
    }
}