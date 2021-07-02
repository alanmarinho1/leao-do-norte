using System;
using System.Collections.Generic;
using arma;
using inimigo;
using mundo;
using UnityEngine;

namespace loja
{
    [DisallowMultipleComponent]
    [Serializable]
    public class Loja:MonoBehaviour
    {
        #region Singleton

        private static Loja instancia;

        private void Awake()
        {
            if (instancia == null)
                instancia = this;
        }

        public static Loja Instancia => instancia;

        #endregion
        public Canhao canhaoSimples;
        public Canhao canhaoRajada;
        public Canhao canhaoMetralhadora;

        
        
        public Canhao GetPrefab(int n)
        {
            return n switch
            {
                1 => canhaoSimples,
                2 => canhaoMetralhadora,
                3 => canhaoRajada,
                _ => null
            };
        }

        public bool Comprar(int n)
        {
            var prefab = GetPrefab(n);
            if (Base.Instancia.Grana < prefab.preco) return false;
            Base.Instancia.Grana = -prefab.preco;
            return true;

        }
    }
}