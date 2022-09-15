using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace physio.Model
{
    public class User
    {
        public User()
        {
            Patient = new List<DoctorsPatient>();
            Doctor = new List<DoctorsPatient>();
            PatientMoves = new List<PatientsMove>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public bool IsDoctor { get; set; }
        public IEnumerable<DoctorsPatient> Doctor { get; set; }
        public IEnumerable<DoctorsPatient> Patient { get; set; }
        public IEnumerable<PatientsMove> PatientMoves { get; set; }


    }
}
