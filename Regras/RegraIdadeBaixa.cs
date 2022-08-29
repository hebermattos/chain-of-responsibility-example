namespace regras_encadeadas.Controllers
{
    public class RegraIdadeBaixa : RegraEmprestimo
    {
        private int _idade;

        public RegraIdadeBaixa(SolicitacaoEmprestimo solicitacaoEmprestimo, int idade) : base(solicitacaoEmprestimo, null)
        {
            _idade = idade;
        }

        public override string NomeRegra => "Idade baixa";

        public override bool VerificarRegra()
        {
            return SolicitacaoEmprestimo.Idade < _idade;
        }
    }
}