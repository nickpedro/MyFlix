import { useEffect, useState } from "react";
import api from "../services/movieService";
import type { Movie } from "../types/Movie";

import MovieForm from "../components/MovieForm";
import MovieList from "../components/MovieList";

export default function Home() {
  const [movies, setMovies] = useState<Movie[]>([]);
  const [movieToEdit, setMovieToEdit] = useState<Movie | null>(null);

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

      <MovieForm
        onMovieSaved={loadMovies}
        movieToEdit={movieToEdit}
        clearEditing={() => setMovieToEdit(null)}
      />

      <hr />

      <h2>Lista de Filmes</h2>

      {movies.length === 0 ? (
        <p>Nenhum filme encontrado.</p>
      ) : (
        <MovieList
          movies={movies}
          onMovieDeleted={loadMovies}
          onMovieEdit={setMovieToEdit}
        />
      )}
    </div>
  );
}