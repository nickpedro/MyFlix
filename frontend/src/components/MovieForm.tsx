import { useState } from "react";
import api from "../services/movieService";

interface MovieFormProps {
  onMovieCreated: () => void;
}

export default function MovieForm({ onMovieCreated }: MovieFormProps) {
  const [title, setTitle] = useState("");
  const [releaseYear, setReleaseYear] = useState("");
  const [genre, setGenre] = useState("");

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();

    try {
      await api.post("/Movies", {
        title,
        releaseYear: Number(releaseYear),
        genre,
      });

      setTitle("");
      setReleaseYear("");
      setGenre("");

      onMovieCreated();
    } catch (error) {
      console.error("Erro ao cadastrar filme:", error);
    }
  }

  return (
    <form onSubmit={handleSubmit}>
      <h2>Adicionar Filme</h2>

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

      <button type="submit">Salvar</button>
    </form>
  );
}