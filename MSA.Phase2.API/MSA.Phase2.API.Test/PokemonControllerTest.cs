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

namespace MSA.Phase2.API.Test
{
    public class PokemonControllerTest : TestSetup
    {
        [SetUp]
        public void Setup()
        {
            SetupControllers();
        }

        [Test]
        public async Task GetAllPokemonsCorrectCountReturn()
        {
            var result = await _pokemonsController.GetPokemons();

            var value = result.Value;

            Assert.AreEqual(3, value.Count());
        }

        [Test]
        public async Task GetPokemonCorrectReturnValue()
        {
            var result = await _pokemonsController.GetPokemon(1);

            var value = result.Value;

            Assert.AreEqual(1, value.Id);
            Assert.AreEqual(25, value.CodexNumber);
            Assert.AreEqual("pikachu", value.Name);
            Assert.AreEqual(4, value.Height);
            Assert.AreEqual(60, value.Weight);
            Assert.AreEqual(1, value.TrainerId);
        }

        [Test]
        public async Task GetPokemonNotFoundValue()
        {
            var result = await _pokemonsController.GetPokemon(10);

            var value = result.Value;

            Assert.IsInstanceOf(typeof(NotFoundResult), result.Result);
        }

        [Test]
        public async Task PutPokemonCorrectReturnValue()
        {
            CreatePokemonDto pokemon = new CreatePokemonDto();
            pokemon.CodexNumber = 1;
            pokemon.TrainerId = 3;

            var res = await _pokemonsController.PutPokemon(3, pokemon);
            Assert.IsInstanceOf<NoContentResult>(res);

            var result = await _pokemonsController.GetPokemon(3);

            var value = result.Value;

            Assert.AreEqual(3, value.Id);
            Assert.AreEqual(1, value.CodexNumber);
            Assert.AreEqual("bulbasaur", value.Name);
            Assert.AreEqual(7, value.Height);
            Assert.AreEqual(69, value.Weight);
            Assert.AreEqual(3, value.TrainerId);

        }

        [Test]
        public async Task PutPokemonBadRequestCodexNumeberAboveValue()
        {
            CreatePokemonDto pokemon = new CreatePokemonDto();
            pokemon.CodexNumber = 1000;
            pokemon.TrainerId = 3;

            var res = await _pokemonsController.PutPokemon(3, pokemon);
            Assert.IsInstanceOf<BadRequestObjectResult>(res);
        }

        [Test]
        public async Task PutPokemonBadRequestCodexNumeberBelowValue()
        {
            CreatePokemonDto pokemon = new CreatePokemonDto();
            pokemon.CodexNumber = 0;
            pokemon.TrainerId = 3;

            var res = await _pokemonsController.PutPokemon(3, pokemon);
            Assert.IsInstanceOf<BadRequestObjectResult>(res);
        }

        [Test]
        public async Task PutPokemonBadRequestTrainerIdValue()
        {
            CreatePokemonDto pokemon = new CreatePokemonDto();
            pokemon.CodexNumber = 1;
            pokemon.TrainerId = 10;

            var res = await _pokemonsController.PutPokemon(3, pokemon);
            Assert.IsInstanceOf<BadRequestObjectResult>(res);
        }

        [Test]
        public async Task PutPokemonNotFoundValue()
        {
            CreatePokemonDto pokemon = new CreatePokemonDto();
            pokemon.CodexNumber = 1;
            pokemon.TrainerId = 3;

            var res = await _pokemonsController.PutPokemon(10, pokemon);
            Assert.IsInstanceOf<NotFoundResult>(res);
        }

        [Test]
        public async Task PostPokemonCorrectValue()
        {
            CreatePokemonDto pokemon = new CreatePokemonDto();
            pokemon.CodexNumber = 1;
            pokemon.TrainerId = 1;

            var res = await _pokemonsController.PostPokemon(pokemon);

            Assert.IsInstanceOf(typeof(CreatedAtActionResult), res.Result);

            var result = await _pokemonsController.GetPokemon(4);

            var value = result.Value;

            Assert.AreEqual(1, value.CodexNumber);
            Assert.AreEqual("bulbasaur", value.Name);
            Assert.AreEqual(7, value.Height);
            Assert.AreEqual(69, value.Weight);
            Assert.AreEqual(1, value.TrainerId);
        }

        [Test]
        public async Task PostPokemonBadRequestCodexNumeberAboveValue()
        {
            CreatePokemonDto pokemon = new CreatePokemonDto();
            pokemon.CodexNumber = 1000;
            pokemon.TrainerId = 3;

            var result = await _pokemonsController.PostPokemon(pokemon);

            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result.Result);
        }

        [Test]
        public async Task PostPokemonBadRequestCodexNumeberBelowValue()
        {
            CreatePokemonDto pokemon = new CreatePokemonDto();
            pokemon.CodexNumber = 0;
            pokemon.TrainerId = 3;

            var result = await _pokemonsController.PostPokemon(pokemon);

            Assert.IsInstanceOf(typeof(BadRequestObjectResult), result.Result);
        }

        [Test]
        public async Task DeletePokemonCorrectReturnValue()
        {
            var result = await _pokemonsController.DeletePokemon(3);
            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task DeletePokemonNotFoundValue()
        {
            var result = await _pokemonsController.DeletePokemon(10);
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

    }
}
