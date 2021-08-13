Getting Started with .NET Core, Docker, and RabbitMQ

NET CORE WEB / Console RabbitMQ POC

Objetivo é inserir uma mensagem e consumir uma mesma.

Produtor e Consumidor de mensagens -> Producer e Consumer

STACK PARA FUNCIONAMENTO

Projeto c# -NET CORE WEB - NET CORE 2.2 LTS ErLang - RabbitMQ gerando mensagens  e Worker (Console) consumindo.

1º MODO)Instalar primeiro: http://www.erlang.org/download.html

Depois: https://www.rabbitmq.com/ Dentro do CMD do RABBITMQ correr o comando: rabbitmq-plugins enable rabbitmq_management

Usuário padrão, mas vc pode criar outro Usuário: convidado Senha: convidado

A seguir deve instalar o Pacote Nuget: RabbitMQ.Client, pode ser por linha de comando, ou não gerenciador de pacotes visual: Instalar-Pacote RabbitMQ.Client

O restante está dentro do projeto comentado.

2º MODO)  pode usar o DOCKER da seguinte maneira--> sem instalar o RABBITMQ

Pra isso deve ter instalado o Docker em sua máquina local

Dentro do Projeto publisher tem um arquivo : docker-compose.yml
Navegar ate ele no terminal do VS  e aplicar o comando: docker-compose up -d






