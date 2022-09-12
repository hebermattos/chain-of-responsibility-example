using System.Text.Json;

namespace regras_encadeadas.Controllers
{
    public class LogArquivoJson: ILogStrategy
    {
        public void Salvar(MensagemLog mensagemLog)
        {
            string json = JsonSerializer.Serialize(mensagemLog);

            File.AppendAllText("log.json", json);
        }
    }
}