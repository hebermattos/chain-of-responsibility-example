namespace regras_encadeadas.Controllers
{
    internal class RegraSalario : RegraEmprestimo
    {
        public RegraSalario(SolicitacaoEmprestimo solicitacaoEmprestimo, RegraEmprestimo proximaRegra) : base(solicitacaoEmprestimo, proximaRegra)
        {
        }

        public override string NomeRegra => "salario";

        public override bool VerificarRegra()
        {
            return SolicitacaoEmprestimo.Salario < 1000;
        }
    }
}