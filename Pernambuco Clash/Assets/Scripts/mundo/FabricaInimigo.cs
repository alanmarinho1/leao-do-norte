using System;
using inimigo;
using UnityEngine;

namespace mundo
{
    [DisallowMultipleComponent]
    public class FabricaInimigo : MonoBehaviour
    {
        private static FabricaInimigo _intancia;
        public static FabricaInimigo Instancia => _intancia;

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