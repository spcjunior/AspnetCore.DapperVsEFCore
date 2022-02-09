using AspnetCore.DapperVsEFCore.Domain.Interfaces.Repositories;
using AspnetCore.DapperVsEFCore.Domain.Models;
using AspnetCore.DapperVsEFCore.WebApi.Extensions;
using AspnetCoreApi.DapperVsEFCore.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AspnetCoreApi.DapperVsEFCore.WebApi.Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false, GroupName = "v1")]
    public class AutorController : ControllerBase
    {

        private readonly ILogger<AutorController> _logger;

        public AutorController(ILogger<AutorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("autores")]
        public IActionResult GetAll(
            [FromServices] IAutorDapperRepository repository)
        {
            var result = WatchTime.Start(() => repository.GetAll(), _logger);

            if (!result.Any()) return NoContent();

            return Ok(result);
        }

        [HttpPost("novo-autor")]
        public IActionResult Add(
            [FromServices] IAutorDapperRepository repository,
            [FromBody] AutorPost autorPost)
        {
            var newAuthor = new Autor
            {
                Nome = autorPost.Nome,
                Telefone = autorPost.Telefone,
                Endereco = autorPost.Endereco,
                Pais = autorPost.Pais
            };

            repository.Insert(ref newAuthor);

            return Ok(new { data = newAuthor, message = "Saved!" });
        }


        [HttpPost("novos-autores-fake")]
        public IActionResult AddAutoresFake(
            [FromServices] IAutorDapperRepository repository, int quantidade)
        {
            if (quantidade > 1000) return BadRequest("Valor máximo é 100");

            var autores = new List<Autor>();
            for (int i = 0; i < quantidade; i++)
            {
                autores.Add(
                    new Autor
                    {
                        Nome = Faker.Name.FullName(),
                        Endereco = Faker.Address.StreetAddress(),
                        Telefone = Faker.Phone.Number(),
                        Pais = Faker.Country.Name(),
                    });
            }

            repository.InsertAll(autores);

            return Ok("Saved!");
        }

        [HttpPost("novos-autores-fake-com-livros")]
        public IActionResult AddAutoresFakeComLivros(
           [FromServices] IAutorDapperRepository repository,
           [FromServices] ILivroDapperRepository repositoryLivro, int quantidade)
        {
            if (quantidade > 1000) return BadRequest("Valor máximo é 1000");

            for (int i = 0; i < quantidade; i++)
            {
                var autor = new Autor
                {
                    Nome = Faker.Name.FullName(),
                    Endereco = Faker.Address.StreetAddress(),
                    Telefone = Faker.Phone.Number(),
                    Pais = Faker.Country.Name(),
                };

                repository.Insert(ref autor);

                var livros = new List<Livro>()
                {
                    new Livro { Titulo = Faker.Name.Prefix(), AnoPublicacao = Faker.RandomNumber.Next(), AutorId = autor.Id },
                    new Livro { Titulo = Faker.Name.Prefix(), AnoPublicacao = Faker.RandomNumber.Next(), AutorId = autor.Id },
                    new Livro { Titulo = Faker.Name.Prefix(), AnoPublicacao = Faker.RandomNumber.Next(), AutorId = autor.Id }
                };
            
                repositoryLivro.InsertAll(livros);
            }

            return Ok("Saved!");
        }

        [HttpGet("obter-por-id")]
        public IActionResult GetById(
            [FromServices] IAutorDapperRepository repository, int id)
        {
            var result = repository.GetById(id);

            if (result == null) return NoContent();

            return Ok(result);
        }

        [HttpPut("editar")]
        public IActionResult Update(
            [FromServices] IAutorDapperRepository repository,
            [FromBody] AutorPost autorRequest, int id)
        {
            var autor = repository.GetById(id);

            if (autor == null) return NotFound();

            autor.Nome = autorRequest.Nome;
            autor.Endereco = autorRequest.Endereco;
            autor.Telefone = autorRequest.Telefone;
            autor.Pais = autorRequest.Pais;

            repository.Update(autor);

            return Ok("Updated!");
        }

        [HttpDelete("remover")]
        public IActionResult Remove(
            [FromServices] IAutorDapperRepository repository, int id)
        {
            var autorRemove = repository.GetById(id);

            if (autorRemove == null) return NotFound();

            repository.Remove(autorRemove);

            return Ok("Removed!");
        }

        [HttpGet("obter-por-nome")]
        public IActionResult GetByName(
            [FromServices] IAutorDapperRepository repository, string nome)
        {
            var result = repository.GetByName(nome);

            if (result == null) return NoContent();

            return Ok(result);
        }

        [HttpGet("publicacoes-por-autor")]
        public IActionResult GetByIdFetchLivro(
            [FromServices] IAutorDapperRepository repository, int id)
        {
            var result = repository.GetByIdFetchAll(id);

            if (result == null) return NoContent();

            return Ok(result);
        }

    }
}
