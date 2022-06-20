using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePractice.Models
{
    public class Student
    {
        public int Id { get; set; }

        [StringLength(200)]
        [Required]
        [Column("StudentName", TypeName = "nvarchar(200)")]
        public string Name { get; set; } = String.Empty;

        public int CurrentGradeId { get; set; }
        public Grade? Grade { get; set; } 
    }
}
