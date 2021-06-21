using System;
using UnityEngine;

namespace mundo
{
    [Serializable]
    public class Instanciacao
    {
        public GameObject prefab;
        public float tempo;

        public Instanciacao(string texto, float _tempo)
        {
            Debug.Log("abrindo em Assets/Recursos/Prefab/" + texto+".prefab");
            prefab = Resources.Load<GameObject>("Assets/Recursos/Prefab/" + texto+".prefab");
            Debug.Log("aberto :");
            Debug.Log(prefab);
            Debug.Log(prefab.name);
            tempo = _tempo;
        }

        public bool tick()
        {
            tempo -= Time.deltaTime;
            return tempo <= 0;
        }
    }
}