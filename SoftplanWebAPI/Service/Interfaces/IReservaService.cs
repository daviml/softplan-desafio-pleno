using Microsoft.EntityFrameworkCore;
using SoftplanWebAPI.Entities;
using System.Collections.Generic;

namespace SoftplanWebAPI.Service.Interfaces
{
    public interface IReservaService
    {
        List<ReservaEntity> BuscaReserva();
    }
}
