using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Topic
    {
        [Required]
        public string Chapters = string.Empty;
    }
}
