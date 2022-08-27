using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using SoftplanWebAPI.Data;
using SoftplanWebAPI.Entities;
using SoftplanWebAPI.Service;
using SoftplanWebAPI.Service.Interfaces;

namespace SoftplanWebAPI.API.Controllers
{
    public class ReservaController : Controller
    {
        private readonly DataContext _context;

        public ReservaController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca sala
        /// </summary>
        /// <returns>custom</returns>
        [HttpGet("busca-salas")]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(SalaEntity))]
        public IActionResult BuscaSalas()
        {
            var sala = _context.Salas;

            return Ok(sala);
        }

        /// <summary>
        /// Busca reservas
        /// </summary>
        /// <returns>custom</returns>
        [HttpGet("busca-reservas")]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(ReservaEntity))]
        public IActionResult BuscaReservas()
        {
            var reservas = _context.Reservas;

            return Ok(reservas);
        }

        /// <summary>
        /// Insere contato
        /// </summary>
        /// <returns></returns>
        [HttpPost("insere-reserva")]
        [ProducesResponseType(200, Type = typeof(ReservaEntity))]
        public IActionResult InsereReserva([FromBody] ReservaEntity reserva)
        {
            var ret = 0;

            var reservas = _context.Reservas.Where(x => x.Sala == reserva.Sala).ToList();

            foreach (var reservaE in reservas)
            {
                if (reserva.DataInicio > reservaE.DataInicio && reserva.DataInicio < reservaE.DataFim)
                {
                    ret = 409;
                }
                else if (reserva.DataFim > reservaE.DataInicio && reserva.DataFim < reservaE.DataFim)
                {
                    ret = 409;
                }
                else if (reserva.DataFim > reservaE.DataFim && reserva.DataInicio < reservaE.DataInicio)
                {
                    ret = 409;
                }
                else if (reserva.DataFim < reservaE.DataFim && reserva.DataInicio > reservaE.DataInicio)
                {
                    ret = 409;
                }
            }

            if(reserva.DataInicio > reserva.DataFim)
            {
                ret = 409;
            }

            if(ret == 409)
            {
                return StatusCode(409);
            }
            else
            {
                _context.Add(reserva);
                _context.SaveChanges();
                return StatusCode(200);
            }
        }


        // GET: Reserva/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaEntity = await _context.Salas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salaEntity == null)
            {
                return NotFound();
            }

            return View(salaEntity);
        }

        // GET: Reserva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Disponivel")] SalaEntity salaEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salaEntity);
        }

        // GET: Reserva/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaEntity = await _context.Salas.FindAsync(id);
            if (salaEntity == null)
            {
                return NotFound();
            }
            return View(salaEntity);
        }

        // POST: Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,Descricao,Disponivel")] SalaEntity salaEntity)
        {
            if (id != salaEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salaEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaEntityExists(salaEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(salaEntity);
        }

        // GET: Reserva/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaEntity = await _context.Salas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salaEntity == null)
            {
                return NotFound();
            }

            return View(salaEntity);
        }

        // POST: Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var salaEntity = await _context.Salas.FindAsync(id);
            _context.Salas.Remove(salaEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaEntityExists(long id)
        {
            return _context.Salas.Any(e => e.Id == id);
        }
    }
}
