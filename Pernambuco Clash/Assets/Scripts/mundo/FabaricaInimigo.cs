using System;
using inimigo;
using UnityEngine;

namespace mundo
{
    [DisallowMultipleComponent]
    public class FabaricaInimigo : MonoBehaviour
    {
        private static FabaricaInimigo _intancia;
        public static FabaricaInimigo Instancia => _intancia;

        private void Awake()
        {
            if (_intancia == null)
                _intancia = this;
        }

        public Inimigo inimigoSimples;
        public Inimigo inimigoGrande;
        public Inimigo inimigoPequeno;
        public Inimigo inimigoRapido;
        public Inimigo inimigoChefe;
        public Inimigo GetInimigo(string str)
        {
            return str switch
            {
                "simples" => inimigoSimples,
                "grande" => inimigoGrande,
                "pequeno" => inimigoPequeno,
                "rapido" => inimigoRapido,
                "chefe" => inimigoChefe,
                _ => null
            };
        }
    }
}