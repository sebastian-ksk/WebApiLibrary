using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLibrary.Entities;

namespace WebApiLibrary.Controllers
{
    [ApiController]
    [Route("api/autores")] //Ruta de controlador
    public class AutorsController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        public AutorsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [HttpGet("list")] //doble ruta
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await context.Autors.Include(x=>x.Books).ToListAsync();
        }

        [HttpGet("first")] //concatena first
        public async Task<ActionResult<Autor>> GetFirst([FromQuery] string dataValidate)
        {
            var author= await context.Autors.Include(x => x.Books).FirstOrDefaultAsync();
            if (author== null)
            {
                return BadRequest();
            }
            return Ok(author);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var author = await context.Autors.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == id);

            if (author == null)
            {
                return NotFound("libro no encontrado");
            }


            return Ok(author);
        }


        [HttpGet("{name:string}/{lastname?}")]
        public async Task<ActionResult<Book>> GetByName(string name, string lastname)
        {
            var author = await context.Autors.Include(x => x.Books).FirstOrDefaultAsync(predicate: x => x.Name.Contains(name));

            if (author == null )
            {
                return NotFound("Author no encontrado");
            }
           


            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("el id no coincide");
            }

            context.Update(autor);
            await context.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Autors.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El usario no existe");
            }

            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }

}
