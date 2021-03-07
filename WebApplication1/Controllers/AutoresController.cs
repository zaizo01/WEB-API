using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.Autores.Include(x => x.Libros).ToList();
        }

        [HttpGet("First")]
        public ActionResult<Autor> GetFirstAutor()
        {
            return context.Autores.FirstOrDefault();
        }

        [HttpGet("{id}", Name = "GetAutor")]
        public ActionResult<Autor> Get(int id)
        {
            var autor = context.Autores.Include(x => x.Libros).FirstOrDefault(x => x.id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            context.Autores.Add(autor);
            context.SaveChanges();
            return new CreatedAtRouteResult("GetAutor", new { id = autor.id }, autor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor value)
        {
            if (id != value.id)
            {
                return BadRequest();
            }

            context.Entry(value).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id) 
        {
            var autor = context.Autores.FirstOrDefault(x => x.id == id);

            if (autor == null)
            {
                return NotFound();
            }

            context.Autores.Remove(autor);
            context.SaveChanges();
            return autor;
        }
    }
}
