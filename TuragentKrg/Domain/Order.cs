using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public Tour Tour { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Client> Clients { get; set; }
        public Status Status { get; set; }

    }
}