using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSA.Phase2.API.Models.Pokemon;
using MSA.Phase2.API.Data;

namespace MSA.Phase2.API.Controllers
{

    public class PokemonApiData
    {
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private readonly PokemonDbContext _context;
        private readonly IMapper _mapper;
        private readonly HttpClient _client;

        public PokemonsController(PokemonDbContext context, IMapper mapper, IHttpClientFactory clientFactory)
        {
            _context = context;
            _mapper = mapper;

            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("pokeApi");
        }

        // GET: api/Pokemons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SimplePokemonDto>>> GetPokemons()
        {
          if (_context.Pokemons == null)
          {
              return NotFound();
          }
            var pokemon = await _context.Pokemons.ToListAsync();
            var simplePokemon = _mapper.Map<List<SimplePokemonDto>>(pokemon);
            return simplePokemon;
        }

        // GET: api/Pokemons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonDto>> GetPokemon(int id)
        {
          if (_context.Pokemons == null)
          {
              return NotFound();
          }
            var result = await _context.Pokemons.Include(q => q.Trainer)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            var pokemon = _mapper.Map<PokemonDto>(result);

            return pokemon;
        }

        // PUT: api/Pokemons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPokemon(int id, CreatePokemonDto createPokemon)
        {
            if (createPokemon.CodexNumber < 1 || createPokemon.CodexNumber > 905)
            {
                return BadRequest("Codex Number must be between 1 and 905");
            }

            if (_context.Trainers.Find(createPokemon.TrainerId) == null)
            {
                return BadRequest("Must be a valid Trainer Id");
            }

            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }

            try
            {
                var res = await _client.GetAsync(createPokemon.CodexNumber.ToString());
                PokemonApiData content = await res.Content.ReadFromJsonAsync<PokemonApiData>();

                pokemon.CodexNumber = createPokemon.CodexNumber;
                pokemon.Name = content.Name;
                pokemon.Height = content.Height;
                pokemon.Weight = content.Weight;
                pokemon.TrainerId = createPokemon.TrainerId;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pokemons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SimplePokemonDto>> PostPokemon(CreatePokemonDto createPokemon)
        {
          if (_context.Pokemons == null)
          {
              return Problem("Entity set 'PokemonDbContext.Pokemons'  is null.");
          }

          if(createPokemon.CodexNumber<1 || createPokemon.CodexNumber > 905)
            {
                return BadRequest("Codex Number must be between 1 and 905");
            }
            if (_context.Trainers.Find(createPokemon.TrainerId) == null)
            {
                return BadRequest("Must be a valid Trainer Id");
            }

            try
            {
                var res = await _client.GetAsync(createPokemon.CodexNumber.ToString());
                PokemonApiData content = await res.Content.ReadFromJsonAsync<PokemonApiData>();
                var pokemon = new Pokemon
                {
                    CodexNumber = createPokemon.CodexNumber,
                    Name = content.Name,
                    Height = content.Height,
                    Weight = content.Weight,
                    TrainerId = createPokemon.TrainerId
                };

                _context.Pokemons.Add(pokemon);
                await _context.SaveChangesAsync();

                var simplePokemon = _mapper.Map<SimplePokemonDto>(pokemon);

                return CreatedAtAction("GetPokemon", new { id = simplePokemon.Id }, simplePokemon);
            } catch
            {
                throw;
            }
        }

        // DELETE: api/Pokemons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            if (_context.Pokemons == null)
            {
                return NotFound();
            }
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }

            _context.Pokemons.Remove(pokemon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PokemonExists(int id)
        {
            return (_context.Pokemons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
