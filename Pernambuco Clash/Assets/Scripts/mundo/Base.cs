using System;
using System.Collections.Generic;
using System.Linq;
using inimigo;
using loja;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace mundo
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Gerador))]
    [RequireComponent(typeof(Controlador))]
    [RequireComponent(typeof(Loja))]
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
        #region Texto

        public Text texto_grana;
        
        #endregion
        

        public float tamanho;
        public float grana;
        public float vida;

        public float Vida
        {
            set
            {
                vida -= value;
                if(vida <= 0)
                    AoMorrer();
            }
        }
        public float Grana
        {
            get => grana;
            set
            {
                grana += value;
                if (grana <= 0)
                    grana = 0;
                texto_grana.text = Convert.ToString(grana);
                // Debug.Log("minha grana é de [" + grana + "]" );
            }
        }
        public Random rng = new Random();
        public ControleCenas cena;
        private LinkedList<GameObject> inimigos = new LinkedList<GameObject>();
        public LinkedList<GameObject> Inimigos => inimigos;
        #endregion

        private void Start()
        {
            Grana = 0;
            Time.timeScale = 3f;
        }

        public void AddInimigo(GameObject go)
        {
            inimigos.AddLast(go);
        }
        protected void Update()
        {
            try
            {
                foreach (var go in inimigos.Where(go =>
                    Vector3.Distance(transform.position, go.transform.position) < tamanho))
                {
                    Invade(go);
                    //cena.GameOverScene();
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        //TODO
        protected void AoMorrer()
        {
            cena.GameOverScene();
        }

        protected void Invade(GameObject go)
        {
            if (!go.CompareTag("Inimigo")) return;
            var inimigo = go.GetComponent<Inimigo>();
            Vida = inimigo.dano;
            //Grana = inimigo.recompensa;
            Debug.Log("A base sofreu [" + inimigo.dano + "] de dano" );
            inimigos.Remove(go);
            Destroy(go);
            cena.GameOverScene();
        }
    }
}