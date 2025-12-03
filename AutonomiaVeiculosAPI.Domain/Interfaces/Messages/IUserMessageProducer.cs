using AutonomiaVeiculosAPI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Interfaces.Messages
{
    public interface IUserMessageProducer
    {
        Task Send(UserMessageVO userMessage);
    }
}
