using ApiCrudFuncionario.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudFuncionario.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }


    }
}
