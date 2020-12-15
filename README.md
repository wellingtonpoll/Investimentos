Apresentação
=====================
Esse projeto é a resolução do desafio proposto e foi implementado utilizando a IDE do Visual Studio 2019 e a versão .NET Core 3.1.

## Visão Geral:
A solução foi divida em quatro projetos, são eles:

- API
	- A primeira camada da aplicação fica aqui, onde o core da aplicação é exposto para consumo. Esse projeto possui referência do projeto de Domínio, expondo suas interfaces de serviço via injeção de dependência no contrutor do ConsolidadoController. As models utilizadas trafegam entre API e Domínio utilizando conversão de objetos com a utilização da biblioteca do AutoMapper. Essa e outras bibliotecas são acessadas via referência do projeto de domínio que por sua vez referencia o projeto de Infra, onde todas as bibliotecas foram instaladas.
- Domínio
	- A segunda camada da aplicação, e a principal, fica no projeto do Domínio, é lá que todos os requisitos do desafio proposto foram implementados. Esse projeto possui referência do projeto de Infra, e consome outras bibliotecas através dessa referência. A camanda de domínio expõe suas implementações através das classes de serviço e suas interfaces.
- Infra
	- A terceira camada da aplicação fica no projeto de Infra, onde todas as dependencias de pacotes ficam instaladas, abstraindo o resto da aplicação de uma dependencia direta com outras bibliotecas. Nessa camada ainda temos as implementações de dois recursos, utilização de cache e requisições HTTP.
- Testes
	- O projeto de testes é uma camada exclusiva para as implementações de testes. Ele possui referência para os projetos de Domínio e Infra.

## Logs:
No appsettings.json do projeto API estará a string de conexão de um banco de dados mongoDb com as credencias de acesso para a visualização dos logs. Esse banco está hospedado na nuvem do www.cloud.mongodb.com.
Para efetuar a persistência dos logs eu utilizei a biblioteca do Serilog. É uma biblioteca que já tenho uma certa experiência, tem uma utilização muito simples e promove uma abstração do repositrório de armazenamento para os logs que considero muito importante quando precisamos apontar a persistência de logs para outros locais.

## Testes Unitários:
Para a implementação dos testes unitários escolhi o xUnit por também já possuir experiência e ser uma biblioteca muito confortável de se utilizar. Utilizei também a biblioteca do AutoFixture para criação de objetos fake e também da biblioteca Moq. Todos os testes possuem um único Assert.
Os testes estão agrupados por categorias, são elas:

- CACHE MANAGER
    - 4 Testes 
- IMPOSTO RENDA
    - 3 Testes 
- VALOR RESGATE
    - 21 Testes

## Cache:
Para a utilização de cache eu utilizei o IMemoryCache por questões de praticidade, mas por se tratar de um cache dentro da aplicação, e isso não me agrada, eu implementei uma abstração entre o recurso de cache e a biblioteca do provedor do cache, isso da a possibilidade de se utilizar mais de uma alternativa de cache sem impacto no resto da aplicação simplismente alterando o ICacheProvider que é utilizado no ICacheManager na configuração de injeção de dependência.
Para o tempo de vida dos investimentos consolidados em cache foi implementado um calculo para pegar a partir do horário relativo até as 00:00 horas do dia seguinte, entretanto, para uma visualização do benefício que o cache causa na experiência do usuário, esse tempo de vida em cache foi configurado para 10 segundos.

## HTTP Request:
Para a utilização de requisições http uma implementação muito similiar com a do cache foi feita utilizando a biblioteca do restsharp, separando IRestManager do IRestProvider, uma implementação muito simples para desacoplar todo o projeto de bibliotecas externas.

## Entidades Domínio
Na camada de domínio para implementar os requisitos do teste eu criei três classes especializadas, uma para cada tipo de investimento, Fundo, Renda Fixa e Tesouro Direto. Todas essas classes herdam de uma classe abstrata chamada Investimento. O objetivo disso foi para ter dois benefícios, se utilizar do polimorfismo para implementar as aliquotas de imposto de renda que são diferentes para cada um dos inevstimentos, o segundo motivo foi para que eu não tivesse que implementar o calculo de imposto de renda e de valor de resgate mais de uma vez realizando essas implementações na classe base, extendendo seus comportamentos para as classes especializadas e permitindo que elas possam ser extendidas em vez de alteradas.

A classe base de investimento também foi utilizada para a implementação de um pattern de fábrica simplificando a construção das classes especializadas e garantindo que toda classe especializada que herde de investimento realize as chamadas para os metodos de calculo de imposto de renda e de valor de resgate.

## Consumo de endpoints externos
A classe de InvestimentoServico é responsável por orquestrar as chamadas para os endpoints mocados disparando requisições asincronas para cada um deles e unificando os resultados obtidos, armazenando em cache e depois disso retorna os resultados, uma vez em cache essa classe não irá sincronizar os dados dos endpoints externos até que os dados do cache expirem.
