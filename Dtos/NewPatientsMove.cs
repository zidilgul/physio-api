using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Dtos
{
    public class NewPatientsMove
    {
        public int PatientId { get; set; }
        public int MoveId { get; set; }
        public int NumberOfRepetitons { get; set; }
        public int NumberOfSets { get; set; }
    }
}
