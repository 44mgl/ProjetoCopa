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
    
    const [selecoes, setSelecoes] = useState<Selecao[]>([]);

    async function buscarSelecoes() {
        const resposta = await api.get<Selecao[]>("/Selecao");

        setSelecoes(resposta.data);
    }

    useEffect(() => {
      buscarSelecoes();
    }, []);

  return (
    <main>
      <h1>Seleções da Copa Do Mundo</h1>

      {selecoes.map((selecao) => (
        <CardSelecao
          key={selecao.id} 
          nome={selecao.nome}
          grupo={selecao.grupo}
          bandeiraUrl={selecao.bandeiraUrl}
        />
      ))}
     
    </main>
  );
}

export default SelecoesPage;