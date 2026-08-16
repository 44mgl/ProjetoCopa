import { useEffect, useState } from "react";
import api from "../../../services/api";
import CardJogador from "../../../components/jogador/CardJogador";

interface Selecao {
    id: number;
    nome: string;
    bandeiraUrl: string;
}

interface Clube {
    id: number;
    nome: string;
    escudoUrl: string;
}

interface Jogador {
    id: number;
    nome: string;
    posicao: string;
    numero: number;
    idade: number;
    fotoJogadorUrl: string;
    selecao: Selecao;
    clube: Clube;
}

function JogadorPage() {
    const [jogadores, setJogadores] = useState<Jogador[]>([]);
    const [selecoes, setSelecoes] = useState<Selecao[]>([]);
    const [clubes, setClubes] = useState<Clube[]>([]);

    const [pesquisar, setPesquisar] = useState("");
    const jogadoresFiltrados = jogadores.filter((jogador) =>
        jogador.nome.toLowerCase().includes(pesquisar.toLowerCase())
    );

    const [carregando, setCarregando] = useState(true);
    const [mensagemErro, setMensagemErro] = useState("");

    const [nome, setNome] = useState("");
    const [posicao, setPosicao] = useState("");
    const [numero, setNumero] = useState("");
    const [idade, setIdade] = useState("");
    const [fotoJogadorUrl, setFotoJogadorUrl] = useState("");
    const [selecaoId, setSelecaoId] = useState(0);
    const [clubeId, setClubeId] = useState(0);

    const [jogadorEditandoId, setJogadorEditandoId] = useState<number | null>(null);

    async function buscarJogadores() {
        try {
            const respostaJogadores = await api.get<Jogador[]>("/Jogador");
            setJogadores(respostaJogadores.data);

            const respostaSelecoes = await api.get<Selecao[]>("/Selecao");
            setSelecoes(respostaSelecoes.data);

            const respostaClubes = await api.get<Clube[]>("/Clube");
            setClubes(respostaClubes.data);
        } catch (erro) {
            console.log(erro);
        } finally {
            setCarregando(false);
        }
    }

    function validarFormulario() {
        if (nome.trim().length < 3) {
            setMensagemErro("O nome do jogador precisa ter pelo menos 3 letras.");
            return false;
        }

        if (posicao.trim().length < 3) {
            setMensagemErro("A posição precisa ter pelo menos 3 letras (ex: Atacante).");
            return false;
        }

        if (!numero || Number(numero) < 1 || Number(numero) > 99) {
            setMensagemErro("Preencha o número da camisa (de 1 a 99).");
            return false;
        }

        if (!idade || Number(idade) < 16 || Number(idade) > 50) {
            setMensagemErro("Preencha a idade do jogador (de 16 a 50 anos).");
            return false;
        }

        if (!fotoJogadorUrl.trim().startsWith("http")) {
            setMensagemErro("A URL da foto precisa começar com http (ex: https://...).");
            return false;
        }

        if (selecaoId === 0) {
            setMensagemErro("Selecione uma seleção.");
            return false;
        }

        if (clubeId === 0) {
            setMensagemErro("Selecione um clube.");
            return false;
        }

        setMensagemErro("");
        return true;
    }

    async function cadastrarJogador(evento: React.FormEvent<HTMLFormElement>) {
        evento.preventDefault();

        if (!validarFormulario()) {
            return;
        }

        try {
            const novoJogador = {
                nome,
                posicao,
                numero: Number(numero),
                idade: Number(idade),
                fotoJogadorUrl,
                selecaoId,
                clubeId,
            };

            await api.post("/Jogador", novoJogador);

            await buscarJogadores();

            setNome("");
            setPosicao("");
            setNumero("");
            setIdade("");
            setFotoJogadorUrl("");
            setSelecaoId(0);
            setClubeId(0);
            setMensagemErro("");
        } catch (erro: unknown) {
            const resposta = erro as { response?: { data?: { message?: string } } };
            const mensagemApi = resposta.response?.data?.message;
            setMensagemErro(mensagemApi || "Erro ao cadastrar jogador. Verifique os dados e tente novamente.");
            console.log(erro);
        }
    }

    async function excluirJogador(id: number) {
        try {
            await api.delete(`/Jogador/${id}`);

            await buscarJogadores();
        } catch (erro) {
            console.log(erro);
        }
    }

    function editarJogador(jogador: Jogador) {
        setJogadorEditandoId(jogador.id);
        setNome(jogador.nome);
        setPosicao(jogador.posicao);
        setNumero(String(jogador.numero));
        setIdade(String(jogador.idade));
        setFotoJogadorUrl(jogador.fotoJogadorUrl);
        setSelecaoId(jogador.selecao.id);
        setClubeId(jogador.clube.id);
        setMensagemErro("");
    }

    async function atualizarJogador(evento: React.FormEvent<HTMLFormElement>) {
        evento.preventDefault();

        if (jogadorEditandoId === null) {
            return;
        }

        if (!validarFormulario()) {
            return;
        }

        try {
            const jogadorAtualizado = {
                nome,
                posicao,
                numero: Number(numero),
                idade: Number(idade),
                fotoJogadorUrl,
                selecaoId,
                clubeId,
            };

            await api.put(`/Jogador/${jogadorEditandoId}`, jogadorAtualizado);

            await buscarJogadores();
            setNome("");
            setPosicao("");
            setNumero("");
            setIdade("");
            setFotoJogadorUrl("");
            setSelecaoId(0);
            setClubeId(0);
            setJogadorEditandoId(null);
            setMensagemErro("");
        } catch (erro: unknown) {
            const resposta = erro as { response?: { data?: { message?: string } } };
            const mensagemApi = resposta.response?.data?.message;
            setMensagemErro(mensagemApi || "Erro ao atualizar jogador. Verifique os dados e tente novamente.");
            console.log("Erro ao atualizar: ", erro);
        }
    }

    function cancelarEdicao() {
        setJogadorEditandoId(null);
        setNome("");
        setPosicao("");
        setNumero("");
        setIdade("");
        setFotoJogadorUrl("");
        setSelecaoId(0);
        setClubeId(0);
        setPesquisar("");
        setMensagemErro("");
    }

    useEffect(() => {
        buscarJogadores();
    }, []);

    if (carregando) {
        return <p className="carregando">Carregando Jogadores...</p>;
    }

    return (
        <main className="pagina">
            <div className="cabecalho-pagina">
                <h1>Jogadores da Copa do Mundo</h1>
                <p>Cadastre e gerencie os atletas das seleções</p>
            </div>

            <form
                className="formulario"
                onSubmit={
                    jogadorEditandoId === null ? cadastrarJogador : atualizarJogador
                }
            >
                <div className="campo">
                    <label htmlFor="nome-jogador">Nome do Jogador</label>
                    <input
                        id="nome-jogador"
                        type="text"
                        placeholder="Ex: Lionel Messi"
                        value={nome}
                        onChange={(evento) => setNome(evento.target.value)}
                    />
                </div>

                <div className="campo">
                    <label htmlFor="posicao-jogador">Posição</label>
                    <input
                        id="posicao-jogador"
                        type="text"
                        placeholder="Ex: Atacante"
                        value={posicao}
                        onChange={(evento) => setPosicao(evento.target.value)}
                    />
                </div>

                <div className="campo">
                    <label htmlFor="numero-camisa">Número da Camisa</label>
                    <input
                        id="numero-camisa"
                        type="number"
                        min={1}
                        max={99}
                        placeholder="Ex: 10"
                        value={numero}
                        onChange={(evento) => setNumero(evento.target.value)}
                    />
                </div>

                <div className="campo">
                    <label htmlFor="idade-jogador">Idade</label>
                    <input
                        id="idade-jogador"
                        type="number"
                        min={16}
                        max={50}
                        placeholder="Ex: 25"
                        value={idade}
                        onChange={(evento) => setIdade(evento.target.value)}
                    />
                </div>

                <div className="campo">
                    <label htmlFor="foto-jogador">URL da Foto</label>
                    <input
                        id="foto-jogador"
                        type="text"
                        placeholder="Ex: https://exemplo.com/foto.jpg"
                        value={fotoJogadorUrl}
                        onChange={(evento) => setFotoJogadorUrl(evento.target.value)}
                    />
                </div>

                <div className="campo">
                    <label htmlFor="selecao-jogador">Seleção</label>
                    <select
                        id="selecao-jogador"
                        value={selecaoId}
                        onChange={(evento) => setSelecaoId(Number(evento.target.value))}
                    >
                        <option value={0}>Selecione uma Seleção</option>
                        {selecoes.map((selecao) => (
                            <option key={selecao.id} value={selecao.id}>
                                {selecao.nome}
                            </option>
                        ))}
                    </select>
                </div>

                <div className="campo">
                    <label htmlFor="clube-jogador">Clube</label>
                    <select
                        id="clube-jogador"
                        value={clubeId}
                        onChange={(evento) => setClubeId(Number(evento.target.value))}
                    >
                        <option value={0}>Selecione um Clube</option>
                        {clubes.map((clube) => (
                            <option key={clube.id} value={clube.id}>
                                {clube.nome}
                            </option>
                        ))}
                    </select>
                </div>

                {mensagemErro && <p className="mensagem-erro">{mensagemErro}</p>}

                <div className="botoes-form">
                    <button className="btn btn-primario" type="submit">
                        {jogadorEditandoId === null ? "Cadastrar Jogador" : "Atualizar Jogador"}
                    </button>

                    <button className="btn btn-secundario" type="button" onClick={cancelarEdicao}>
                        Limpar
                    </button>
                </div>
            </form>

            <div className="formulario caixa-pesquisa">
                <div className="campo campo-busca">
                    <label htmlFor="pesquisar-jogador">Pesquisar Jogador</label>
                    <input
                        id="pesquisar-jogador"
                        type="text"
                        placeholder="Digite o nome do jogador..."
                        value={pesquisar}
                        onChange={(evento) => setPesquisar(evento.target.value)}
                    />
                </div>
            </div>

            {jogadoresFiltrados.length === 0 ? (
                <p className="vazio">Nenhum Jogador Encontrado.</p>
            ) : (
                <div className="lista-cards">
                {jogadoresFiltrados.map((jogador) => (
                    <CardJogador
                        key={jogador.id}
                        id={jogador.id}
                        nome={jogador.nome}
                        posicao={jogador.posicao}
                        numero={jogador.numero}
                        idade={jogador.idade}
                        fotoJogadorUrl={jogador.fotoJogadorUrl}
                        selecaoNome={jogador.selecao.nome}
                        clubeNome={jogador.clube.nome}
                        onExcluir={excluirJogador}
                        onEditar={() => editarJogador(jogador)}
                    />
                ))}
                </div>
            )}
        </main>
    );
}

export default JogadorPage;
