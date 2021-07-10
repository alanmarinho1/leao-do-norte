using System;
using mundo;
using UnityEngine;
using Random = System.Random;

namespace arma
{
    public class CanhaoRajada: Canhao
    {
        [Range(4,50)]
        public int numero;

        public int crescimentoNumero;

        protected override void Dispara()
        {
            for (var i = 0; i < numero; i++)
            {
                var go = Instantiate(balaPrefab);
                go.transform.position = transform.position + new Vector3((float)(0.5- Base.Instancia.rng.NextDouble()),(float)(0.5- Base.Instancia.rng.NextDouble()),0);
                BalaDeCanhao(go);
            }
        }

        protected override void Localizar()
        {
            LocalizaMaisProximo();
        }

        protected override void AoAtirar(){}
        protected override void AoMudarAlvo(){ }
        protected override void AoMelhorar()
        {
            numero += crescimentoNumero;
        }
    }
}