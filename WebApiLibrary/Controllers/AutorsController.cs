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


    }

}
