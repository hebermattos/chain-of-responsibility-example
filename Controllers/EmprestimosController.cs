using Microsoft.AspNetCore.Mvc;

namespace regras_encadeadas.Controllers;

[ApiController]
[Route("[controller]")]
public class EmprestimosController : ControllerBase
{
    public ResultadoSolicitacaoEmprestimo Post(SolicitacaoEmprestimo model)
    {
        var regraIdade = new RegraIdade(model);
        var regraValorEmprestimo = new RegraValorEmprestimo(model, regraIdade);
        var regraSalario = new RegraSalario(model, regraValorEmprestimo);

        var resultado = regraSalario.VerificarRegras();

        return resultado;
    }
}