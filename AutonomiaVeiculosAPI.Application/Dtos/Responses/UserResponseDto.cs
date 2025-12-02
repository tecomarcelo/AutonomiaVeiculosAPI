using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Dtos.Responses
{
    public class UserResponseDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
