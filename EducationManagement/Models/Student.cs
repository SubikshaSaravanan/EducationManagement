using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationManagement.Models
{
    public class Student
    {
        // Models/Student.cs
        [Key]
            public int Id { get; set; }
        [Required]

            public string Name { get; set; }
            public int Age { get; set; }

        [ForeignKey("ClassId")]
            public int ClassId { get; set; }
            public Classes Class { get; set; }
        }

        // Models/Class.cs
       
    }

