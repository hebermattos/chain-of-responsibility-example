namespace regras_encadeadas.Controllers
{
    public class LogEmprestimo
    {
        public LogEmprestimo()
        {
        }

        public void Logar(SolicitacaoEmprestimo model, ResultadoSolicitacaoEmprestimo resultado, ILogStrategy strategy)
        {
            var mensagemLog = new MensagemLog
            {
                Solicitacao = model,
                Resultado = resultado
            };

            strategy.Salvar(mensagemLog);
        }
    }
}