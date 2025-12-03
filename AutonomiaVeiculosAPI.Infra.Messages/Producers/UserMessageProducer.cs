using AutonomiaVeiculosAPI.Domain.Interfaces.Messages;
using AutonomiaVeiculosAPI.Domain.ValueObjects;
using AutonomiaVeiculosAPI.Infra.Messages.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Infra.Messages.Producers
{
    public class UserMessageProducer : IUserMessageProducer
    {
        private readonly RabbitMQSettings? _rabbitMQSettings;

        public UserMessageProducer(IOptions<RabbitMQSettings?> rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings.Value;
        }

        public async Task Send(UserMessageVO userMessage)
        {
            // Conectar no servidor do RabbitMQ
            var connectionFactory = new ConnectionFactory() { Uri = new Uri(_rabbitMQSettings?.Url) };
                        
            await using (var connection = await connectionFactory.CreateConnectionAsync())
            {
                await using (var channel = await connection.CreateChannelAsync())
                {
                    // criando a fila
                    await channel.QueueDeclareAsync(
                        queue: _rabbitMQSettings.Queue,
                        durable: true, //não apaga as filas ao desligar ou reiniciar o broker
                        autoDelete: false, //apagar ou não a fila quando estiver vazia
                        exclusive: false, //fila exclusiva para aplicação
                        arguments: null
                    );

                    // gravando a mensagem na fila
                    await channel.BasicPublishAsync(
                        exchange: string.Empty,
                        routingKey: _rabbitMQSettings.Queue,
                        mandatory: false,                
                        body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(userMessage)));
                }
            }
        }
    }
}