using MSA.Phase2.API.Models.Pokemon;

namespace MSA.Phase2.API.Models.Trainer
{
    public class TrainerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SimplePokemonDto> Pokemon { get; set; }
    }
}
