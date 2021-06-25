using System;
using System.Linq;
using inimigo;
using mundo;
using municao;
using UnityEngine;

namespace arma
{
    public abstract class Canhao :MonoBehaviour
    {
        public GameObject balaPrefab;
        public float cadencia;
        public float potencia;
        public float alcance;
        public float tempo;
        public int nivelMaximo;
        public float preco;
        public float crescimentoPreco;
        public float crescimentoDano;
        public float cresimentoCadencia;
        private int nivel;

        protected GameObject alvo;

        private void Start()
        {
            tempo = cadencia;
        }

        private void Update()
        {
            if (!Tick()) return;
            if (ChecaAlvo()){
                AoAtirar();
                Dispara();
                tempo = cadencia;
            }
            else
                Localiza();
        }

        protected bool Tick()
        {
            tempo -= Time.deltaTime;
            if (tempo > 0) return false;
            return true;
        }

        protected bool ChecaAlvo()
        {
            return alvo != null && alvo.activeInHierarchy && Vector3.Distance(alvo.transform.position, transform.position) <= alcance;
        }

        protected abstract void Dispara();
        protected void Localiza()
        {
            var inimigos = Base.Instancia.Inimigos.Where(i => Vector3.Distance(i.transform.position, transform.position) < alcance);
            if(!inimigos.Any()) return;
            AoMudarAlvo();
            GameObject ini = null;
            float min = 9999999999999f,dis;
            foreach (var inimigo in inimigos)
            {
                dis = Vector3.Distance(inimigo.transform.position, transform.position);
                if (!(dis < min)) continue;
                min = dis;
                ini = inimigo;
            }

            alvo = ini;
        }

        protected void BalaDeCanhao(GameObject go)
        {
            var bala = go.GetComponent<Bala>();
            bala.dano = potencia;
            bala.alvo = alvo;
        }

        protected abstract void AoAtirar();

        protected abstract void AoMudarAlvo();
        protected abstract void AoMelhorar();

        public bool Melhorar()
        {
            if (nivel >= nivelMaximo) return false;
            AoMelhorar();
            preco += crescimentoPreco * ++nivel;
            potencia += crescimentoDano;
            cadencia -= cresimentoCadencia;
            if (cadencia <= 0)
                cadencia = 0.1f;
            return true;
        }
    }
}