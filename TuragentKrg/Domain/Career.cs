using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Career
    {
        public int Id { get; set; }
        public DateTime StartCareer { get; set; }
        public DateTime? FinishCareer { get; set; }
    }
}