using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Teste.Domain.Models;

namespace Teste.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UsuarioViewModel> Usuario { get; set; }

        public DbSet<HistoricoLogin> HistoricoLogins { get; set; }

    }
}