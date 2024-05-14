import React, { useState } from 'react';
import './Board.css';
import Piece from './Piece';

const vertical = [1, 2, 3, 4, 5, 6, 7, 8];
const horizontal = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'];

let activePiece = null;
let selectedSquareRow = null;
let selectedSquareCol = null;

function Board() {
  const [boardState, setBoardState] = useState(initializeBoard());
  
  function initializeBoard() {
    // Initialize the board state with piece positions
    const initialState = [];
    for (let i = 0; i < vertical.length; i++) {
      const row = [];
      for (let j = 0; j < horizontal.length; j++) {
        const pieceType = determinePieceType(i, j);
        row.push(pieceType || ' ');
      }
      initialState.push(row);
    }
    return initialState;
  }

  function handleSquareClick(i, j) {
    selectedSquareRow = i;
    selectedSquareCol = j;

    // Send click position to backend
    fetch('/api/game/click', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ row: i, column: j }),
    })
      .then(response => response.json())
      .then(data => {
        // Handle response from backend 
        console.log(data);
      })
      .catch(error => {
        console.error('Error:', error);
      });
  }

  function handlePieceDragStart(event, pieceType) {
    activePiece = pieceType;
  }

  function handleSquareDrop(i, j) {
    // Update board state with the dropped piece
    const updatedBoardState = [...boardState];
    updatedBoardState[i][j] = activePiece;

    // Clear the original position of the piece
    if (selectedSquareRow !== null && selectedSquareCol !== null) {
      updatedBoardState[selectedSquareRow][selectedSquareCol] = null;
      selectedSquareRow = null;
      selectedSquareCol = null;
    }

    setBoardState(updatedBoardState);

    // Send move information to backend
    fetch('/api/game/move', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        fromRow: selectedSquareRow,
        fromColumn: selectedSquareCol,
        toRow: i,
        toColumn: j,
      }),
    })
      .then(response => response.json())
      .then(data => {
        // Handle response from backend 
        console.log(data);
      })
      .catch(error => {
        console.error('Error:', error);
      });
  }
  function determinePieceType(i, j) {
    if (i === 1) {
      return 'pawn_B';
    } else if (i === 6) {
      return 'pawn_W';
    } else if (i === 0 && (j === 0 || j === 7)) {
      return 'rook_B';
    } else if (i === 7 && (j === 0 || j === 7)) {
      return 'rook_W';
    } else if (i === 0 && (j === 1 || j === 6)) {
      return 'knight_B';
    } else if (i === 7 && (j === 1 || j === 6)) {
      return 'knight_W';
    } else if (i === 0 && (j === 2 || j === 5)) {
      return 'bishop_B';
    } else if (i === 7 && (j === 2 || j === 5)) {
      return 'bishop_W';
    } else if (i === 0 && j === 3) {
      return 'king_B';
    } else if (i === 0 && j === 4) {
      return 'queen_B';
    } else if (i === 7 && j === 3) {
      return 'king_W';
    } else if (i === 7 && j === 4) {
      return 'queen_W';
    }
    return null;
  }

  return (
    <div id="chessboard">
      {horizontal.map((letter, j) => (
        <div key={letter} className="board-column">
          {vertical.map((number, i) => (
            <div
              key={`${letter}-${number}`}
              className={`tile ${((i + j) % 2 === 0) ? 'dark-square' : 'white-square'}`}
              onClick={() => handleSquareClick(i, j)}
              onDragOver={(e) => e.preventDefault()}
              onDrop={() => handleSquareDrop(i, j)}
            >
              <Piece type={boardState[i][j]} onDragStart={(e) => handlePieceDragStart(e, boardState[i][j])} />
            </div>
          ))}
        </div>
      ))}
    </div>
  );
}

export default Board;
