using Microsoft.EntityFrameworkCore;
using SoftplanWebAPI.Data;
using SoftplanWebAPI.Entities;
using SoftplanWebAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftplanWebAPI.Service
{
    public class ReservaService : Service, IReservaService
    {
        private readonly DataContext _context;
        public ReservaService(DataContext context)
        {
            _context = context;
        }

        public List<ReservaEntity> BuscaReserva()
        {

            var reservaEntity = _context.Reservas.ToList();

            return reservaEntity;
        }

    }
}
