using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MSA.Phase2.API.Data;
using AutoMapper;
using MSA.Phase2.API.Controllers;
using MSA.Phase2.API.Configurations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MSA.Phase2.API.Models.Pokemon;
using Moq;

namespace MSA.Phase2.API.Test
{
    public class TestSetup
    {
        protected PokemonsController _pokemonsController;
        protected TrainersController _trainersController;
        protected void SetupControllers()
        {
            var options = new DbContextOptionsBuilder<PokemonDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var context = new PokemonDbContext(options);

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MapperConfig());
            });
            var mapper = config.CreateMapper();

            var mockHttpClient = new HttpClient();
            mockHttpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");

            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(mockHttpClient);

            CreateData(context);

            _trainersController = new TrainersController(context, mapper);
            _pokemonsController = new PokemonsController(context, mapper, mockHttpClientFactory.Object);
        }

        private void CreateData(PokemonDbContext context)
        {
            var trainers = new[]
            {
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
        };

            var pokemon = new[]
            {
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
        };
            context.Trainers.AddRange(trainers);
            context.Pokemons.AddRange(pokemon);
            context.SaveChanges();
        }
    }
}
