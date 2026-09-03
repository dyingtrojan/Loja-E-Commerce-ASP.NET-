using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Loja_e_commerce.Data;
using Loja_e_commerce.Models;

namespace Loja_e_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoquesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstoquesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Estoques
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estoque>>> GetEstoque()
        {
          if (_context.Estoque == null)
          {
              return NotFound();
          }
            return await _context.Estoque.ToListAsync();
        }

        // GET: api/Estoques/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estoque>> GetEstoque(int id)
        {
          if (_context.Estoque == null)
          {
              return NotFound();
          }
            var estoque = await _context.Estoque.FindAsync(id);

            if (estoque == null)
            {
                return NotFound();
            }

            return estoque;
        }

        // PUT: api/Estoques/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstoque(int id, Estoque estoque)
        {
            if (id != estoque.Cod_Estoque)
            {
                return BadRequest();
            }

            _context.Entry(estoque).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstoqueExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Estoques
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estoque>> PostEstoque(Estoque estoque)
        {
          if (_context.Estoque == null)
          {
              return Problem("Entity set 'AppDbContext.Estoque'  is null.");
          }
            _context.Estoque.Add(estoque);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstoque", new { id = estoque.Cod_Estoque }, estoque);
        }

        // DELETE: api/Estoques/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstoque(int id)
        {
            if (_context.Estoque == null)
            {
                return NotFound();
            }
            var estoque = await _context.Estoque.FindAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }

            _context.Estoque.Remove(estoque);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstoqueExists(int id)
        {
            return (_context.Estoque?.Any(e => e.Cod_Estoque == id)).GetValueOrDefault();
        }
    }
}
