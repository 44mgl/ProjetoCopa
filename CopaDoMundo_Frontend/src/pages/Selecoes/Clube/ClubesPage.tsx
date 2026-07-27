import { useEffect, useState } from "react";
import api from "../../../services/api";
import CardClube from "../../../components/clube/CardClube";


interface Clube{
    id: number;
    nome: string;
    pais: string;
    escudoUrl: string;
}

function ClubesPage() {

    const [clubes, setClubes] = useState<Clube[]>([]);
    
    const [pesquisar, setPesquisar] = useState(""); // Cria um novo array somente com as seleções cujo nome contém o texto pesquisado
    const clubesFiltrados = clubes.filter((clube) =>
    clube.nome.toLowerCase().includes(pesquisar.toLowerCase())
    );

    const [carregando, setCarregando] = useState(true);

    const [nome, setNome] = useState(""); 
    const [pais, setPais] = useState("");
    const [escudoUrl, setEscudoUrl] = useState("");

    const [clubeEditandoId, setClubeEditandoId] = useState<number | null>(null);

async function buscarClubes() {
    
    try {
        const resposta = await api.get<Clube[]>("/Clube");

        setClubes(resposta.data);
    }
    catch (erro) {
        console.log(erro)
    }
    finally {
        setCarregando(false);
    }
    }
    
    async function cadastrarClube(evento: React.FormEvent<HTMLFormElement>) {
        evento.preventDefault();

        try {
            const novoClube = {
                nome,
                pais,
                escudoUrl
            };

            await api.post("/Clube", novoClube);

            await buscarClubes();
            
            setNome("");
            setPais("");
            setEscudoUrl("");
        }
        catch (erro) {
            console.log(erro);
        }
    }

    async function excluirClube(id: number) {
        try {
            await api.delete(`/Clube/${id}`);

            await buscarClubes();
        }
        catch (erro) {
            console.log(erro);
        }
    }

    async function editarClube(clube: Clube) {
        setClubeEditandoId(clube.id);
        setNome(clube.nome);
        setPais(clube.pais);
        setEscudoUrl(clube.escudoUrl);
    }

    async function atualizarClube(evento: React.FormEvent<HTMLFormElement>) {
        if (clubeEditandoId === null) {
            return;
        }

        try {
            const clubeAtualizado = {
                nome,
                pais,
                escudoUrl
            };

            await api.put(`/Clube/${clubeEditandoId}`, clubeAtualizado);

            await buscarClubes();
                setNome("");
                setPais("");
                setEscudoUrl("");
                setClubeEditandoId(null);
        }
        catch (erro) {
            console.log("Erro ao atualizar: ", erro)
        }
    }

    function cancelarEdicao() {
                setNome("");
                setPais("");
                setEscudoUrl("");
                setClubeEditandoId(null);
                setPesquisar("");
        }

    useEffect(() => {
        buscarClubes();
    }, []);

    if (carregando) {
        return <h2>{"Carregando Clubes..."}</h2>
    }

    return (
        <main>
            <h1>Clubes Dos Jogadores</h1>

            <form onSubmit={
                clubeEditandoId === null
                    ? cadastrarClube
                    : atualizarClube
            }>
                <input
                    type="text"
                    placeholder="Nome Do Clube"
                    value={nome}
                    onChange={(evento) => setNome(evento.target.value)}
                />

                <input
                    type="text"
                    placeholder="Nome do País"
                    value={pais}
                    onChange={(evento) => setPais(evento.target.value)}
                />

                <input
                    type="text"
                    placeholder="URL do Escudo"
                    value={escudoUrl}
                    onChange={(evento) => setEscudoUrl(evento.target.value)}
                />

                <input
                    type="text"
                    placeholder="Pesquisar Clube..."
                    value={pesquisar}
                    onChange={(evento) => setPesquisar(evento.target.value)}
                />

                <button type="submit">
                    {clubeEditandoId === null
                        ? "Cadastrar"
                        : "Atualizar"
                    }
                </button>

                <button
                    type="button"
                    onClick={cancelarEdicao}>Limpar
                </button>
            </form>

            {clubesFiltrados.length === 0 ? (
                <p>Nenhum Clube Encontrado.</p>
            ) : (
                clubesFiltrados.map((clube) => (
                    <CardClube
                        key={clube.id}
                        id={clube.id}
                        nome={clube.nome}
                        pais={clube.pais}
                        escudoUrl={clube.escudoUrl}
                        onExcluir={excluirClube}
                        onEditar={() => editarClube(clube)}
                    />
                ))
            )}
        </main>
    );
}

export default ClubesPage;