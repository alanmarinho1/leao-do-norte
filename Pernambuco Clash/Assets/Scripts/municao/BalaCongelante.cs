using inimigo;

namespace municao
{
    public class BalaCongelante:Bala
    {
        public float reducaoVelocidade;
        public override void AoAcertar(Inimigo alvo)
        {
            if (alvo.Velocidade > alvo.velocidadeBase * .4f)
                alvo.velocidadeBase = reducaoVelocidade;
        }

        protected override void Redireciona()
        {
        }

        protected override void Movimentar()
        {
        }
        
    }
}