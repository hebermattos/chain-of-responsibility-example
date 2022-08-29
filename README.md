# Modelando regras com Chain of Responsibility e Template Method

Solitação de empréstimo:

Regras:
- Idade menor que X
- Salario maior que X
- Valor do empréstimo não pode ser mais que X vezes o salario

```
    var regraIdadeAlta = new RegraIdadeAlta(model, 75);
    var regraValorEmprestimo = new RegraValorEmprestimo(model, regraIdadeAlta, 5);
    var regraSalario = new RegraSalario(model, regraValorEmprestimo, 1000);

    var resultado = regraSalario.VerificarRegras();
```

Para adicionar uma nova regra:
- Criar uma classe que herde de RegraEmprestimo:
```
    public class RegraIdadeBaixa : RegraEmprestimo
    {
        private int _idade;

        public RegraIdadeBaixa(SolicitacaoEmprestimo solicitacaoEmprestimo, RegraEmprestimo proximaRegra, int idade) : base(solicitacaoEmprestimo, proximaRegra)
        {
            _idade = idade;
        }

        public override string NomeRegra => "Idade baixa";

        public override bool VerificarRegra()
        {
            return SolicitacaoEmprestimo.Idade < _idade;
        }
    }
```
- Adicione ela no fluxo, na parte mais adequada:
```
    var regraIdadeAlta = new RegraIdadeAlta(model, 75);
    var regraIdadeBaixa = new RegraIdadeBaixa(model, regraIdadeAlta, 18);
    var regraValorEmprestimo = new RegraValorEmprestimo(model, regraIdadeBaixa, 5);
    var regraSalario = new RegraSalario(model, regraValorEmprestimo, 1000);

    var resultado = regraSalario.VerificarRegras();
```

O importante na Chain of Responsibility é encadear as objetos na ordem adequada, e sempre comecar a execução com o úlitmo, que eventualmente vai chamar objetos encadeados previamente.