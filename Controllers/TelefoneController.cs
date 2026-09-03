using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Loja_e_commerce.Data;
using Loja_e_commerce.Models.Clientes;

namespace Loja_e_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TelefoneController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Telefone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefone>>> GetTelefone()
        {
          if (_context.Telefone == null)
          {
              return NotFound();
          }
            return await _context.Telefone.ToListAsync();
        }

        // GET: api/Telefone/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Telefone>> GetTelefone(int id)
        {
          if (_context.Telefone == null)
          {
              return NotFound();
          }
            var telefone = await _context.Telefone.FindAsync(id);

            if (telefone == null)
            {
                return NotFound();
            }

            return telefone;
        }

        // PUT: api/Telefone/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelefone(int id, Telefone telefone)
        {
            if (id != telefone.Cod_Telefone)
            {
                return BadRequest();
            }

            _context.Entry(telefone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefoneExists(id))
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

        // POST: api/Telefone
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Telefone>> PostTelefone(Telefone telefone)
        {
          if (_context.Telefone == null)
          {
              return Problem("Entity set 'AppDbContext.Telefone'  is null.");
          }
            _context.Telefone.Add(telefone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTelefone", new { id = telefone.Cod_Telefone }, telefone);
        }

        // DELETE: api/Telefone/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelefone(int id)
        {
            if (_context.Telefone == null)
            {
                return NotFound();
            }
            var telefone = await _context.Telefone.FindAsync(id);
            if (telefone == null)
            {
                return NotFound();
            }

            _context.Telefone.Remove(telefone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelefoneExists(int id)
        {
            return (_context.Telefone?.Any(e => e.Cod_Telefone == id)).GetValueOrDefault();
        }
    }
}
