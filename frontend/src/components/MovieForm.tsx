import { useEffect, useState } from "react";
import api from "../services/movieService";
import type { Movie } from "../types/Movie";

interface MovieFormProps {
  onMovieSaved: () => void;
  movieToEdit: Movie | null;
  clearEditing: () => void;
}

export default function MovieForm({
  onMovieSaved,
  movieToEdit,
  clearEditing,
}: MovieFormProps) {
  const [title, setTitle] = useState("");
  const [releaseYear, setReleaseYear] = useState("");
  const [genre, setGenre] = useState("");
  const [status, setStatus] = useState("1");
  const [rating, setRating] = useState("5");

  useEffect(() => {
    if (movieToEdit) {
      setTitle(movieToEdit.title);
      setReleaseYear(movieToEdit.releaseYear.toString());
      setGenre(movieToEdit.genre);
      setStatus(movieToEdit.status.toString());
      setRating((movieToEdit.rating ?? 5).toString());
    }
  }, [movieToEdit]);

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();

    const movieData = {
      title,
      releaseYear: Number(releaseYear),
      genre,
      status: Number(status),
      rating: Number(rating),
    };

    try {
      if (movieToEdit) {
        await api.put(`/Movies/${movieToEdit.id}`, movieData);
      } else {
        await api.post("/Movies", movieData);
      }

      setTitle("");
      setReleaseYear("");
      setGenre("");
      setStatus("1");
      setRating("5");

      clearEditing();
      onMovieSaved();
    } catch (error) {
      console.error("Erro ao salvar filme:", error);
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <h2>
        {movieToEdit ? "Editar Filme" : "Adicionar Filme"}
      </h2>

      <input
        type="text"
        placeholder="Título"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
      />

      <br />
      <br />

      <input
        type="number"
        placeholder="Ano"
        value={releaseYear}
        onChange={(e) => setReleaseYear(e.target.value)}
      />

      <br />
      <br />

      <input
        type="text"
        placeholder="Gênero"
        value={genre}
        onChange={(e) => setGenre(e.target.value)}
      />

      <br />
      <br />

      <label>Status</label>

      <br />

      <select
        value={status}
        onChange={(e) => setStatus(e.target.value)}
      >
        <option value="1">Quero Assistir</option>
        <option value="2">Assistindo</option>
        <option value="3">Assistido</option>
      </select>

      <br />
      <br />

      <label>Nota</label>

      <br />

      <select
        value={rating}
        onChange={(e) => setRating(e.target.value)}
      >
        <option value="1">1 ⭐</option>
        <option value="2">2 ⭐</option>
        <option value="3">3 ⭐</option>
        <option value="4">4 ⭐</option>
        <option value="5">5 ⭐</option>
      </select>

      <br />
      <br />

      <button type="submit">
        {movieToEdit ? "Atualizar" : "Salvar"}
      </button>
    </form>
  );
}