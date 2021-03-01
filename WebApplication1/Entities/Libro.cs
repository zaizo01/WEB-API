using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        [Required]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}
