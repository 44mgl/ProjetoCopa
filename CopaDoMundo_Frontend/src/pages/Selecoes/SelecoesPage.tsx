// Monta a aplicação e decide qual página aparece.
import { useEffect, useState } from "react";
import CardSelecao from "../../components/selecao/CardSelecao";
import api from "../../services/api";

interface Selecao {
    id: number;
    nome: string;
    grupo: string;
    bandeiraUrl: string;
}

function SelecoesPage() {
    
    const [selecoes, setSelecoes] = useState<Selecao[]>([]); // Guarda todas as selecoes da API

    const [pesquisar, setPesquisar] = useState(""); // Cria um novo array somente com as seleções cujo nome contém o texto pesquisado
    const selecoesFiltradas = selecoes.filter((selecao) =>
    selecao.nome.toLowerCase().includes(pesquisar.toLowerCase())
    );

    const [carregando, setCarregando] = useState(true);  // Guarda se os dados ainda estão sendo carregados

    const [nome, setNome] = useState(""); 
    const [grupo, setGrupo] = useState("");
    const [bandeiraUrl, setBandeiraUrl] = useState("");

    const [selecaoEditandoId, setSelecaoEditandoId] = useState<number | null>(null); // Pega o ID da selecao que esta sendo editada

    async function buscarSelecoes() {
        
        try {
            const resposta = await api.get<Selecao[]>("/Selecao");

            setSelecoes(resposta.data);
        }
        catch (erro) {
           console.log(erro)
        }
        finally { // Sempre executa, não importa se deu erro ou não
            setCarregando(false);
        }
    }

    async function cadastrarSelecao(evento: React.FormEvent<HTMLFormElement>) {
            evento.preventDefault(); // evitar que links redirecionem a página ou que formulários façam recarregamentos ao serem enviados, permitindo que você controle essas ações de forma assíncrona

        try {
            const novaSelecao = {
                nome,
                grupo,
                bandeiraUrl
            };

            await api.post("/Selecao", novaSelecao);

            await buscarSelecoes();

            setNome("");
            setGrupo("");
            setBandeiraUrl("");
        }
        catch (erro) {
            console.log(erro);
        }
    }

    async function excluirSelecao(id: number) {
         try {
            await api.delete(`/Selecao/${id}`);

            await buscarSelecoes();
        }
        catch (erro) {
            console.log(erro);
        }
    }
    
    async function editarSelecao(selecao: Selecao) {
            setSelecaoEditandoId(selecao.id);
            setNome(selecao.nome);
            setGrupo(selecao.grupo);
            setBandeiraUrl(selecao.bandeiraUrl);
        }

    async function atualizarSelecao(evento: React.FormEvent<HTMLFormElement>) {
            evento.preventDefault();

            if (selecaoEditandoId === null) {
                return;
            }

            try {
                const selecaoAtualizada = {
                    nome,
                    grupo,
                    bandeiraUrl
                };
                
            await api.put(`/Selecao/${selecaoEditandoId}`,selecaoAtualizada);

            await buscarSelecoes();
                setNome("");
                setGrupo("");
                setBandeiraUrl("");
                setSelecaoEditandoId(null);
            } 
            catch (erro)
            {
                console.log("Erro ao atualizar: ", erro);
            }
    }

    function cancelarEdicao() {
            setSelecaoEditandoId(null);
            setNome("");
            setGrupo("");
            setBandeiraUrl("");
            setPesquisar("");
    }
        

    useEffect(() => {
      buscarSelecoes();
    }, []);

    if (carregando) {
        return <p className="carregando">Carregando Seleções...</p>
    }

  return (
    <main className="pagina">
        <div className="cabecalho-pagina">
            <h1>Seleções da Copa do Mundo</h1>
            <p>Cadastre e gerencie as seleções participantes</p>
        </div>

        <form
            className="formulario"
            onSubmit={
         selecaoEditandoId === null
            ? cadastrarSelecao
            : atualizarSelecao
        }>
            <input
                type="text"
                placeholder="Nome da Seleção"
                value={nome}
                onChange={(evento) => setNome(evento.target.value)}
            />

            <input
                type="text"
                placeholder="Grupo"
                value={grupo}
                onChange={(evento) => setGrupo(evento.target.value)}
            />

            <input
                type="text"
                placeholder="URL da Bandeira"
                value={bandeiraUrl}
                onChange={(evento) => setBandeiraUrl(evento.target.value)}
            />
                
            <input
                className="campo-busca"
                type="text"
                placeholder="Pesquisar Seleção..."
                value={pesquisar}
                onChange={(e) => setPesquisar(e.target.value)}
            />

            <div className="botoes-form">
                <button className="btn btn-primario" type="submit">
                    {selecaoEditandoId === null
                    ? "Cadastrar"
                    : "Atualizar"}
                </button>

                <button
                    className="btn btn-secundario"
                    type="button"
                    onClick={cancelarEdicao}>Limpar
                </button>
            </div>
          </form>

        {selecoesFiltradas.length === 0 ? (
        <p className="vazio">Nenhuma Seleção Encontrada.</p>
    ) : (
        <div className="lista-cards">
        {selecoesFiltradas.map((selecao) => (
            <CardSelecao
                key={selecao.id}
                id={selecao.id}
                nome={selecao.nome}
                grupo={selecao.grupo}
                bandeiraUrl={selecao.bandeiraUrl}
                onExcluir={excluirSelecao}
                onEditar={() => editarSelecao(selecao)}
            />
        ))}
        </div>
    )}
        
    </main>
  );
}

export default SelecoesPage;