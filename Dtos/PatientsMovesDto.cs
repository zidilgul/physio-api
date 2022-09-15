using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Dtos
{
    public class PatientsMovesDto
    {
        public int Id { get; set; }
        public int MoveId { get; set; }
        public string Move { get; set; }
        public bool State { get; set; }
        public int NumberOfRepetitons { get; set; }
        public int NumberOfSets { get; set; }
        public string BodyPart { get; set; }
    }
}
