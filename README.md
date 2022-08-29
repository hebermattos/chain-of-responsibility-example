# Modelando regras com Chain of Responsibility e Template Method

solitação de empréstimo:

regras:
- idade menor que X
- salario maior que X
- valor do empréstimo não pode ser mais que X vezes o salario

```
    var regraIdadeAlta = new RegraIdadeAlta(model, 75);
    var regraValorEmprestimo = new RegraValorEmprestimo(model, regraIdadeAlta, 5);
    var regraSalario = new RegraSalario(model, regraValorEmprestimo, 1000);

    var resultado = regraSalario.VerificarRegras();
```

para adicionar uma nova regra:
- criar uma classe que herde de RegraEmprestimo:

```
    public class RegraIdadeBaixa : RegraEmprestimo
    {
        private int _idade;

        public RegraIdadeBaixa(SolicitacaoEmprestimo solicitacaoEmprestimo, int idade) : base(solicitacaoEmprestimo, null)
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