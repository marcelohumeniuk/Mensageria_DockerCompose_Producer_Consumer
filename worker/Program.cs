using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace worker
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Console.WriteLine("Sleeping to wait for Rabbit");
            Task.Delay(500).Wait();
        
            Console.WriteLine("Pronto pra receber mensagens agora!");
            
            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost", Port = 5672 };
            factory.UserName = "guest";
            factory.Password = "guest";
            IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();
            channel.QueueDeclare(queue: "FILA_TESTE",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Recebendo do Rabbit: {0}", message);
                Console.WriteLine("-----------------------------------");
               
            };
            channel.BasicConsume(queue: "FILA_TESTE",
                                    autoAck: true,
                                    consumer: consumer);
        }
    }
}
