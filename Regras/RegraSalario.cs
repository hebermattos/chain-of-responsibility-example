namespace regras_encadeadas.Controllers
{
    public class RegraSalario : RegraEmprestimo
    {
        private int _salario;

        public RegraSalario(SolicitacaoEmprestimo solicitacaoEmprestimo, int salario) : base(solicitacaoEmprestimo)
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