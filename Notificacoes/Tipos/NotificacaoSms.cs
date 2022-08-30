namespace regras_encadeadas.Controllers
{
    internal class NotificacaoSms : INotificacao
    {
        public void Enviar()
        {
            Console.WriteLine("Enviou SMS...");
        }
    }
}