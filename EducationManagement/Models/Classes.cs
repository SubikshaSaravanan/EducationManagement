using System.ComponentModel.DataAnnotations;

namespace EducationManagement.Models
{
    public class Classes
    {

        [Key]
            public int ClassId { get; set; }
            public string ClassName { get; set; }
            public ICollection<Student> Students { get; set; }
        }

    }

