using System;
using municao;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
namespace inimigo
{
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
        public float defesaBase;
        public GameObject barraVida;

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
                    Morrer();
                }

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
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
            _navMeshAgent.speed = velocidadeBase;
            alvo = GameObject.FindWithTag("Base");
            Debug.Log(transform.position + " -> " +alvo.transform.position);
            //barraVida.maxValue = vidaMaxima;
            //barraVida.value = vidaAtual;
        }

        #endregion
        

        protected void Update()
        {
            //_navMeshAgent.speed = Velocidade;
            _navMeshAgent.SetDestination(alvo.transform.position);
            Debug.Log("*");
        }

        
        private void Morrer()
        {
            AoMorrer();
            if(vidaAtual <= 0)
                Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            var go = other.gameObject;
            if (!go.CompareTag("Bala")) return;
            var bala = go.GetComponent<Bala>();
            bala.AoAcertar(this);
            AoLevarDano(bala);
        }
    }
}