using System.Collections.Generic;

namespace Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BIN { get; set; }
        public string Address { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public int State { get; set; }

    }
}