using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Model
{
    public class Move
    {
        public Move()
        {
            PatientMoves = new List<PatientsMove>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int BodyPartId { get; set; }
        public BodyPart BodyPart { get; set; }
        public IEnumerable<PatientsMove> PatientMoves { get; set; }

    }
}
