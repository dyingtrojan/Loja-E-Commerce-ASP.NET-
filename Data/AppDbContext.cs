using Microsoft.EntityFrameworkCore;
using Loja_e_commerce.Models;
using Loja_e_commerce.Models.Clientes;

namespace Loja_e_commerce.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Loja_e_commerce.Models.Produto> Produto { get; set; } = default!;
        public DbSet<Loja_e_commerce.Models.Compra> Compra { get; set; } = default!;
        public DbSet<Loja_e_commerce.Models.Estoque> Estoque { get; set; } = default!;
        public DbSet<Loja_e_commerce.Models.Funcionario> Funcionario { get; set; } = default!;
        public DbSet<Loja_e_commerce.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<Loja_e_commerce.Models.Clientes.Email> Email { get; set; } = default!;
        public DbSet<Loja_e_commerce.Models.Clientes.Telefone> Telefone { get; set; } = default!;
    }
}