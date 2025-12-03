using AutonomiaVeiculosAPI.Domain.ValueObjects;
using AutonomiaVeiculosAPI.Infra.Messages.Services;
using AutonomiaVeiculosAPI.Infra.Messages.Settings;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace AutonomiaVeiculosAPI.Infra.Messages.Consumers
{
    public class UserMessageConsumer : BackgroundService
    {
        private readonly RabbitMQSettings? _rabbitMQSettings;
        private readonly EmailMessageService? _emailMessageService;

        public UserMessageConsumer(IOptions<RabbitMQSettings?> rabbitMQSettings, EmailMessageService emailMessageService)
        {
            _rabbitMQSettings = rabbitMQSettings.Value;
            _emailMessageService = emailMessageService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { Uri = new Uri(_rabbitMQSettings.Url) };
            var connection = await factory.CreateConnectionAsync();
            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(_rabbitMQSettings.Queue, durable: true, exclusive: false, autoDelete: false);

            //objeto utilizado para ler e processar a fila
            var consumer = new AsyncEventingBasicConsumer(channel);

            //criando o mecanismo para ler cada item da fila
            consumer.ReceivedAsync += async (sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var userMessageVO = JsonConvert.DeserializeObject<UserMessageVO>(message);

                if (userMessageVO != null)
                {
                    await _emailMessageService.SendEmailAsync(userMessageVO);
                }

                //removendo o item da fila
                await channel.BasicAckAsync(args.DeliveryTag, false);
            };

            //executando a leitura da fila
            await channel.BasicConsumeAsync(_rabbitMQSettings.Queue, autoAck: false, consumer);

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
    }
}
