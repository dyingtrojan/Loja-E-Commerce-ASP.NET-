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
    public class EmailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmailController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Email
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetEmail()
        {
          if (_context.Email == null)
          {
              return NotFound();
          }
            return await _context.Email.ToListAsync();
        }

        // GET: api/Email/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Email>> GetEmail(int id)
        {
          if (_context.Email == null)
          {
              return NotFound();
          }
            var email = await _context.Email.FindAsync(id);

            if (email == null)
            {
                return NotFound();
            }

            return email;
        }

        // PUT: api/Email/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmail(int id, Email email)
        {
            if (id != email.Cod_Email)
            {
                return BadRequest();
            }

            _context.Entry(email).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
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

        // POST: api/Email
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Email>> PostEmail(Email email)
        {
          if (_context.Email == null)
          {
              return Problem("Entity set 'AppDbContext.Email'  is null.");
          }
            _context.Email.Add(email);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmail", new { id = email.Cod_Email }, email);
        }

        // DELETE: api/Email/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmail(int id)
        {
            if (_context.Email == null)
            {
                return NotFound();
            }
            var email = await _context.Email.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }

            _context.Email.Remove(email);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmailExists(int id)
        {
            return (_context.Email?.Any(e => e.Cod_Email == id)).GetValueOrDefault();
        }
    }
}
