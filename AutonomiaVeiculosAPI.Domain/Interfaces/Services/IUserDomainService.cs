using AutonomiaVeiculosAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Domain.Interfaces.Services
{
    public interface IUserDomainService : IDisposable
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        User? Get(Guid id);
        User? Get(string email);
        User? Get(string email, string password);
        IEnumerable<User> GetAll();
        string Authenticate(string email, string password);
    }
}
