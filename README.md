# EduTechPlatform

Plataforma acadêmica e financeira desenvolvida em .NET, focada na aplicação de boas práticas de arquitetura de software, isolamento de regras de negócio e garantia da qualidade com testes automatizados utilizando xUnit.

## Requisitos do Ambiente

* [.NET 10 SDK](https://www.google.com/search?q=https%3A%2F%2Fdotnet.microsoft.com%2F) (ou versão instalada compatível, como .NET 8 ou 9).
* Git para controle de versionamento.
* IDE ou editor de código (VS Code, Visual Studio ou JetBrains Rider).

## Visão Geral da Plataforma

A **EduTechPlatform** centraliza rotinas de cálculo de desempenho estudantil, controle de assiduidade escolar e validações financeiras de matrícula e mensalidade, estruturada sob a seguinte divisão de projetos:

* **EduTechPlatform.App**: Biblioteca/aplicativo central contendo as classes de serviço e as regras de domínio.
* **EduTechPlatform.Tests**: Suíte de testes unitários parametrizados com xUnit para validação contínua da integridade do sistema.

## Responsabilidade das Classes de Serviço

### 1. `NotaDesempenhoService`
Responsável pela gestão de notas e status acadêmico:
* `CalcularMediaPonderada(decimal nota1, decimal nota2, decimal notaProjeto)`: realiza a ponderação com Nota 1 (peso 3), Nota 2 (peso 3) e Projeto (peso 4), dividindo o montante por 10.
* `ObterSituacaoAcademica(decimal mediaFinal)`: determina a situação do estudante com base nos critérios institucionais:
  * `"APROVADO"`: média igual ou superior a 7.0.
  * `"RECUPERACAO"`: média entre 5.0 e 6.99.
  * `"REPROVADO"`: média inferior a 5.0.

### 2. `FrequenciaService`
Responsável pelo controle de assiduidade e presença escolar:
* `CalcularPorcentagemPresenca(int aulasTotais, int faltas)`: calcula o percentual de presenças em relação à carga horária total ministrada.
* `AprovadoPorFrequencia(int aulasTotais, int faltas)`: verifica se o estudante alcançou o limite mínimo regulamentar de 75% de presença para aprovação direta por frequência.

### 3. `MatriculaFinanceiraService`
Responsável pelas regras financeiras e validações de rematrícula:
* `CalcularValorMensalidade(decimal valorBase, int diaPagamento, bool eBolsista)`: calcula a cobrança com base em políticas de benefício e pontualidade:
  * Bolsistas (`eBolsista = true`): desconto fixo de 50%, independente do dia de pagamento.
  * Não bolsistas pagando até o dia 5: desconto de 10% por pontualidade.
  * Não bolsistas pagando após o dia 5: valor integral sem desconto.
* `PodeRealizarRematricula(bool possuiPendenciaFinanceira, string situacaoAcademica)`: autoriza a renovação de matrícula apenas quando o estudante não possui pendência financeira ativa e sua situação acadêmica não é classificada como `"REPROVADO"`.

## Guia de Execução (CLI)

Execute os comandos abaixo a partir da raiz da solução:

1. **Restaurar dependências do projeto:**
   ```bash
   dotnet restore
   ```

2. **Compilar a solução e verificar integridade:**
   ```bash
   dotnet build
   ```

3. **Executar as suítes de testes automatizados:**
   ```bash
   dotnet test
   ```

## Testes Automatizados com xUnit

A garantia de qualidade do sistema foi implementada aplicando **testes baseados em dados (Data-Driven Tests)** com xUnit através dos atributos `[Theory]` e `[InlineData]`:

* **Otimização de código de teste:** permite que um único método de teste seja executado repetidas vezes sob conjuntos variados de entradas e saídas esperadas, eliminando código redundante.
* **Validação de cenários limítrofes:** garante cobertura sistemática para valores de fronteira, tais como transição de médias de aprovação e recuperação, percentual exato de 75% de frequência, regras de datas de vencimento de boleto e combinação de pendências financeiras com situação acadêmica.

## Licença

Este projeto está licenciado sob os termos da licença [MIT](https://www.google.com/search?q=LICENSE).

## Contribuidores

* **Desenvolvedor 1 (Dev Backend / Core):** Estrutura inicial e regras de negócio.
* **Desenvolvedor 2 (QA / Testes Unitários):** Suítes de testes parametrizadas em xUnit.
* **Desenvolvedor 3 (Documentação e DevOps):** Repositório, versionamento, .gitignore e README.
