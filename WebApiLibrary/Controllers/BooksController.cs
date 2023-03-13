using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiLibrary.Entities;

namespace WebApiLibrary.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        public BooksController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
            return await context.Books.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var book= await context.Books.Include(x=>x.Author).FirstOrDefaultAsync(x => x.Id == id);

            if (book == null)
            {
                return NotFound("libro no encontrado");
            }


            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Book book)
        {
           

            var authorExist = await context.Autors.AnyAsync(author => author.Id == book.AuthorId);
            if (!authorExist) {
                return BadRequest("El autor no existe");
            }

            var author = await context.Autors.FirstOrDefaultAsync(x => x.Id == book.AuthorId);

    

            context.Add(book);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(Book book, int id)
        {
            if (book.Id != id)
            {
                return BadRequest("el id no coincide");
            }

            context.Update(book);
            await context.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Books.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("El libro no existe");
            }

            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }


    }
}
