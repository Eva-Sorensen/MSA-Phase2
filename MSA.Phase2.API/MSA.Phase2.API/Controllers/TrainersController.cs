using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSA.Phase2.API.Data;
using MSA.Phase2.API.Models.Trainer;
using AutoMapper;


namespace MSA.Phase2.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly PokemonDbContext _context;
        private readonly IMapper _mapper;

        public TrainersController(PokemonDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }

        // GET: api/Trainers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SimpleTrainerDto>>> GetTrainers()
        {
          if (_context.Trainers == null)
          {
              return NotFound();
          }

            var trainers = await _context.Trainers.ToListAsync();
            var simpleTrainers = _mapper.Map<List<SimpleTrainerDto>>(trainers);
            return simpleTrainers;
        }

        // GET: api/Trainers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainerDto>> GetTrainer(int id)
        {
          if (_context.Trainers == null)
          {
              return NotFound();
          }
            var result = await _context.Trainers.Include(q => q.Pokemon)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            var trainer = _mapper.Map<TrainerDto>(result);

            return trainer;
        }

        // PUT: api/Trainers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainer(int id, SimpleTrainerDto simpleTrainer)
        {
            if (id != simpleTrainer.Id)
            {
                return BadRequest();
            }

            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            trainer.Name = simpleTrainer.Name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerExists(id))
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

        // POST: api/Trainers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SimpleTrainerDto>> PostTrainer(CreateTrainerDto createTrainer)
        {
          if (_context.Trainers == null)
          {
              return Problem("Entity set 'PokemonDbContext.Trainers'  is null.");
          }

            var trainer = _mapper.Map<Trainer>(createTrainer);
            _context.Trainers.Add(trainer);
            await _context.SaveChangesAsync();
            var simpleTrainer = _mapper.Map<SimpleTrainerDto>(trainer);

            return CreatedAtAction("GetTrainer", new { id = simpleTrainer.Id }, simpleTrainer);
        }

        // DELETE: api/Trainers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            if (_context.Trainers == null)
            {
                return NotFound();
            }
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            _context.Trainers.Remove(trainer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainerExists(int id)
        {
            return (_context.Trainers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
