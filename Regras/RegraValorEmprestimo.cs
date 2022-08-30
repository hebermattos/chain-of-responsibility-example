namespace regras_encadeadas.Controllers
{
    public class RegraValorEmprestimo : RegraEmprestimo
    {
        private int _multiplicador;

        public RegraValorEmprestimo(SolicitacaoEmprestimo solicitacaoEmprestimo, int multiplicador) : base(solicitacaoEmprestimo)
        {
            _multiplicador = multiplicador;
        }

        public override string NomeRegra => "Valor do Emprestimo";

        public override bool VerificarRegra()
        {
            return SolicitacaoEmprestimo.Valor >  SolicitacaoEmprestimo.Salario * _multiplicador;
        }
    }
}