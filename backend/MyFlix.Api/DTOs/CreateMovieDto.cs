namespace MyFlix.Api.DTOs
{
    public class CreateMovieDto
    {
        public string Title { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string Genre { get; set; } = string.Empty;
    }
}
