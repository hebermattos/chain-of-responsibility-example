# Exemplificando padrões de projeto

## Chain of Responsibility 

Solitação de empréstimo:

Regras:
- Idade maior que X
- Salario maior que X
- Valor do empréstimo não pode ser mais que X vezes o salario
- Restrição na Serasa

```
        var regraIdadeAlta = new RegraIdadeAlta(model, 75);
        var regraValorEmprestimo = new RegraValorEmprestimo(model,  5);
        var regraSalario = new RegraSalario(model,  1000);
        var regraSerasa = new RegraSerasa(model, new ProxyProvedorSerasa(new ProvedorSerasa()));

        regraIdadeAlta.DefinirProximaRegra(regraValorEmprestimo);
        regraValorEmprestimo.DefinirProximaRegra(regraSalario);        
        regraSalario.DefinirProximaRegra(regraSerasa);

        var resultado = regraIdadeAlta.VerificarRegras();
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
        var regraIdadeBaixa = new RegraIdadeBaixa(model, 18);
        var regraValorEmprestimo = new RegraValorEmprestimo(model,  5);
        var regraSalario = new RegraSalario(model,  1000);
        var regraSerasa = new RegraSerasa(model, new ProxyProvedorSerasa(new ProvedorSerasa()));

        regraIdadeAlta.DefinirProximaRegra(regraIdadeBaixa);
        regraIdadeBaixa.DefinirProximaRegra(regraValorEmprestimo);
        regraValorEmprestimo.DefinirProximaRegra(regraSalario);        
        regraSalario.DefinirProximaRegra(regraSerasa);

        var resultado = regraIdadeAlta.VerificarRegras();
```

O importante na Chain of Responsibility é encadear as objetos na ordem adequada, e sempre comecar com o primeiro objeto da cadeia, que eventualmente vai chamar os objetos encadeados previamente.

## Utilizando Observer para notificações

Método "Enviar" executa todas as notificações registradas

```
        var notificador = new Notificador();

        notificador.Registrar(new NotificacaoEmail());
        notificador.Registrar(new NotificacaoSms());

        notificador.Enviar();
```

## Utilizando Proxy para cache no ProvedorSerasa

Criamos uma outra classe para para fazer o cache, não modificando a classe original, podendo substituir pela mesma

```
        var regraSerasa = new RegraSerasa(model, new ProxyProvedorSerasa(new ProvedorSerasa()));
```

## Utilizando Strategy para o log

Criamos uma outra classe especializada em salvar os dados, podendo alterar para qualquer implementação do ILogStrategy

```
        logEmprestimo.Logar(model, resultado, new LogArquivoJson());
```