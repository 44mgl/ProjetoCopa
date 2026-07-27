// Representa a página completa de seleções e organiza a lista.

interface CardSelecaoProps{ // Define o que o componente precisa receber
    id: number;
    nome: string;
    grupo: string;
    bandeiraUrl: string;
    onExcluir: (id: number) => void;
    onEditar: (id: number) => void;
}

function CardSelecao({ id, nome, grupo, bandeiraUrl, onExcluir, onEditar }: CardSelecaoProps) { // Componente recebe os valores
    return (
        <div>
            <img src={bandeiraUrl} alt={`Bandeira de ${nome}`} />
            
            <h2>{nome}</h2>

            <p>Grupo: {grupo}</p>

            <button onClick={() => onExcluir(id)}>
               Excluir
            </button>

            <button onClick={()=> onEditar(id)}>
               Editar
            </button>
            
        </div>
    );
}

export default CardSelecao;