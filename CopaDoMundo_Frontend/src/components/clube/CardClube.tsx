interface CardClubeProps {
    id: number;
    nome: string;
    pais: string;
    escudoUrl: string;
    onExcluir: (id: number) => void;
    onEditar: (id: number) => void;
}

function CardClube({ id, nome, pais, escudoUrl, onExcluir, onEditar }: CardClubeProps) {
    return (
        <div className="card">
            <img className="card-imagem" src={escudoUrl} alt={`Escudo de ${nome}`} />

            <div className="card-corpo">
                <h2>{nome}</h2>
                <p>País: {pais}</p>
            </div>

            <div className="card-acoes">
                <button className="btn btn-editar" onClick={() => onEditar(id)}>
                    Editar
                </button>

                <button className="btn btn-perigo" onClick={() => onExcluir(id)}>
                    Excluir
                </button>
            </div>
        </div>
    );
}

export default CardClube;
