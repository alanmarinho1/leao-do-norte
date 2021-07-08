using System;
using System.Collections.Generic;
using arma;
using inimigo;
using mundo;
using UnityEngine;
using UnityEngine.UI;

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

        private void Start()
        {
            painelArma.SetActive(false);
            painelEvolucao.SetActive(false);
            
        }
        

        public static Loja Instancia => instancia;

        #endregion

        public GameObject painelArma;
        public GameObject painelEvolucao;
        public Canhao canhaoSimples;
        public Canhao canhaoRajada;
        public Canhao canhaoMetralhadora;

        private const string conteudo = "Evoluir                ";
        public EspacoArma espaco;
        public Text texto;

        public GameObject GetPainel(int n)
        {
            if (n == -1) return painelArma;
            texto.text = conteudo + GetPrefab(n).preco;
            return painelEvolucao;
        }
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
        public bool Evoluir()
        {
            var prefab = espaco.canhao ? espaco.canhao : canhaoSimples;
            if (Base.Instancia.Grana < prefab.preco) return false;
            Base.Instancia.Grana = -prefab.preco;
            return true;
        }
    }
}