import React from 'react';
import './App.css';
import Board from './Board.jsx';

const title = 'Have fun!';

function App() {
  return (
    <div className="App">
      <div className="board-container">
        <h1>{title}</h1>
        <Board />
      </div>
    </div>
  );
}

export default App;
