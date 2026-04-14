namespace DoctorManagementSystem
{
    public class ViewModel
    {
        public Doctor Doctors { get; set; }
        public IEnumerable<BookAppointment> bookAppointments { get; set; }
    }
}
