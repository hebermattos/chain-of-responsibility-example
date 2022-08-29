using Microsoft.AspNetCore.Mvc;

namespace regras_encadeadas.Controllers;

[ApiController]
[Route("[controller]")]
public class EmprestimosController : ControllerBase
{
    [HttpPost]
    public ResultadoSolicitacaoEmprestimo Post([FromBody]SolicitacaoEmprestimo model)
    {
        var regraIdade = new RegraIdade(model, 75);
        var regraValorEmprestimo = new RegraValorEmprestimo(model, regraIdade, 5);
        var regraSalario = new RegraSalario(model, regraValorEmprestimo, 1000);

        var resultado = regraSalario.VerificarRegras();

        return resultado;
    }
}