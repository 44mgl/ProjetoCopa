interface CardJogadorProps {
    id: number;
    nome: string;
    posicao: string;
    numero: number;
    idade: number;
    fotoJogadorUrl: string;
    selecaoNome: string;
    clubeNome: string;
    onExcluir: (id: number) => void;
    onEditar: (id: number) => void;
}

function CardJogador({
    id,
    nome,
    posicao,
    numero,
    idade,
    fotoJogadorUrl,
    selecaoNome,
    clubeNome,
    onExcluir,
    onEditar,
}: CardJogadorProps) {
    return (
        <div className="card">
            <img className="card-imagem" src={fotoJogadorUrl} alt={`Foto de ${nome}`} />

            <div className="card-corpo">
                <h2>{nome}</h2>
                <p>Posição: {posicao}</p>
                <p>Número da Camisa: {numero}</p>
                <p>Idade: {idade} anos</p>
                <p>Seleção: {selecaoNome}</p>
                <p>Clube: {clubeNome}</p>
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

export default CardJogador;
