using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Model
{
    public class DoctorsPatient
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public User DUser { get; set; }
        public User PUser { get; set; }

    }
}
