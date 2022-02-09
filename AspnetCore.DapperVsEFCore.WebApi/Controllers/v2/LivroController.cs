using AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories;
using AspnetCore.DapperVsEFCore.Domain.Models;
using AspnetCoreApi.DapperVsEFCore.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AspnetCoreApi.DapperVsEFCore.WebApi.Controllers.v2
{
    [ApiController]
    [Route("v2/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v2")]
    public class LivroController : ControllerBase
    {
        private readonly ILogger<LivroController> _logger;

        public LivroController(ILogger<LivroController> logger)
        {
            _logger = logger;
        }

        [HttpGet("livros")]
        public IActionResult GetAll(
            [FromServices] ILivroEFCoreRepository repository)
        {
            var result = repository.GetAll();

            if (!result.Any()) return NoContent();

            return Ok(result);
        }

        [HttpPost("novo-livro")]
        public IActionResult AddLivro(
            [FromServices] ILivroEFCoreRepository repository,
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
            [FromServices] ILivroEFCoreRepository repository, int livroId)
        {
            var autorRemove = repository.GetById(livroId);

            if (autorRemove == null) return NotFound();

            repository.Remove(autorRemove);

            return Ok("Removed!");
        }

    }


}
