using Microsoft.AspNetCore.Mvc;

namespace regras_encadeadas.Controllers;

[ApiController]
[Route("[controller]")]
public class EmprestimosController : ControllerBase
{
    [HttpPost]
    public ResultadoSolicitacaoEmprestimo Post([FromBody]SolicitacaoEmprestimo model)
    {
        var regraIdadeAlta = new RegraIdadeAlta(model, 75);
        var regraIdadeBaixa = new RegraIdadeBaixa(model, regraIdadeAlta, 18);
        var regraValorEmprestimo = new RegraValorEmprestimo(model, regraIdadeBaixa, 5);
        var regraSalario = new RegraSalario(model, regraValorEmprestimo, 1000);

        var resultado = regraSalario.VerificarRegras();

        return resultado;
    }
}