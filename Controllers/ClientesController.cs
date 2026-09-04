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
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<IActionResult> GetCliente()
        {
            try
            {
                if (_context.Cliente == null)
                {
                    return NotFound(new { mensagem = "DbSet 'Cliente' não encontrado no DbContext." });
                }

                var clientes = await _context.Cliente.ToListAsync();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                // Captura o erro real do SQL/Entity Framework para não retornar HTML da IIS
                return StatusCode(500, new
                {
                    erro = "Erro interno ao buscar clientes.",
                    detalhe = ex.Message,
                    innerException = ex.InnerException?.Message
                });
            }
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            try
            {
                if (_context.Cliente == null)
                {
                    return NotFound();
                }

                var cliente = await _context.Cliente.FindAsync(id);

                if (cliente == null)
                {
                    return NotFound();
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }

        // POST: api/Clientes
        [HttpPost]
        public async Task<IActionResult> PostCliente(Cliente cliente)
        {
            try
            {
                if (_context.Cliente == null)
                {
                    return Problem("Entity set 'AppDbContext.Cliente' é nulo.");
                }

                _context.Cliente.Add(cliente);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCliente), new { id = cliente.Cod_cliente }, cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Erro ao cadastrar no banco de dados.", detalhe = ex.InnerException?.Message ?? ex.Message });
            }
        }

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Cod_cliente)
            {
                return BadRequest("O ID enviado na URL não coincide com o ID do corpo.");
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }

            return NoContent();
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if (_context.Cliente == null)
            {
                return NotFound();
            }
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return (_context.Cliente?.Any(e => e.Cod_cliente == id)).GetValueOrDefault();
        }
    }
}