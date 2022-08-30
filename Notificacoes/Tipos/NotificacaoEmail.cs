namespace regras_encadeadas.Controllers
{
    internal class NotificacaoEmail: INotificacao
    {
        public void Enviar()
        {
            Console.WriteLine("Enviou email...");
        }
    }
}