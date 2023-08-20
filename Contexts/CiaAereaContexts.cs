using CiaAerea.Entities;
using CiaAerea.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CiaAerea.Contexts;

public class CiaAereaContexts: DbContext
{ 

    const string CIA_AEREA = "CiaAerea";

    private readonly IConfiguration _configuration;

    public CiaAereaContexts(IConfiguration configuration)
    {
        _configuration = configuration;
    }    

    public DbSet<Aeronave> Aeronaves => Set<Aeronave>();
    public DbSet<Piloto> Pilotos => Set<Piloto>();
    public DbSet<Voo> Voos => Set<Voo>();
    public DbSet<Cancelamento> Cancelamentos => Set<Cancelamento>();
    public DbSet<Manutencao> Manutencoes => Set<Manutencao>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString(CIA_AEREA))
            .EnableSensitiveDataLogging()
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AeronaveConfiguration());
        modelBuilder.ApplyConfiguration(new PilotoConfiguration());
        modelBuilder.ApplyConfiguration(new VooConfiguration());
        modelBuilder.ApplyConfiguration(new CancelamentoConfiguration());
        modelBuilder.ApplyConfiguration(new ManutencaoConfiguration());
    }
}