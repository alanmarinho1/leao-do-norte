using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using inimigo;
using UnityEngine;

namespace mundo
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Gerador))]
    public class Base : MonoBehaviour
    {
        #region singleton

        private static Base instancia;
        public static Base Instancia => instancia;

        protected void Awake()
        {
            if (instancia == null)
                instancia = this;
        }

        #endregion

        #region campos

        public float tamanho;
        private LinkedList<GameObject> inimigos = new LinkedList<GameObject>();

        #endregion

        public void AddInimigo(GameObject go)
        {
            inimigos.AddLast(go);
        }
        protected void Update()
        {
            foreach (var go in inimigos.Where(go => Vector3.Distance(transform.position, go.transform.position) < tamanho))
            {
                Invade(go);
                inimigos.Remove(go);
                Destroy(go);
                break;
            }
        }

        protected void Invade(GameObject go)
        {
            if (!go.CompareTag("Inimigo")) return;
            var inimigo = go.GetComponent<Inimigo>();
            Debug.Log("dano causado = " +inimigo.dano);
            
        }
    }
}