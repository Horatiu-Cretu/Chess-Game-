import React from 'react';
import './ImageButton.css';
import BlackPawn from './images/PawnB.jpg';
import WhitePawn from './images/PawnW.png';
import BlackRook from './images/RookB.png';
import WhiteRook from './images/RookW.png';
import BlackKnight from './images/KnightB.png';
import WhiteKnight from './images/KnightW.png';
import BlackBishop from './images/BishopB.png';
import WhiteBishop from './images/BishopW.png';
import BlackQueen from './images/QueenB.png';
import WhiteQueen from './images/QueenW.png';
import BlackKing from './images/KingB.png';
import WhiteKing from './images/KingW.png';

export default function Piece(props) {
  const getBackgroundForPiece = (pieceType) => {
    if (pieceType === '') return {};
    switch (pieceType) {
      case "pawn_B":
        return {
          backgroundImage: `url(${BlackPawn})`,
          width: '100px',
          height: '100px',
          backgroundRepeat: 'no-repeat',
          backgroundPosition: 'center',
          backgroundSize: '50px'
        };
      case "pawn_W":
        return {
          backgroundImage: `url(${WhitePawn})`,
          width: '100px',
          height: '100px',
          backgroundRepeat: 'no-repeat',
          backgroundPosition: 'center',
          backgroundSize: '50px'
        };
      case "rook_B":
        return {
          backgroundImage: `url(${BlackRook})`,
          width: '100px',
          height: '100px',
          backgroundRepeat: 'no-repeat',
          backgroundPosition: 'center',
          backgroundSize: '50px'
        };
      case "rook_W":
        return {
          backgroundImage: `url(${WhiteRook})`,
          width: '100px',
          height: '100px',
          backgroundRepeat: 'no-repeat',
          backgroundPosition: 'center',
          backgroundSize: '50px'
        };
      case "knight_B":
        return {
          backgroundImage: `url(${BlackKnight})`,
          width: '100px',
          height: '100px',
          backgroundRepeat: 'no-repeat',
          backgroundPosition: 'center',
          backgroundSize: '50px'
        };
      case "knight_W":
        return {
          backgroundImage: `url(${WhiteKnight})`,
          width: '100px',
          height: '100px',
          backgroundRepeat: 'no-repeat',
          backgroundPosition: 'center',
          backgroundSize: '50px'
        };
      case "bishop_B":
        return {
          backgroundImage: `url(${BlackBishop})`,
          width: '100px',
          height: '100px',
          backgroundRepeat: 'no-repeat',
          backgroundPosition: 'center',
          backgroundSize: '50px'
        };
      case "bishop_W":
        return {
          backgroundImage: `url(${WhiteBishop})`,
          width: '100px',
          height: '100px',
          backgroundRepeat: 'no-repeat',
          backgroundPosition: 'center',
          backgroundSize: '50px'
        };
      case "queen_B":
        return {
          backgroundImage: `url(${BlackQueen})`,
          width: '100px',
          height: '100px',
          backgroundRepeat: 'no-repeat',
          backgroundPosition: 'center',
          backgroundSize: '50px'
        };
      case "queen_W":
        return {
          backgroundImage: `url(${WhiteQueen})`,
          width: '100px',
          height: '100px',
          backgroundRepeat: 'no-repeat',
          backgroundPosition: 'center',
          backgroundSize: '50px'
        };
      case "king_B":
        return {
          backgroundImage: `url(${BlackKing})`,
          width: '100px',
          height: '100px',
          backgroundRepeat: 'no-repeat',
          backgroundPosition: 'center',
          backgroundSize: '50px'
        };
      case "king_W":
        return {
          backgroundImage: `url(${WhiteKing})`,
          width: '100px',
          height: '100px',
          backgroundRepeat: 'no-repeat',
          backgroundPosition: 'center',
          backgroundSize: '50px'
        };
      default:
        return null;
    }
  };

  if (!props.type) return null; 
  
  return (
    <div
      className="piece image-button"
      style={getBackgroundForPiece(props.type)}
      draggable="true"
      onDragStart={props.onDragStart}
    />
  );
}
