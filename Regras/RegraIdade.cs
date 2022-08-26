namespace regras_encadeadas.Controllers
{
    public class RegraIdade : RegraEmprestimo
    {
        public RegraIdade(SolicitacaoEmprestimo solicitacaoEmprestimo) : base(solicitacaoEmprestimo, null)
        {
        }

        public override string NomeRegra => "Idade";

        public override bool VerificarRegra()
        {
            return SolicitacaoEmprestimo.Idade > 85;

        }
    }
}