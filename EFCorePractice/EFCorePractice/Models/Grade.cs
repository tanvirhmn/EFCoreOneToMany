using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePractice.Models
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }

        [StringLength(2)]
        [Required]
        [Column(TypeName = "varchar(2)")]
        public string GradeName { get; set; } = String.Empty;

        [StringLength(20)]
        [Required]
        [Column("GradeSection", TypeName = "nvarchar(20)")]
        public string Section { get; set; } = String.Empty;

        public ICollection<Student>? Students { get; set; }
    }
}
