namespace MSA.Phase2.API.Data
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IList<Pokemon> Pokemon { get; set; }
    }
}
