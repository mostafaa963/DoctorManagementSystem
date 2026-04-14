namespace DoctorManagementSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Specialization { get; set; }
        public string  Img { get; set; }
        public List<BookAppointment>  Books { get; set; }

    }
}
