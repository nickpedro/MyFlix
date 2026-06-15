using Microsoft.AspNetCore.Mvc;
using MyFlix.Api.Data;
using MyFlix.Api.DTOs;
using MyFlix.Api.Services;

namespace MyFlix.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        // Injeção de dependência do serviço de filmes
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() // Método para obter todos os filmes
        {
            var movies = await _movieService.GetAllAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) // Método para obter um filme específico por ID
        {
            var movie = await _movieService.GetByIdAsync(id);

            if (movie == null)

                return NotFound();

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieDto dto) // Método para criar um novo filme
        {
            var createdMovie = await _movieService.CreateAsync(dto);

            return CreatedAtAction(nameof(GetById),
                new { id = createdMovie.Id }, createdMovie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMovieDto dto) // Método para atualizar um filme existente
        {
            var updated = await _movieService.UpdateAsync(id, dto);

            if (!updated)
                return NotFound(new { message = "Movie Not Found" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) // Método para excluir um filme por ID
        {
            var deleted = await _movieService.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = "Movie Not Found" });

            return NoContent();
        }
    }
}
