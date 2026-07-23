interface TituloProps {
  texto: string;
}

function Titulo({ texto }: TituloProps) {
  return <h1>{texto}</h1>;
}

export default Titulo;