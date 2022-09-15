using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Model
{
    public class BodyPart
    {
        public BodyPart()
        {
            Moves = new List<Move>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Move> Moves { get; set; }

    }
}
