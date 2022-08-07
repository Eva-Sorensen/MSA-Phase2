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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainer>().HasData(
                new Trainer
                {
                    Id = 1,
                    Name = "Ash"
                },
                new Trainer
                {
                    Id = 2,
                    Name = "Brock"
                },
                new Trainer
                {
                    Id = 3,
                    Name = "May"
                }
            );
            modelBuilder.Entity<Pokemon>().HasData(
                new Pokemon
                {
                    Id = 1,
                    CodexNumber = 25,
                    Name = "pikachu",
                    Height = 4,
                    Weight = 60,
                    TrainerId = 1
                },
                new Pokemon
                {
                    Id = 2,
                    CodexNumber = 205,
                    Name = "forretress",
                    Height = 12,
                    Weight = 1258,
                    TrainerId = 2
                },
                new Pokemon
                {
                    Id = 3,
                    CodexNumber = 255,
                    Name = "torchic",
                    Height = 4,
                    Weight = 25,
                    TrainerId = 3
                }
            );
        }
    }

}
