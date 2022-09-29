using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class User : BaseEntity
    {
        [Required, StringLength(30)]//campo obligatorio y longitud menor a 30 caracteres
        public string Name { get; set; } = string.Empty;//en caso que no venga lo pengo un string vacio (string.Empty)

        [Required, StringLength(50)]//campo obligatorio y longitud menor a 50 caracteres
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress] //es requeirdo y tambien a travez de exprexiones regulares verifica que sea un email valido
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

    }
   
}
