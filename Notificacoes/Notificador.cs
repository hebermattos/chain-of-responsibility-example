namespace regras_encadeadas.Controllers
{
    public class Notificador
    {
        private List<INotificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes =  new List<INotificacao>();
        }

        public void Registrar(INotificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public void Enviar()
        {
            foreach (var notificacao in _notificacoes)
            {
                notificacao.Enviar();
            }
        }
    }
}