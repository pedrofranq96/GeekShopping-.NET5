# Documentação do Sistema "Geek Shopping"

O sistema "Geek Shopping" é um microserviço extenso desenvolvido com .NET 5 e é composto por várias camadas e tecnologias. Este sistema é destinado a fins de estudo e pode receber atualizações futuras. As principais tecnologias e camadas incluem OAuth2, OpenID, JWT, o framework Duende para construir um Identity Server, consumo de mensagens com RabbitMQ, API Gateway com Ocelot e documentação de API com Swashbuckle (Swagger).

## Requisitos Prévios

Antes de começar a instalar o sistema "Geek Shopping", certifique-se de que você possui os seguintes requisitos prévios em sua máquina:

- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) instalado.
- [Docker](https://www.docker.com/get-started) instalado (para executar RabbitMQ).
- Um ambiente de desenvolvimento .NET configurado.

## Instalação

Siga os passos abaixo para instalar e executar o sistema "Geek Shopping" em sua máquina:

### Passo 1: Clonar o Repositório

Clone o repositório do sistema "Geek Shopping" para o seu ambiente local:

```bash
git clone https://github.com/seu-usuario/geek-shopping.git
```

Substitua `seu-usuario` pelo seu nome de usuário no GitHub, caso necessário.

### Passo 2: Configurar o Identity Server

O Identity Server é uma parte fundamental do sistema. Certifique-se de configurá-lo corretamente seguindo as instruções fornecidas no projeto Duende IdentityServer. Você pode encontrar mais informações em [Duende IdentityServer](https://github.com/DuendeSoftware/IdentityServer).

### Passo 3: Configurar o RabbitMQ

O sistema utiliza o RabbitMQ para mensagens. Inicie um contêiner Docker do RabbitMQ com o seguinte comando:

```bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management
```

Isso iniciará um contêiner RabbitMQ com suporte ao painel de controle de gerenciamento.

### Passo 4: Configurar e Executar os Microserviços

Navegue até as pastas de cada microserviço no repositório clonado e siga as instruções individuais de configuração e execução para cada serviço. Por exemplo:

- `cd GeekShopping.ProductAPI`
- Siga as instruções no arquivo README específico deste serviço para configurar e executar.

Repita esse processo para todos os outros microserviços, como GeekShopping.PaymentAPI, GeekShopping.OrderAPI, GeekShopping.CouponAPI, etc.

### Passo 5: Configurar e Executar o API Gateway

O API Gateway é responsável por encaminhar as solicitações para os microserviços apropriados. Navegue até a pasta GeekShopping.GatewayAPI e siga as instruções no arquivo README específico deste serviço para configurar e executar.

### Passo 6: Documentação da API

A documentação da API é gerada automaticamente com o Swagger (Swashbuckle). Verifique a documentação da API para cada microserviço executando-o e acessando `http://localhost:<porta>/swagger` em seu navegador.

### Passo 7: Teste e Uso

Depois de configurar e executar todos os microserviços e o API Gateway, você pode começar a usar o sistema "Geek Shopping" acessando o API Gateway em `http://localhost:<porta-do-gateway>` em seu navegador ou usando ferramentas como [Postman](https://www.postman.com/) para interagir com as APIs.

## Arquitetura em Camadas

O sistema "Geek Shopping" segue uma arquitetura em camadas que inclui as seguintes camadas principais:

1. **Camada de Interface do Usuário (GeekShopping.Web)**: Esta camada lida com a apresentação e interação com o usuário e pode ser desenvolvida usando uma tecnologia de frontend como Angular, React ou Vue.js.

2. **Camadas de Microserviços**: O sistema é dividido em vários microserviços independentes, cada um com sua própria responsabilidade. Alguns exemplos de microserviços incluem:

   - GeekShopping.ProductAPI: Responsável pela gestão de produtos.
   - GeekShopping.PaymentAPI: Responsável pelo processamento de pagamentos.
   - GeekShopping.OrderAPI: Lida com a gestão de pedidos.
   - GeekShopping.CouponAPI: Gerencia cupons e descontos.
   - GeekShopping.CartAPI: Lida com operações de carrinho de compras.
   - GeekShopping.MessageBus: Lida com a comunicação assíncrona entre microserviços, muitas vezes usando tecnologias como RabbitMQ.
   - GeekShopping.IdentityServer: Fornecer serviços de autenticação e autorização, geralmente usando OAuth2 e OpenID.
   - GeekShopping.GatewayAPI: Um ponto de entrada único para acessar os serviços e redirecionar as solicitações para os microserviços apropriados.

3. **Camada de Comunicação (GeekShopping.MessageBus)**: Esta camada lida com a comunicação assíncrona entre os microserviços, muitas vezes usando tecnologias como RabbitMQ.

4. **Camada de Documentação (Swagger/Swashbuckle)**: A documentação da API é gerada automaticamente com o Swagger (Swashbuckle) para facilitar o entendimento e uso das APIs.

Lembre-se de que as tecnologias e estruturas específicas usadas em cada camada podem variar dependendo das necessidades do projeto e das preferências da equipe de desenvolvimento. Certifique-se de consultar a documentação e os READMEs individuais de cada microserviço para obter informações mais detalhadas sobre como configurar e executar cada parte do sistema.

Para qualquer dúvida ou problema específico relacionado a um microserviço em particular, consulte os READMEs individuais ou entre em contato com a equipe de desenvolvimento.
