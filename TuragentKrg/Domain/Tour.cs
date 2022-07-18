using System.Collections.Generic;

namespace Domain
{
    public class Tour
    {
        public int Id { get; set; }
        public ICollection<Checkpoint> Checkpoints { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }

    }
}