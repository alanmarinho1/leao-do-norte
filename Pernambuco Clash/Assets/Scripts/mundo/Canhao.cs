using System;
using System.Linq;
using inimigo;
using municao;
using UnityEngine;

namespace mundo
{
    public class Canhao :MonoBehaviour
    {
        public GameObject balaPrefab;
        public float cadencia;
        public float potencia;
        public float alcance;
        public float tempo;
        private GameObject alvo;

        private void Start()
        {
            tempo = cadencia;
        }

        private void Update()
        {
            tempo -= Time.deltaTime;
            if(tempo > 0) return;
            tempo = cadencia;
            if (alvo != null)
            {
                
                if (!alvo.activeInHierarchy)
                {
                    alvo= null;
                    return;
                }
                if (Vector3.Distance(alvo.transform.position, transform.position) > alcance)
                {
                    alvo = null;
                    return;
                }

                var go = Instantiate(balaPrefab);
                go.transform.position = transform.position;
                var bala = go.GetComponent<Bala>();
                bala.alvo = alvo;
                return;
            }
            var inimigos = Base.Instancia.Inimigos.Where(i => Vector3.Distance(i.transform.position, transform.position) < alcance);
            if(!inimigos.Any()) return;
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
    }
}