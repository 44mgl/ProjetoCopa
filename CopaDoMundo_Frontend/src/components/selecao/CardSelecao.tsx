interface CardSelecaoProps {
    id: number;
    nome: string;
    grupo: string;
    bandeiraUrl: string;
    onExcluir: (id: number) => void;
    onEditar: (id: number) => void;
}

function CardSelecao({ id, nome, grupo, bandeiraUrl, onExcluir, onEditar }: CardSelecaoProps) {
    return (
        <div className="card">
            <img className="card-imagem" src={bandeiraUrl} alt={`Bandeira de ${nome}`} />

            <div className="card-corpo">
                <h2>{nome}</h2>
                <p>Grupo: {grupo}</p>
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

export default CardSelecao;
