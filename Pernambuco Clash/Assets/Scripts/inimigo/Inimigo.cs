using System;
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
        public float porcentagemVida = 1f;
        public GameObject barraVida;
        public Animator anim;

        public float Vida
        {
            get => vidaAtual;
            set
            {
                vidaAtual -= value;
                if (vidaAtual >= vidaMaxima) vidaAtual = vidaMaxima;
                if (vidaAtual < 0)
                {
                    vidaAtual = 0;
                    porcentagemVida = 0f;
                    Morrer();
                }
                var vec = barraVida.transform.localScale;
                porcentagemVida = vidaAtual / vidaMaxima;
                barraVida.transform.localScale = new Vector3(porcentagemVida, vec.y, vec.z);
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
                if (_navMeshAgent == null)
                    _navMeshAgent = GetComponent<NavMeshAgent>();
                _navMeshAgent.speed = velocidadeAtual;
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
            StartAdicional();
        }

        #endregion

        protected void Update()
        {
            _navMeshAgent.SetDestination(alvo.transform.position);
            UpdateAdicional();
            if (anim != null)
            {
                soldierMove();
                shipMove();
            }
            
        }


        private void Morrer()
        {
            AoMorrer();
            if (!(vidaAtual <= 0)) return;
            anim.SetBool("IsDead", true);

            Base.Instancia.Grana = recompensa;
            Base.Instancia.Inimigos.Remove(gameObject);
            
            Destroy(gameObject, 0.4f);
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

        protected abstract void UpdateAdicional();
        protected abstract void StartAdicional();

        protected void soldierMove()
        {

            anim.ResetTrigger("RightDown");
            anim.ResetTrigger("RightUp");
            anim.ResetTrigger("LeftDown");
            anim.ResetTrigger("LeftUp");
            anim.ResetTrigger("Down");
            anim.ResetTrigger("Up");

            if (transform.position.x < -1 && transform.position.y > 0.47) anim.SetTrigger("RightDown"); // comparar com posicao do canhao

            if (transform.position.x < -1 && transform.position.y < 0.47) anim.SetTrigger("RightUp"); // comparar com posicao do canhao

            if (transform.position.x > 1 && transform.position.x < 3 && transform.position.y > 0.47) anim.SetTrigger("LeftDown"); // comparar com posicao do canhao

            if (transform.position.x > 1 && transform.position.x < 3 && transform.position.y < 0.47) anim.SetTrigger("LeftUp");// comparar com posicao do canhao

            if (transform.position.x > -1 && transform.position.x < 1 && transform.position.y > 0.47) anim.SetTrigger("Down"); // comparar com posicao do canhao

            if (transform.position.x > -1 && transform.position.x < 1 && transform.position.y < 0.47) anim.SetTrigger("Up"); // comparar com posicao do canhao

            if (transform.position.x > 3 && transform.position.x < 6.2) anim.SetTrigger("RightDown");

            /*if (transform.position.x > 6.2)
            {
                _navMeshAgent.speed = 0;
                anim.SetTrigger("RightDown");
            }*/
        }

        protected void shipMove()
        {

            anim.ResetTrigger("down");
            anim.ResetTrigger("right");
            anim.ResetTrigger("left");
            anim.ResetTrigger("up");

            if (transform.position.x > -12 && transform.position.x < -4.5 || transform.position.x > -3.8 && transform.position.x < -0.5 || transform.position.x > 0.3 && transform.position.x < 4.9 || transform.position.x > 5.8) anim.SetTrigger("right");

            if (transform.position.x > -4.5 && transform.position.x < -3.8 || transform.position.x > 4.9 && transform.position.x < 5.8) anim.SetTrigger("down");
            
            if (transform.position.x > -0.5 && transform.position.x < 0.3) anim.SetTrigger("up");

        }
    }
}