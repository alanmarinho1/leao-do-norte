using System;
using System.IO;
using System.Linq;
using loja;
using UnityEditor;
using UnityEngine;

namespace mundo
{
    [Serializable]
    public class Instanciacao
    {
        public GameObject prefab;
        public float tempo;

        public Instanciacao(string str)
        {
            Debug.Log(str);
            var partes = str.Split(new []{"::"},StringSplitOptions.RemoveEmptyEntries);
            tempo = float.Parse(partes[1]);
            prefab = FabricaInimigo.Instancia.GetInimigo(partes[0]).gameObject;
            // Debug.Log(tempo + "");
        }
        
          

        public static Instanciacao[] ApartirDeArquivo(string str)
        {
            var lines = System.IO.File.ReadAllLines("Assets/Recursos/Roteiro/" + str).Where(line=>line.Length > 2 && !line.StartsWith("#")).ToArray();
            var len = lines.Count();
            var vec = new Instanciacao[len];
            for (var i = 0; i < len; i++)
                vec[i] = new Instanciacao(lines[i]);
            return vec;
        }
        public bool tick()
        {
            tempo -= Time.deltaTime;
            return tempo <= 0;
        }
    }
}