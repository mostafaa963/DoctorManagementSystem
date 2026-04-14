namespace DoctorManagementSystem.Models
{
    public class BookAppointment
    {
        public int Id  { get; set; }
        public string  Name { get; set; }
        public DateTime DateBook { get; set; }
        public TimeOnly TimeBook { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctors { get; set; }
    }
}
