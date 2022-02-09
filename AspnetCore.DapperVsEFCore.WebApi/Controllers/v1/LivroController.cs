using AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories;
using AspnetCore.DapperVsEFCore.Domain.Models;
using AspnetCoreApi.DapperVsEFCore.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AspnetCoreApi.DapperVsEFCore.WebApi.Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    public class LivroController : ControllerBase
    {
        private readonly ILogger<LivroController> _logger;

        public LivroController(ILogger<LivroController> logger)
        {
            _logger = logger;
        }

        [HttpGet("livros")]
        public IActionResult GetAll(
            [FromServices] ILivroDapperRepository repository)
        {
            var result = repository.GetAll();

            if (!result.Any()) return NoContent();

            return Ok(result);
        }

        [HttpPost("novo-livro")]
        public IActionResult AddLivro(
            [FromServices] ILivroDapperRepository repository,
            [FromBody] LivroPost livroPost)
        {
            var newBook = new Livro
            {
                Titulo = livroPost.Titulo,
                AnoPublicacao = livroPost.AnoPublicacao,
                AutorId = livroPost.AutorId,
            };
            repository.Insert(ref newBook);


            return Ok(new { data = newBook, message = "Saved!" });
        }


        [HttpDelete("remover")]
        public IActionResult Remove(
            [FromServices] ILivroDapperRepository repository, int livroId)
        {
            var autorRemove = repository.GetById(livroId);

            if (autorRemove == null) return NotFound();

            repository.Remove(autorRemove);

            return Ok("Removed!");
        }

    }


}
