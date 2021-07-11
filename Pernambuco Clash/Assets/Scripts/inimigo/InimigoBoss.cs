using System.Linq.Expressions;
using mundo;
using municao;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace inimigo
{
    public class InimigoBoss : Inimigo
    {
        protected override void AoMorrer(){}
        public int hitPraInvocar;
        public int hits;
        public bool curaDisponivel = false;
        public Inimigo minionPrefab;

        protected override void AoLevarDano(Bala bala)
        {
            ++hits;
            var defesa = Defesa - bala.penetracao;
            var dano = bala.dano*(100f - defesa)/100;
            if (bala.tipo == "Leve")
                dano *= 1.25f;
            Vida = dano;
        }

        protected override void UpdateAdicional()
        {
            if (hits >= hitPraInvocar)
                Criar();
            if (curaDisponivel && porcentagemVida <= .2f)
                Curar();
        }

        private void Criar()
        {
            hits = 0;
            var minion = Instantiate(minionPrefab);
            minion.transform.position = transform.position;
        }

        private void Curar()
        {
        }

        protected override void StartAdicional()
        {
            curaDisponivel = true;
            hits = 0;
            minionPrefab = FabricaInimigo.Instancia.GetInimigo("ship");
            minionPrefab.vidaMaxima /= 3;
            minionPrefab.Vida = -minionPrefab.vidaMaxima;
            minionPrefab.Velocidade /=  -3;
        }
    }
}