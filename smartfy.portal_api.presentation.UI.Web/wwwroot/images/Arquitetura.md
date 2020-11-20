# Arquitetura

A aplicação deve rodar com os componentes de forma independente e desacoplados uns dos outros, permitindo que caso uma seção da aplicação fique indisponível não pare a aplicação.

O conceito principal é trabalhar com o padrão **Event Driven - PubSub baseado em programação funcional**, ou seja, com uma arquitetura orientada a eventos usando o padrão publish/subscribe. 

As arquiteturas orientadas a eventos, se baseiam em um padrão comum no desenvolvimento de software, **publish/subscribe** ou no padrão **observer**.

Em uma arquitetura orientada a eventos, existem pelo menos dois atores: o **emissor** e o **observador**.

O **emissor** transmite dados, como uma mensagem, para qualquer **observador**. Pode haver apenas um ou cem observadores, não importa, desde que o sujeito tenha alguma mensagem a transmitir.

Ao clicar em um botão, o clique é um evento, o botão é um emissor e a função que captura este clique é um observador.<br />

## Publish/Subscribe

![PubSub](https://d1.awsstatic.com/product-marketing/Messaging/sns_img_topic.e024462ec88e79ed63d690a2eed6e050e33fb36f.png)

Padrão de design que permite criar módulos que podem se comunicar uns com os outros sem depender diretamente uns dos outros. Permite que as mensagens sejam transmitidas para diferentes partes de um sistema de forma assíncrona. 

Quando um evento é disparado, publicado, todos os assinantes tem acesso ao dados enviados atraves do evento. Os componentes inscritos se mantem atualizados de forma individual, podendo remover sua inscrição e se inscrever em outras publicações.<br />

## Event Driven

![Event Driven](https://dzone.com/storage/temp/6520586-pushpin.jpg)



Na imagem podemos ver como um padrão orientado a eventos se comporta em relação ao padrão Cliente-Servidor.<br />

Padrão de arquitetura criado para lidar com um grande número de conexões simultâneas com consumo mínimo de recursos. As aplicações mais modernas precisam de um modelo totalmente assíncrono para escalar. Essas estruturas da web modernas fornecem um comportamento mais confiável em um ambiente distribuído.<br />

Streaming de dados é visto como uma ferramenta útil para implementar uma arquitetura baseada em eventos.

Eventos são processos,dentro de um sistema ou software. Uma aplicação orientada a eventos é aquela organizada em torno da reação a esses eventos. Exemplo:

- Uma transação de pagamento concluída.
- Uma tentativa de acesso que não foi autorizado.<br />

**Pros**:

- Facilmente adaptável a ambientes complexos.
- Escala facilmente.
- Facilmente expansíveis quando novos tipos de eventos aparecem.<br />

**Contras**:

- Teste complexos. As interações só podem ser testadas em um sistema totalmente funcional.
- Tratamento de erros complexos.
- Um evento precisa sempre ser respondido.<br />

## Programação Funcional

A base da programação funcional descreve que *as funções devem se manter isoladas e incapazes de impactar outras partes do sistema.* Funções puras são estáveis, consistentes e previsíveis. A baixo segue um conceito básico sobre programação funcional.<br />

```javascript
// Função não pura:

const PI = 3.14;
const calculateAreaNotPure = (radius) => radius * radius * PI;
calculateAreaNotPure(10); // 314.0
```

```javascript
// Função pura:

const PI = 3.14;
const calculateAreaPure = (radius, pi) => radius * radius * pi;
calculateAreaPure(10, PI); // 314.0
```

<br />

### Imutabilidade

A imutabilidade do código, significa que apos a criação o estado não pode ser alterado. Para alterar um estado imutável, deve se criar um estado com um novo valor.<br />

```javascript
// Imutabilidade:

let list = [1, 2, 3, 4, 5];
let accumulator = 0;

const sum = (list, accumulator) => {
  if (list.length === 0) return accumulator;
  return sum(list.slice(1), accumulator + list[0]);
};

sum(list, accumulator); // 15
list; // [1, 2, 3, 4, 5]
accumulator; // 0
```

<br />

### Transparência referencial

Transparência referencial, a função da uma mesma entrada produzira uma mesma saída. Pode se afirmar que: **funções puras + imutabilidade  = transparência referencial**.<br />

```javascript
// Tranparência referencial:

const square = (n) => n * n;

square(2); // 4
square(4); // 16
square(8); // 64
```

<br />

### Funções de primeira classe

As funções são tratadas como valores e usadas como dados. Podem ser referenciadas a partir de constantes e variáveis, passadas como parâmetro para outras funções e retornadas de outras funções. Dessa forma podemos criar novas funções usando combinações de funções de primeira classe.<br />

```javascript
// Funções de Primeira classe:

const sum = (a, b) => a + b;
const subtraction = (a, b) => a - b;

// doubleOperator é uma função de ordem superior
const doubleOperator = (f, a, b) => f(a, b) * 2;

doubleOperator(sum, 3, 1); // 8
doubleOperator(subtraction, 3, 1); // 4
```

<br />

### Funções de ordem superior

Assume uma ou mais funções como argumento, retorna uma função como resultado. <br />

# Aplicando os conceitos

Este tópico define como os conceitos de arquitetura serão aplicados ao escopo do **React-Native**, detalhes como de como a arquitetura será implementada:

## Dependências

- Node
- React-Native
- React-Navigation
- Styled-Components
- Styled-System
- Vasern
- Husky
- Lint-Staged
- Prettier
- Eslint

## Estrutura

A ideia é usar o **princípio da separação de preocupações** (principle of separation of concerns) para afastar a lógica de negócios das rotas, no caso as views (screens). A estrutura segue o padrão **VIPER(Views, Interactor, Presenter, Entity, Routes)** com uma adição da *models*, para armazenamento off-line e gerenciamento de dados.

```
 src
  │
  └─ __test__			# Arquivos de teste da aplicação.
  └─ entity				# Estrutura de dados e dados off-line.
  	 └─ index.js		# Index do módulo models.
  └─ interactor			# Chamadas de API e serviços.
  └─ presenter          # Event handlers, tarefas assíncronas.
  └─ routes				# Definação das rotas.
  └─ themes				# Design System.
  	 └─ atoms
  	 └─ molecules
  	 └─ organisms
  	 └─ templates
  	 └─ theme.js	    # Definição do tema.
  └─ views				# Telas da aplicação.
  └─ app.js			    # Index do módulo src.
```

<br />

## Pipeline

![Pipeline Viper](https://koenig-media.raywenderlich.com/uploads/2018/02/viper-scheme-480x273.png)

### definição

- **test**, arquivos de testes da aplicação.
- **entity**, estrutura de gerenciamento e manutenção de dados da aplicação.
- **views**, telas da aplicação.
- **interactor**, vai realizar as chamadas de API e os serviços internos da aplicação.
- **presenter**, onde a logica e a estrutura do padrão PubSub, Publish/Subscribe é definida. Neste diretório e onde os eventos serão repassados aos componentes, neste caso componentes, seriam estruturas com login, acessos não autorizados e entre outras estruturas de dependem de uma ação, evento do usuário.
- **routes**, endereços das páginas.
- **themes**, definição do tema e de componentes de interface.