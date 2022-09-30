using System.ComponentModel.DataAnnotations;//Proporciona clases de atributos que se usan para definir los metadatos para ASP.NET MVC y los controles de ASP.NET.

namespace UniversityApiBackend.Models.DataModels
{
    //calse base de la db 
    //aca van a esatr las columnas que va a ser iguales para todas la tablas
    public class BaseEntity
    {
        //digo que el campo id no es nulleable y el primaryKey
        [Required]
        [Key]
        public int Id { get; set; }
        //como CreatedBy no acepta null lo inicializo con un string vacio (String.Empty) , podria haber puesto string? CreatedBy para que acepte null tambien

        //toda propieda que no tenga [Required] quiere decir que puede o no estar
        public string CreatedBy { get; set; }= string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public bool isDeleted { get; set; } = false;
 

    }
}
