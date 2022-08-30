namespace regras_encadeadas.Controllers
{
    internal class RegraSerasa : RegraEmprestimo
    {
        private IProvedorSerasa _provedorSerasa;

        public RegraSerasa(SolicitacaoEmprestimo solicitacaoEmprestimo, IProvedorSerasa provedorSerasa) : base(solicitacaoEmprestimo)
        {
            _provedorSerasa = provedorSerasa;
        }

        public override string NomeRegra => "serasa";

        public override bool VerificarRegra()
        {
            return _provedorSerasa.PossuiRestriacao(SolicitacaoEmprestimo.Cpf);
        }
    }
}