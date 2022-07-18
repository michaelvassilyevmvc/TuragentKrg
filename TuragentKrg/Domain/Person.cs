using System;
using System.Collections.Generic;

namespace Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string IIN { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }
        public DateTime? DoB { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}