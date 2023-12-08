using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.data;
public class AppDataContext: DbContext {
    public AppDataContext(DbContextOptions<AppDataContext>options): base(options) { }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Imc> Imcs { get; set; }
}