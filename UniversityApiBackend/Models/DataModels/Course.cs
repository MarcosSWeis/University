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

        //que alumonos esta en este curso
        [Required]
        public ICollection<Student> Courses { get; set; } = new List<Student>();
        
        [Required]
        public Topic Topic { get; set; } = new Topic(); 


    }
}

public enum ENivel
{
    Basic = 0,
    Medium,
    Advanced
}