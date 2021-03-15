using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Autor
    {
      public int id { get; set; }
      [Required]
      [StringLength(20, MinimumLength = 5, ErrorMessage ="El nombre debe de tener {1} caracteres o menos")]
      public string Nombre { get; set; }
      public List<Libro> Libros { get; set; }
        [Range(18, 120, ErrorMessage = "Solo se permite de 18-120 anos de edad")]
        public int edad { get; set; }
        [CreditCard]
        public string creditCard { get; set; }
        [Url]
        public Uri url { get; set; }
    }
}
