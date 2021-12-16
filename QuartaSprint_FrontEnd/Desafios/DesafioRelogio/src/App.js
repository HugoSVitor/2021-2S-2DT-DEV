import React from 'react';
import './App.css';

function DataFormatada(props) {
  return <h2>Horário atual: {props.date.toLocaleTimeString()}</h2>
}

class Clock extends React.Component{
  constructor(props){
    super(props);
    this.state = {
      //Definimos o estado date pegando a data atual
      date : new Date()
    }
  }

  //Fora do construtor, definidos os ciclos de vida

  //Ciclo de vida que ocorre quando Clock é inserido na DOM
  componentDidMount(){
    this.idTime = setInterval(() => {
      this.tick()
    }, 1000);
  }

  //Ciclo de vida que ocorre quando clock é removido da DOM
  componentWillUnmount(){
    clearInterval(this.idTime)
  }

  tick(){
    this.setState({
      date : new Date()
    })
  }

  parar(){
    clearInterval(this.idTime)
  }

  retomar(){
    this.idTime = setInterval(() => {
    this.tick()
    }, 1000);
  }

  render(){
    return (
      <div>
        <h1>Relogio</h1>
        <DataFormatada date={this.state.date} />  
        <button id="Parar" onClick={() => this.parar()}>Parar</button>
        <button id="Retomar" onClick={() => this.retomar()}>Continuar</button>
      </div>
    )
  }
}


function App() {
  return (
    <div className="App">
      <header className="App-header">
        <Clock />
        <Clock />
      </header>
    </div>
  );
}

export default App;
