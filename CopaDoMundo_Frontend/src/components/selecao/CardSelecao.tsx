// Representa a página completa de seleções e organiza a lista.

interface CardSelecaoProps{ // Define o que o componente precisa receber
    nome: string;
    grupo: string;
    bandeiraUrl: string;
}

function CardSelecao({ nome, grupo, bandeiraUrl }: CardSelecaoProps) { // Componente recebe os valores
    return (
        <div>
            <img src={bandeiraUrl} alt={`Bandeira de ${nome}`} />
            
            <h2>{nome}</h2>

            <p>Grupo: {grupo}</p>
        </div>
    );
}

export default CardSelecao;