namespace Kurs.DTO
{
    public class StudentForUpdateDto
    {
             public string FirstName { get; set; }

            public string LastName { get; set; }

            public string MiddleName { get; set; }

            public DateTime DateOfBirth { get; set; }

            public string Address { get; set; }

            public string Phone { get; set; }

            public string Email { get; set; }

            public int GroupID { get; set; }
           
       // public Kurs.Models.Group Group { get; set; }
    }
}
