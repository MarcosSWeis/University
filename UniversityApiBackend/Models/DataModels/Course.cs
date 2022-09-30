using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Course:BaseEntity
    {
   
        [Required, StringLength(50)]
        public string Name { get; set; }=string.Empty;


        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required, StringLength(2000)]
        public string LongDescription { get; set; } = string.Empty;   

        [Required]
        public int Nivel { get; set; } = (int) ENivel.Basic;

        //un curso puede tener muchas categorias, aca hago al relacion
        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        [Required]
        public Chapter Chapter { get; set; } = new Chapter();

        //que alumonos esta en este curso
        [Required]
        public ICollection<Student> Courses { get; set; } = new List<Student>();

        


    }
}

public enum ENivel
{
    Basic = 0,
    Medium,
    Advanced
}