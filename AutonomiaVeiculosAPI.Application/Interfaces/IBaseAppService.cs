using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutonomiaVeiculosAPI.Application.Interfaces
{
    public interface IBaseAppService<TAddDto, TUpdateDto, TResponseDto>
    {
        TResponseDto Add(TAddDto dto);
        TResponseDto Update(int id, TUpdateDto dto);
        TResponseDto Delete(int id);
        TResponseDto Get(int id);
        IEnumerable<TResponseDto> GetAll();
    }
}
