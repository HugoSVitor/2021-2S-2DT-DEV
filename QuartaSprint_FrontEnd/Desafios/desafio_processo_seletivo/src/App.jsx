import { Component } from 'react';
import './App.css';

class ListaRepositorios extends Component{
  constructor(props){
    super(props);
    this.state = {
      //Definimos o estado date pegando a data atual
      listaDosRepositorios : [],
      nomeUsuario : ''
    }
  }

  //Fora do construtor, definidos os ciclos de vida

  //Ciclo de vida que ocorre quando Clock é inserido na DOM
  componentDidMount(){
    console.log('O sistema foi iniciado!')
  }

  //Ciclo de vida que ocorre quando clock é removido da DOM
  componentWillUnmount(){
    clearInterval(this.idTime)
  }

  atualizaEstadodoNomeUsuario = async (event) => {
    //Nome titulo > valor input.
    await this.setState({ nomeUsuario: event.target.value })
    console.log(this.state.nomeUsuario)
}

  buscarRepositorios = () => {
    console.log("Fazendo a chamada para a API")

    fetch('https://api.github.com/users/'+ this.state.nomeUsuario +'/repos')

    .then(resposta => resposta.json())

    .then(dados => this.setState({listaDosRepositorios : dados}))

    .catch(erro => console.log(erro))


  }

  limparCampos = () => {
    this.setState({
        nomeUsuario : '',
    })
    console.log('Os states foram resetados!')
}


  render(){
    return (
      <div>
        <main>
          <h1>Processo Seletivo</h1>

          <h2>Insira um nome de usuário do github</h2>
          <input type="text" value={this.state.nomeUsuario} onChange={this.atualizaEstadodoNomeUsuario}></input>
          <button type="submit" onClick={() => this.buscarRepositorios()}>Listar</button>
          <button type="submit" onClick={() => this.limparCampos()}>Limpar</button>

          <table>
            <thead>
              <tr>
                <th>#</th>
                <th>nomeRepositorio</th>
                <th>descricaoRepositorio</th>
                <th>dataCriacao</th>
                <th>tamanhoRepositorio</th>
              </tr>
            </thead>
            <tbody>
              {
                this.state.listaDosRepositorios.map((repositorio) => {return (
                  <tr>
                    <td>{repositorio.id}</td>
                    <td>{repositorio.name}</td>
                    <td>{repositorio.description}</td>
                    <td>{repositorio.created_at}</td>
                    <td>{repositorio.size}</td>
                  </tr>

                )})
              }
            </tbody>
          </table>

          
        </main>
      </div>
    )}

    



    }function App() {
  return (
    <div className="App">
      <header className="App-header">
      <ListaRepositorios/>
      </header>
    </div>
  );
}



export default App;
