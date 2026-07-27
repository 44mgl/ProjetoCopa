interface CardClubeProps{
    id: number;
    nome: string;
    pais: string;
    escudoUrl: string;
    onExcluir: (id: number) => void;
    onEditar: (id: number) => void;
}

function CardClube({ id, nome, pais, escudoUrl, onExcluir, onEditar }: CardClubeProps) {
    return (
        <div>
            <img src={escudoUrl} alt={`Bandeira de ${nome}`} />

            <h2>{nome}</h2>

            <p>Grupo: {pais}</p>

            <button onClick={() => onExcluir(id)}>
                Excluir
            </button>

            <button onClick={() => onEditar(id)}>
                Editar
            </button>

        </div>
    );
}

export default CardClube;