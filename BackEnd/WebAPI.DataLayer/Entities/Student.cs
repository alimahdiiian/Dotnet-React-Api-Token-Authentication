using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Student
    {
      
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(16)")]
        public int Mobile  { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; } = string.Empty;
    }
}
