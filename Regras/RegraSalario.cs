namespace regras_encadeadas.Controllers
{
    internal class RegraSalario : RegraEmprestimo
    {
        private int _salario;

        public RegraSalario(SolicitacaoEmprestimo solicitacaoEmprestimo, RegraEmprestimo proximaRegra, int salario) : base(solicitacaoEmprestimo, proximaRegra)
        {
            _salario = salario;
        }

        public override string NomeRegra => "salario";

        public override bool VerificarRegra()
        {
            return SolicitacaoEmprestimo.Salario < _salario;
        }
    }
}