using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Dtos
{
    public class NewPatientDto
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int DoctorId { get; set; }

    }
}
