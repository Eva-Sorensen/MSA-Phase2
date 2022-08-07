using MSA.Phase2.API.Models.Trainer;

namespace MSA.Phase2.API.Models.Pokemon
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public int CodexNumber { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int TrainerId { get; set; }
        public SimpleTrainerDto Trainer { get; set; }
    }
}
