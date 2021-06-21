using inimigo;
using UnityEngine;
using UnityEngine.AI;

namespace municao
{
    public abstract class Bala : MonoBehaviour
    {
        public GameObject alvo;
        public float dano;
        public float penetracao;
        public float velocidadeBase;
        private NavMeshAgent _navMeshAgent;
        public string tipo;

        public abstract void AoAcertar(Inimigo alvo);

    }
}