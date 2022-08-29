# Modelando regras com Chain of Responsibility e Template Method

solitação de empréstimo:

regras:
- idade menor que X
- salario maior que X
- valor do empréstimo não pode ser mais que X vezes o salario

´´´
    var regraIdade = new RegraIdade(model, 75);
    var regraValorEmprestimo = new RegraValorEmprestimo(model, regraIdade, 5);
    var regraSalario = new RegraSalario(model, regraValorEmprestimo, 1000);

    var resultado = regraSalario.VerificarRegras();

´´´