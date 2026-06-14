using MyFlix.Api.Models;

namespace MyFlix.Api.DTOs
{
    public class MovieResponseDto
    {
        public int Id { get; set; } // Identificador único do filme
        public string Title { get; set; } = string.Empty; // Titulo do filme
        public int ReleaseYear { get; set; } // Ano de lançamento do filme
        public string Genre { get; set; } = string.Empty; // Gênero do filme
        public MovieStatus Status { get; set; } // Status do filme
        public int? Rating { get; set; } // Avaliação do filme

    }
}
