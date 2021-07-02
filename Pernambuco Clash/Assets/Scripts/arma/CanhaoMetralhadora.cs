namespace arma
{
    public class CanhaoMetralhadora : Canhao
    {
        public float passo;
        public float cadenciaInicial;
        public float velocidadeMinima;
        public float crescimentoPasso;
        public float crescimentoMinimo;
        protected override void Dispara()
        {
            var go = Instantiate(balaPrefab);
            go.transform.position = transform.position;
            BalaDeCanhao(go);
        }

        protected override void Localizar()
        {
            LocalizaMaisVida();
        }

        protected override void AoAtirar()
        {
            cadencia -= passo;
            if (cadencia <= velocidadeMinima)
                cadencia = velocidadeMinima;

        }

        protected override void AoMudarAlvo()
        {
            cadencia = cadenciaInicial;
        }

        protected override void AoMelhorar()
        {
            passo += crescimentoPasso;
            cadenciaInicial -= crescimentoMinimo;
            if (cadenciaInicial <= 0)
                cadenciaInicial = 0.1f;
        }
    }
}