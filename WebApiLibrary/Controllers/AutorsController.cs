using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLibrary.Entities;

namespace WebApiLibrary.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutorsController: ControllerBase
    {

        private readonly ApplicationDbContext context;
        public AutorsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult <List<Autor>>> Get()
        {
            return await context.Autors.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
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
            if (!exist) { 
                return NotFound("El usario no existe");
            }

            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }

}
