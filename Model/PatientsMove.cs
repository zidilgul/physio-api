using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Model
{
    public class PatientsMove
    {
        public PatientsMove()
        {
            LastClickeds = new List<LastClicked>();
        }
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MoveId { get; set; }
        public bool State { get; set; }
        public int NumberOfRepetitons { get; set; }
        public int NumberOfSets { get; set; }
        public User User { get; set; }
        public Move Move { get; set; }
        public IEnumerable<LastClicked> LastClickeds { get; set; }

    }
}
