using System.ComponentModel.DataAnnotations.Schema;

namespace MSA.Phase2.API.Data
{
    public class Pokemon
    {
        public int Id { get; set; }
        public int CodexNumber { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        [ForeignKey(nameof(TrainerId))]
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

    }
}
