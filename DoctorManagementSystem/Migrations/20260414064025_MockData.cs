using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class MockData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Doctors (Name, Specialization, Img) values ('Klara Dat', 'Cardiology', '');\r\ninsert into Doctors (Name, Specialization, Img) values ('Reagen Gianninotti', 'Neurology', '6.jpg');\r\ninsert into Doctors (Name, Specialization, Img) values ('Jermain Bewsey', 'Pediatrics', '4.jpg');\r\ninsert into Doctors (Name, Specialization, Img) values ('Dori Clair', 'Orthopedics', '2.jpg');\r\ninsert into Doctors (Name, Specialization, Img) values ('Pate Shoutt', 'Dermatology', '1.jpg');\r\ninsert into Doctors (Name, Specialization, Img) values ('Emmy Jolliffe', 'Oncology', '');\r\ninsert into Doctors (Name, Specialization, Img) values ('Ajay Pender', 'Cardiology', '2.jpg');\r\ninsert into Doctors (Name, Specialization, Img) values ('Field Mochan', 'Neurology', '2.jpg');");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Doctors");
        }
    }
}
