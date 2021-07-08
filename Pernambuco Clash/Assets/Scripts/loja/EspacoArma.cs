using System;
using arma;
using UnityEngine;

namespace loja
{
    public class EspacoArma : Espaco
    {
        //greatest outcast
        public AudioSource clickSound;
        public int stick = -1;
        public Canhao canhao;
        private void Start()
        {
        }

        public override void Click()
        {
            clickSound.Play(0);
            var miniMenu = stick == -1 ? Loja.Instancia.painelArma : Loja.Instancia.painelEvolucao;
            Loja.Instancia.espaco = this;
            miniMenu.SetActive(true);
            miniMenu.transform.position = Input.mousePosition + new Vector3(100,10); 
        }
        public void Gera(int n)
        {
            canhao = Loja.Instancia.GetPrefab(n);
            var go = Instantiate(canhao);
            go.transform.position = transform.position;
            stick = n;
        }

        public void Evoluir()
        {
            canhao.Melhorar();
        }
    }
}