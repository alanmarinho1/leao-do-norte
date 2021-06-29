using System;
using UnityEngine;

namespace loja
{
    public class EspacoArma : Espaco
    {
        //greatest outcast
        public GameObject painel;

        private void Start()
        {
            painel.SetActive(false);
        }

        public override void Click()
        {
            var aberto = painel.activeInHierarchy;
            foreach (var go in GameObject.FindGameObjectsWithTag("Menu"))
            {
                go.SetActive(false);
                for (var n=0;n<go.transform.childCount;n++)
                {
                    go.transform.GetChild(n).gameObject.SetActive(false);
                }
            }
            painel.SetActive(!aberto);
            for (var n=0;n<painel.transform.childCount;n++)
            {
                painel.transform.GetChild(n).gameObject.SetActive(!aberto);
            }
        }
        public void Gera(int n)
        {
            var prefab = Loja.Instancia.GetPrefab(n);
            var go = Instantiate(prefab);
            go.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}