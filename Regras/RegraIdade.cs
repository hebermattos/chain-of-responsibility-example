namespace regras_encadeadas.Controllers
{
    public class RegraIdade : RegraEmprestimo
    {
        private int _idade;

        public RegraIdade(SolicitacaoEmprestimo solicitacaoEmprestimo, int idade) : base(solicitacaoEmprestimo, null)
        {
            _idade = idade;
        }

        public override string NomeRegra => "Idade";

        public override bool VerificarRegra()
        {
            return SolicitacaoEmprestimo.Idade > _idade;
        }
    }
}