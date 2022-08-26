namespace regras_encadeadas.Controllers
{
    internal class RegraValorEmprestimo : RegraEmprestimo
    {
        public RegraValorEmprestimo(SolicitacaoEmprestimo solicitacaoEmprestimo, RegraEmprestimo proximaRegra) : base(solicitacaoEmprestimo, proximaRegra)
        {
        }

        public override string NomeRegra => "Valor do Emprestimo";

        public override bool VerificarRegra()
        {
            return SolicitacaoEmprestimo.Valor > 100000;
        }
    }
}