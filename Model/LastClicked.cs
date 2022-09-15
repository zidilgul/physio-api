namespace physio.Model
{
    public class LastClicked
    {
        public int Id { get; set; }
        public int PatientsMoveId { get; set; }
        public PatientsMove PatientsMove { get; set; }
    }
}
