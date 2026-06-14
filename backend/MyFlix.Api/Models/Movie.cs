namespace MyFlix.Api.Models
{
    public class Movie
    {
        public int Id { get; set; } // Pega pelo ID do filme
        public string Title { get; set; } = string.Empty; // Título do filme
        public int ReleaseYear { get; set; }// Ano de lançamento do filme
        public string Genre { get; set; } = string.Empty;// Gênero do filme
        public MovieStatus Status { get; set; } = MovieStatus.ToWatch;// Status do filme 
        public int? Rating { get; set; }// Avaliação do filme

    }
}
