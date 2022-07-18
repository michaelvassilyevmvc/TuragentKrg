using System;
using System.Collections.Generic;

namespace Domain
{
    public class Employee : Person
    {
        public ICollection<Career> Careers { get; set; }

    }
}