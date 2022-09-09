using Microsoft.AspNetCore.Mvc;

namespace regras_encadeadas.Controllers;

[ApiController]
[Route("[controller]")]
public class EmprestimosController : ControllerBase
{
    [HttpPost]
    public ResultadoSolicitacaoEmprestimo Post([FromBody] SolicitacaoEmprestimo model)
    {
        var regraIdadeAlta = new RegraIdadeAlta(model, 75);
        var regraIdadeBaixa = new RegraIdadeBaixa(model, 18);
        var regraValorEmprestimo = new RegraValorEmprestimo(model, 5);
        var regraSalario = new RegraSalario(model, 1000);
        var regraSerasa = new RegraSerasa(model, new ProxyProvedorSerasa(new FakeCache(), new ProvedorSerasa()));

        regraIdadeAlta.DefinirProximaRegra(regraIdadeBaixa);
        regraIdadeBaixa.DefinirProximaRegra(regraValorEmprestimo);
        regraValorEmprestimo.DefinirProximaRegra(regraSalario);
        regraSalario.DefinirProximaRegra(regraSerasa);

        var resultado = regraIdadeAlta.VerificarRegras();

        var notificador = new Notificador();

        notificador.Registrar(new NotificacaoEmail());
        notificador.Registrar(new NotificacaoSms());

        notificador.Enviar();

        var logEmprestimo = new LogEmprestimo();

        logEmprestimo.Logar(model, resultado, new LogArquivoJson());

        return resultado;
    }
}