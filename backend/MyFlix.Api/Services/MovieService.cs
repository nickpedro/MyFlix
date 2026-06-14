using Microsoft.EntityFrameworkCore;
using MyFlix.Api.Data;
using MyFlix.Api.DTOs;
using MyFlix.Api.Models;

namespace MyFlix.Api.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        // Implementação dos métodos da interface IMovieService
        public async Task<IEnumerable<MovieResponseDto>> GetAllAsync()
        {
            return await _context.Movies
                .Select(movie => new MovieResponseDto
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    ReleaseYear = movie.ReleaseYear,
                    Genre = movie.Genre,
                    Status = movie.Status,
                    Rating = movie.Rating
                })
                .ToListAsync();
        }

        // Implementação do método GetByIdAsync para obter um filme específico por ID
        public async Task<MovieResponseDto?> GetByIdAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
                return null;
            return new MovieResponseDto
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Genre = movie.Genre,
                Status = movie.Status,
                Rating = movie.Rating
            };
        }

        // Implementação do método CreateAsync para criar um novo filme
        public async Task<MovieResponseDto> CreateAsync(CreateMovieDto dto)
        {
            var movie = new Movie
            {
                Title = dto.Title,
                ReleaseYear = dto.ReleaseYear,
                Genre = dto.Genre,
                Status = MovieStatus.ToWatch,
            };
            _context.Movies.Add(movie);

            await _context.SaveChangesAsync();

            return new MovieResponseDto
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Genre = movie.Genre,
                Status = movie.Status,
                Rating = movie.Rating
            };
        }

        // Implementação do método UpdateAsync para atualizar um filme existente
        public async Task<bool> UpdateAsync(int id, UpdateMovieDto dto)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
                return false;

            movie.Title = dto.Title;
            movie.ReleaseYear = dto.ReleaseYear;
            movie.Genre = dto.Genre;
            movie.Status = dto.Status;
            movie.Rating = dto.Rating;

            await _context.SaveChangesAsync();

            return true;
        }

        // Implementação do método DeleteAsync para excluir um filme por ID
        public async Task<bool> DeleteAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
                return false;

            _context.Movies.Remove(movie);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
