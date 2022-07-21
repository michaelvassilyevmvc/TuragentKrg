using System.Collections.Generic;

namespace Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BIN { get; set; }
        public string Address { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public int State { get; set; }

    }
}