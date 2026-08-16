import { useState } from "react";
import SelecoesPage from "./pages/Selecoes/SelecoesPage";
import ClubesPage from "./pages/Selecoes/Clube/ClubesPage";
import JogadorPage from "./pages/Selecoes/Jogador/JogadorPage";

function App() {
  const [paginaAtual, setPaginaAtual] = useState("selecoes");

  return (
    <>
      <header className="navbar">
        <div className="logo">
          Copa do <span>Mundo</span>
        </div>

        <nav className="nav-botoes">
          <button
            type="button"
            className={paginaAtual === "selecoes" ? "btn-nav ativo" : "btn-nav"}
            onClick={() => setPaginaAtual("selecoes")}
          >
            Seleções
          </button>

          <button
            type="button"
            className={paginaAtual === "clubes" ? "btn-nav ativo" : "btn-nav"}
            onClick={() => setPaginaAtual("clubes")}
          >
            Clubes
          </button>

          <button
            type="button"
            className={paginaAtual === "jogadores" ? "btn-nav ativo" : "btn-nav"}
            onClick={() => setPaginaAtual("jogadores")}
          >
            Jogadores
          </button>
        </nav>
      </header>

      {paginaAtual === "selecoes" && <SelecoesPage />}
      {paginaAtual === "clubes" && <ClubesPage />}
      {paginaAtual === "jogadores" && <JogadorPage />}
    </>
  );
}

export default App;
