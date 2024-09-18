<h1 align="center">Nota Fiscal (Invoice)</h1>

## 💻 Project
- Este projeto tem o objetivo de estudar design patterns em um contexto de negócio de geração de notas fiscais.

## Contexto de negócios
Existem dois tipos de notas fiscais no Brasil:
  - Serviço
  - Produto

Nesse projeto, o foco será na geração de nota fiscal de serviço e para isso existem algumas regras:
- Regime contábil de caixa: a emissão de nota é identificada com base no pagamento, ou seja, se entrou dinheiro no caixa.
- Regime de competência: a emissão de nota é identificada com base na entrega do serviço, ou seja, independente do pagamento.

- Além disso, essa nota fiscal também pode ser apresentada em diferentes formatos, como pdf e excel.

**Exemplo**
- As mensalidades de uma faculdade são dividas em 6 semestres (meses) e em 6 parcelas. Se você tiver uma parcela de 1000 reais e 6 meses de aula são 6 parcelas de 1000 reais.
- No exemplo acima, o regime de caixa e competência se casam.

**Questionamentos**
- Mas e se houver pagamento a vista das mensalidades? Qual será a regra para emissão da nota fiscal? Será uma nota fiscal de 6 mil reais ou vai seguir emitindo por mês?
- A resposta está no regime:
    - Se é de caixa: Só terá uma nota fiscal de 6000 reais.
    - Se é de competência: Terá várias notas fiscais de 6000 reais.

**Anotações**
- Atribuir um use case por classe (melhora a rastreabilidade, deixa mais limpo).

## 🧪 Techs
This project was develop with the following technologies:

- [.NET 8 Console Application](https://docs.microsoft.com/pt-br/dotnet/core/dotnet-7)

## How can I use?

You will need of the Visual Studio 2022 and .NET 8 SDK.
This SKDs and tools can be download in .NET 8 https://dot.net/core.
You can execute in Visual Studio Code too (Windows, Linux or MacOS)

## 🚀 How can I execute?

Clone the projet and access the pasta.

```bash
$ git clone https://github.com/rafaelaccampos/design-patterns-in-csharp
$ cd DesignPatterns

$ dotnet restore

```

To initiate the tests, follow the steps below:
```bash
$ dotnet test
```

