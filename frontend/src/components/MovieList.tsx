import api from "../services/movieService";
import type { Movie } from "../types/Movie";

interface MovieListProps {
  movies: Movie[];
  onMovieDeleted: () => void;
  onMovieEdit: (movie: Movie) => void;
}

export default function MovieList({
  movies,
  onMovieDeleted,
  onMovieEdit,
}: MovieListProps) {
  async function handleDelete(id: number) {
    if (!confirm("Deseja realmente excluir este filme?")) return;

    try {
      await api.delete(`/Movies/${id}`);
      onMovieDeleted();
    } catch (error) {
      console.error("Erro ao excluir filme:", error);
    }
  }

  function getStatusText(status: number) {
    switch (status) {
      case 1:
        return "🎯 Quero Assistir";
      case 2:
        return "👀 Assistindo";
      case 3:
        return "✅ Assistido";
      default:
        return "❓ Desconhecido";
    }
  }

  return (
    <ul>
      {movies.map((movie) => (
        <li key={movie.id}>
          <strong>{movie.title}</strong>
          {" - "}
          {movie.releaseYear}
          {" - "}
          {movie.genre}
          {" - "}
          {getStatusText(movie.status)}
          {" - "}
          ⭐ {movie.rating ?? "Sem nota"}

          <button
            style={{ marginLeft: "10px" }}
            onClick={() => onMovieEdit(movie)}
          >
            Editar
          </button>

          <button
            style={{ marginLeft: "10px" }}
            onClick={() => handleDelete(movie.id)}
          >
            Excluir
          </button>
        </li>
      ))}
    </ul>
  );
}