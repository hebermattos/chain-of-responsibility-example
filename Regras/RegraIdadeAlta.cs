namespace regras_encadeadas.Controllers
{
    public class RegraIdadeAlta : RegraEmprestimo
    {
        private int _idade;

        public RegraIdadeAlta(SolicitacaoEmprestimo solicitacaoEmprestimo, int idade) : base(solicitacaoEmprestimo)
        {
            _idade = idade;
        }

        public override string NomeRegra => "Idade alta";

        public override bool VerificarRegra()
        {
            return SolicitacaoEmprestimo.Idade > _idade;
        }
    }
}