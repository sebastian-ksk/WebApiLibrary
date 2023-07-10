using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using WebApiLibrary.Validations;
namespace WebApiLibrary.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El Campo {0} es Requerido")]
        [StringLength(maximumLength:5, ErrorMessage = "El cmapo {0} no debe tener más de {1} caracteres")]
        //[FirstLetterUpperCase]
        [FirstLetterUpperCaseAtributte]
        public string? Name { get; set; }
        
        [Range(18,20)]
        [NotMapped] //No corresponde a una columna
        public int? Age { get; set; }

        [CreditCard]
        [NotMapped]
        public string? CreditCard { get; set; }
        [Url]
        [NotMapped]
        public string? Url { get; set; }
        public List<Book>? Books { get; set; }
    }
}
