﻿using System;
using mundo;
using municao;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
namespace inimigo
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class Inimigo : MonoBehaviour
    {
        #region campos
        #region privadas
        
        private GameObject alvo;
        private NavMeshAgent _navMeshAgent;

        private float vidaAtual;
        private float velocidadeAtual;
        private float defesaAtual;

        #endregion
        #region publicas

        public float vidaMaxima;
        public float velocidadeBase;
        public float recompensa;
        public float dano;
        public float defesaBase;
        public GameObject barraVida;
        public Animator anim;

        public float Vida
        {
            get => vidaAtual;
            set
            {
                //Debug.Log("com" + vidaAtual + ", daninho de " + value);
                vidaAtual -= value;
                //Debug.Log("vida =" + vidaAtual);
                if (vidaAtual >= vidaMaxima) vidaAtual = vidaMaxima;
                if (vidaAtual < 0)
                {
                    vidaAtual = 0;
                    Morrer();
                }
                //Debug.Log("vida =" + vidaAtual);

                var vec = barraVida.transform.localScale;
                barraVida.transform.localScale = new Vector3(vidaAtual / vidaMaxima, vec.y, vec.z );
            }
        }
        public float Velocidade
        {
            get => velocidadeAtual;
            set
            {
                velocidadeAtual -= value;
                if (velocidadeAtual >= velocidadeBase) velocidadeAtual = velocidadeBase;
                if (velocidadeAtual <= 0) velocidadeAtual = 0;
            }
        }
        public float Defesa
        {
            get => defesaAtual;
            set
            {
                defesaAtual -= value;
                if (defesaAtual >= defesaBase) defesaAtual = defesaBase;
                if (defesaAtual <= 0) defesaAtual = 0;
            }
        }
        
        #endregion

        #endregion
        #region metodos abstatos

        protected abstract void AoMorrer();
        protected abstract void AoLevarDano(Bala bala);

        #endregion
        #region Construtor

        protected void Start()
        {
            vidaAtual = vidaMaxima;
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
            velocidadeAtual = velocidadeBase;
            _navMeshAgent.speed = velocidadeBase;
            alvo = GameObject.FindWithTag("Base");
            Base.Instancia.AddInimigo(gameObject);
            anim = GetComponent<Animator>();
            vidaAtual = vidaMaxima;
            Vida = 0;
        }

        #endregion
        
        protected void Update()
        {
            _navMeshAgent.speed = velocidadeAtual;
            _navMeshAgent.SetDestination(alvo.transform.position);
            UpdateAdicional();
            soldierMove();            
        }

        
        private void Morrer()
        {
            AoMorrer();
            if (!(vidaAtual <= 0)) return;
            Base.Instancia.Grana = recompensa;
            Base.Instancia.Inimigos.Remove(gameObject);
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            //Debug.Log(other.gameObject.name);
            var go = other.gameObject;
            if (!go.CompareTag("Bala")) return;
            var bala = go.GetComponent<Bala>();
            bala.AoAcertar(this);
            AoLevarDano(bala);
            Destroy(go);
        }

        protected void UpdateAdicional(){}

        protected void soldierMove()
        {

            anim.ResetTrigger("RightDown");
            anim.ResetTrigger("RightUp");
            anim.ResetTrigger("LeftDown");
            anim.ResetTrigger("LeftUp");
            anim.ResetTrigger("Down");
            anim.ResetTrigger("Up");

            if (transform.position.x < -1 && transform.position.y > 0.47) // comparar com posicao do canhao
            {
                anim.SetTrigger("RightDown");
            }

            if (transform.position.x < -1 && transform.position.y < 0.47) // comparar com posicao do canhao
            {
                anim.SetTrigger("RightUp");
            }

            if (transform.position.x > 1 && transform.position.x < 3 && transform.position.y > 0.47) // comparar com posicao do canhao
            {
                anim.SetTrigger("LeftDown");
            }

            if (transform.position.x > 1 && transform.position.x < 3 && transform.position.y < 0.47) // comparar com posicao do canhao
            {
                anim.SetTrigger("LeftUp");
            }

            if (transform.position.x > -1 && transform.position.x < 1 && transform.position.y > 0.47) // comparar com posicao do canhao
            {
                anim.SetTrigger("Down");
            }

            if (transform.position.x > -1 && transform.position.x < 1 && transform.position.y < 0.47) // comparar com posicao do canhao
            {
                anim.SetTrigger("Up");
            }

            if (transform.position.x > 3 && transform.position.x < 6.2)
            {
                anim.SetTrigger("RightDown");
            }

            if (transform.position.x > 6.2)
            {
                _navMeshAgent.speed = 0;                
                anim.SetTrigger("RightDown");
            }
        }
    }
}