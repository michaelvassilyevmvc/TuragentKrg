using System;

namespace Domain
{
    public class Checkpoint
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string StartPlace { get; set; }
        public string FinishPlace { get; set; }
        public string Place { get; set; }
        public Status Status { get; set; }
    }
}