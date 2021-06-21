using municao;
using UnityEngine.PlayerLoop;

namespace inimigo
{
    public class InimigoNormal : Inimigo
    {
        protected override void AoMorrer(){}

        protected override void AoLevarDano(Bala bala)
        {
            var defesa = Defesa - bala.penetracao;
            var dano = bala.dano*(100f - defesa)/100;
            if (bala.tipo == "Leve")
                dano *= 1.25f;
            Vida = dano;
        }

        protected new void UpdateAdicional() {}
    }
}