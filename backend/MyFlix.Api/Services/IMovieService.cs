using MyFlix.Api.DTOs;

namespace MyFlix.Api.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieResponseDto>> GetAllAsync();// Retorna uma lista de filmes
        Task<MovieResponseDto?> GetByIdAsync(int id); // Retorna um filme específico com base no ID fornecido. Se o filme não for encontrado, retorna null.
        Task<MovieResponseDto> CreateAsync(CreateMovieDto dto); // Cria um novo filme com base nos dados fornecidos no CreateMovieDto e retorna o filme criado como MovieResponseDto.
        Task<bool> UpdateAsync(int id, UpdateMovieDto dto); // Atualiza um filme existente com base no ID fornecido e nos dados fornecidos no UpdateMovieDto. Retorna true se a atualização for bem-sucedida, caso contrário, retorna false.
        Task<bool> DeleteAsync(int id); // Exclui um filme com base no ID fornecido. Retorna true se a exclusão for bem-sucedida, caso contrário, retorna false.
    }
}
