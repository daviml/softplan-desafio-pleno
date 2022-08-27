using Microsoft.EntityFrameworkCore;
using SoftplanWebAPI.Data;
using SoftplanWebAPI.Entities;
using SoftplanWebAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftplanWebAPI.Service
{
    public class SalaService : Service, ISalaService
    {
        private readonly DataContext _context;
        public SalaService(DataContext context)
        {
            _context = context;
        }

        public List<SalaEntity> BuscaSala()
        {

            var salaEntity = _context.Salas.ToList();

            return salaEntity;
        }

    }
}
