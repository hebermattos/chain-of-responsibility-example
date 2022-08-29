namespace regras_encadeadas.Controllers
{
    public abstract class RegraEmprestimo
    {
        public RegraEmprestimo? ProximaRegra;
        protected SolicitacaoEmprestimo SolicitacaoEmprestimo;

        public abstract bool VerificarRegra();
        public abstract string NomeRegra { get; }

        public RegraEmprestimo(SolicitacaoEmprestimo solicitacaoEmprestimo, RegraEmprestimo? proximaRegra)
        {
            SolicitacaoEmprestimo = solicitacaoEmprestimo;
            ProximaRegra = proximaRegra;
        }

        public ResultadoSolicitacaoEmprestimo VerificarRegras()
        {
            var regraBateu = VerificarRegra();

            if (regraBateu)
            {
                return new ResultadoSolicitacaoEmprestimo
                {
                    Aprovado = false,
                    Motivo = NomeRegra
                };
            }

            if (ProximaRegra != null)
            {
                return ProximaRegra.VerificarRegras();
            }

            return new ResultadoSolicitacaoEmprestimo
            {
                Aprovado = true
            };
        }
    }
}