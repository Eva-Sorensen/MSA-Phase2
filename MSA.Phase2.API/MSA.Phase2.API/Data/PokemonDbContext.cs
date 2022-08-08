using Microsoft.EntityFrameworkCore;

namespace MSA.Phase2.API.Data
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }

    }

}
