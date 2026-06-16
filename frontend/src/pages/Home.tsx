import { useEffect, useState } from "react";
import api from "../services/movieService";
import type { Movie } from "../types/Movie";
import MovieForm from "../components/MovieForm";

export default function Home() {
  const [movies, setMovies] = useState<Movie[]>([]);

  useEffect(() => {
    loadMovies();
  }, []);

  async function loadMovies() {
    try {
      const response = await api.get("/Movies");
      setMovies(response.data);
    } catch (error) {
      console.error("Erro ao buscar filmes:", error);
    }
  }

  return (
    <div style={{ padding: "20px" }}>
      <h1>🎬 MyFlix</h1>

      <MovieForm onMovieCreated={loadMovies} />
      
      <hr />

      <h2>Lista de Filmes</h2>

      {movies.length === 0 ? (
        <p>Nenhum filme encontrado.</p>
      ) : (
        <ul>
          {movies.map((movie) => (
            <li key={movie.id}>
              <strong>{movie.title}</strong>
              {" - "}
              {movie.releaseYear}
              {" - "}
              {movie.genre}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}