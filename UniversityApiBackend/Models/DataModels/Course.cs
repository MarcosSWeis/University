using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Course:BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }=string.Empty;


        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required, StringLength(2000)]
        public string LongDescription { get; set; } = string.Empty;

        [Required]
        public string PublicTarget { get; set; } = string.Empty;

        [Required]
        public string Targets { get; set; } = string.Empty;

        [Required]
        public string Requirements { get; set; }= string.Empty;

        [Required]
        public int Nivel { get; set; } = (int) ENivel.Basic;
    }
}

public enum ENivel
{
    Basic = 0,
    Medium,
    Advanced
}