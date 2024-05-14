using System;
using System.Collections.Generic;

namespace ChessBoard.Models
{
    public class Board
    {
        private Piece[,] _board;

        public Board()
        {
            _board = new Piece[8, 8];
            InitializeBoard();
        }

        public void PlacePiece(Piece piece, int row, int column)
        {
            piece.Position = (row, column);
            _board[row, column] = piece;
        }

        public Piece GetPieceAtPosition(int row, int column)
        {
            return _board[row, column];
        }

        public bool MovePiece(int sourceRow, int sourceColumn, int destinationRow, int destinationColumn)
        {
            // Check if the source and destination coordinates are valid
            if (!AreCoordinatesValid(sourceRow, sourceColumn) || !AreCoordinatesValid(destinationRow, destinationColumn))
            {
                return false;
            }

            // Retrieve the piece at the source coordinates
            Piece pieceToMove = _board[sourceRow, sourceColumn];

            // Check if there is a piece at the source coordinates
            if (pieceToMove == null)
            {
                return false;
            }

            // Remove the piece from the source coordinates
            _board[sourceRow, sourceColumn] = null;

            // Place the piece at the destination coordinates
            _board[destinationRow, destinationColumn] = pieceToMove;

            // Update the piece's position
            pieceToMove.Position = (destinationRow, destinationColumn);

            return true;
        }

        private bool AreCoordinatesValid(int row, int column)
        {
            return row >= 0 && row < 8 && column >= 0 && column < 8;
        }

        private void InitializeBoard()
        {
            // Initialize pieces for both players
            // Black pieces
            _board[0, 0] = new Piece { Type = PieceType.Rook, Color = "black" };
            _board[0, 1] = new Piece { Type = PieceType.Knight, Color = "black" };
            _board[0, 2] = new Piece { Type = PieceType.Bishop, Color = "black" };
            _board[0, 3] = new Piece { Type = PieceType.Queen, Color = "black" };
            _board[0, 4] = new Piece { Type = PieceType.King, Color = "black" };
            _board[0, 5] = new Piece { Type = PieceType.Bishop, Color = "black" };
            _board[0, 6] = new Piece { Type = PieceType.Knight, Color = "black" };
            _board[0, 7] = new Piece { Type = PieceType.Rook, Color = "black" };
            for(int i = 0; i < 7; i++)
            {
                _board[1, i] = new Piece { Type = PieceType.Pawn, Color = "black" };
            }

            // white pieces
            _board[7, 0] = new Piece { Type = PieceType.Rook, Color = "white" };
            _board[7, 1] = new Piece { Type = PieceType.Knight, Color = "white" };
            _board[7, 2] = new Piece { Type = PieceType.Bishop, Color = "white" };
            _board[7, 3] = new Piece { Type = PieceType.Queen, Color = "white" };
            _board[7, 4] = new Piece { Type = PieceType.King, Color = "white" };
            _board[7, 5] = new Piece { Type = PieceType.Bishop, Color = "white" };
            _board[7, 6] = new Piece { Type = PieceType.Knight, Color = "white" };
            _board[7, 7] = new Piece { Type = PieceType.Rook, Color = "white" };
            for (int i = 0; i < 7; i++)
            {
                _board[6, i] = new Piece { Type = PieceType.Pawn, Color = "white" };
            }
        }

        public List<List<Piece>> BoardStatus()
        {
            // Convert the 2D array of pieces into a list of lists for easier handling in the frontend
            List<List<Piece>> boardState = new List<List<Piece>>();
            for (int i = 0; i < 8; i++)
            {
                List<Piece> row = new List<Piece>();
                for (int j = 0; j < 8; j++)
                {
                    row.Add(_board[i, j]);
                }
                boardState.Add(row);
            }
            return boardState;
        }
    }
}
