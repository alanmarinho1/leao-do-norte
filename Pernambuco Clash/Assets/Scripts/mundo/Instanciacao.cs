using System;
using UnityEngine;

namespace mundo
{
    [Serializable]
    public class Instanciacao
    {
        public GameObject prefab;
        public float tempo;
        public bool tick()
        {
            tempo -= Time.deltaTime;
            return tempo <= 0;
        }
    }
}