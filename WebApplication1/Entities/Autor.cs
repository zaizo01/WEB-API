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
      public string Nombre { get; set; }
      public List<Libro> Libros { get; set; }
    }
}
