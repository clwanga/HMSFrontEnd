using System.ComponentModel.DataAnnotations;

namespace InterviewFrontEnd.Models.Requests
{
    public class Requests
    {
        public class PatientRegRequest
        {
            [Required(ErrorMessage = "Please enter firstname")]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public string DOB { get; set; }
            [Required]
            public string Gender { get; set; }
        }

        public class VitalsRegRequest
        {
            public int PatientID { get; set; }
            public string Date { get; set; }
            public int Height { get; set; }
            public int Weight { get; set; }
            public int BMI { get; set; }
            public string General_Health { get; set; }
            public int OnDrugs { get; set; }
            public int OnDiet { get; set; }
            public string Comments { get; set; }
            public string Status { get; set; }
        }

    }
}
