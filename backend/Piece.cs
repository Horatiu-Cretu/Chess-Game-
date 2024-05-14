using System;
using System.Collections.Generic;

namespace ChessBoard.Models
{
    public class Piece
    {
        public PieceType Type { get; set; }
        public string Color { get; set; }
        public (int Row,int Column) Position { get; set; }

        public List<(int Row, int Column)> PieceMove(Board board, int currentRow, int currentColumn)
        {
            List<(int Row, int Column)> possibleMoves = new List<(int Row, int Column)>();
            Piece piece = new Piece();
            piece = board.GetPieceAtPosition(currentRow, currentColumn);   
            if (piece == null)
            {
                //we clicked on an empty square
                return null;
            }
            if(piece.Type == PieceType.Pawn)
            {
                if (piece.Color == "black")
                {
                    if (board.GetPieceAtPosition(currentRow + 1, currentColumn) == null)
                        possibleMoves.Add((currentRow + 1, currentColumn));
                }
                else
                {
                    if (board.GetPieceAtPosition(currentRow - 1, currentColumn) == null)
                        possibleMoves.Add((currentRow - 1, currentColumn));
                }
            }
            else
            {
                switch (piece.Type)
                {
                    case PieceType.Rook:
                        {
                            //for a rook we verify first the positions it can move on the column 
                            int posRow = currentRow;
                            int posColumn = currentColumn;
                            while (board.GetPieceAtPosition(posRow + 1, posColumn) == null && posRow < 8 &&
                                posColumn < 8 && posRow >= 0 && posColumn >= 0)
                            {
                                possibleMoves.Add((posRow, posColumn));
                                posRow++;
                            }
                            posRow = currentRow - 1;
                            posColumn = currentColumn;
                            while (board.GetPieceAtPosition(posRow - 1, posColumn) == null && posRow < 8 &&
                                posColumn < 8 && posRow >= 0 && posColumn >= 0)
                            {
                                possibleMoves.Add((posRow, posColumn));
                                posRow--;
                            }

                            // and than we verify the positions it can go on the row
                            posRow = currentRow;
                            posColumn = currentColumn + 1;
                            while (board.GetPieceAtPosition(posRow, posColumn) == null && posRow < 8 &&
                                posColumn < 8 && posRow >= 0 && posColumn >= 0)
                            {
                                possibleMoves.Add((posRow, posColumn));
                                posColumn++;
                            }
                            posRow = currentRow;
                            posColumn = currentColumn - 1;
                            while (board.GetPieceAtPosition(posRow, posColumn) == null && posRow < 8 &&
                                posColumn < 8 && posRow >= 0 && posColumn >= 0)
                            {
                                possibleMoves.Add((posRow, posColumn));
                                posColumn--;
                            }
                            //we do this because the open road on the column may be longer that the one on
                            //the row and viceversa
                            break;
                        }
                    case PieceType.Knight:
                        {
                            //we are implementing the knight moves 
                            int[] positions1 = { -2, 2 };
                            int[] positions2 = { -1, 1 };
                            //theese two arrays will determine the possible positions of the knight in the chess game 
                            //if we add an number from the first array to a number from the second array we will
                            //get four positions of a knight, and by inversing them we will get all the positions 
                            //possible for the knight 
                            for (int i = 0; i < 2; i++)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    if ((board.GetPieceAtPosition(currentRow + positions1[i], currentColumn + positions2[j]) == null
                                        || board.GetPieceAtPosition(currentColumn + positions2[i], currentRow + positions1[j]) == null)
                                        && currentRow + positions1[i] < 8 && currentRow + positions1[i] >= 0 &&
                                        currentColumn + positions2[i] < 8 && currentColumn + positions2[i] >= 0)
                                    {
                                        possibleMoves.Add((currentRow + positions1[i], currentColumn + positions2[j]));
                                        possibleMoves.Add((currentColumn + positions2[j], currentRow + positions1[i]));
                                    }
                                }
                            }
                            break;
                        }
                    case PieceType.Bishop:
                        {
                            //we implement the possible moves for the Bishop
                            int posRow = currentRow;
                            int posColumn = currentColumn;
                            while (board.GetPieceAtPosition(posRow + 1, posColumn + 1) == null
                                && posRow + 1 < 8 && posRow + 1 >= 0 && posColumn + 1 < 8 &&
                                posColumn + 1 >= 0)
                            {
                                posRow++;
                                posColumn++;
                                possibleMoves.Add((posRow, posColumn));
                            }

                            posRow = currentRow;
                            posColumn = currentColumn;
                            while (board.GetPieceAtPosition(posRow - 1, posColumn - 1) == null
                                && posRow - 1 < 8 && posRow - 1 >= 0 && posColumn - 1 < 8 &&
                                posColumn - 1 >= 0)
                            {
                                posRow--;
                                posColumn--;
                                possibleMoves.Add((posRow, posColumn));
                            }

                            posRow = currentRow;
                            posColumn = currentColumn;
                            while (board.GetPieceAtPosition(posRow - 1, posColumn + 1) == null
                                && posRow - 1 < 8 && posRow - 1 >= 0 && posColumn + 1 < 8 &&
                                posColumn + 1 >= 0)
                            {
                                posRow--;
                                posColumn++;
                                possibleMoves.Add((posRow, posColumn));
                            }

                            posRow = currentRow;
                            posColumn = currentColumn;
                            while (board.GetPieceAtPosition(posRow + 1, posColumn - 1) == null
                                && posRow + 1 < 8 && posRow + 1 >= 0 && posColumn - 1 < 8 &&
                                posColumn - 1 >= 0)
                            {
                                posRow++;
                                posColumn--;
                                possibleMoves.Add((posRow, posColumn));
                            }
                            break;
                        }
                    case PieceType.Queen:
                        {
                            //for the queen we will combine the moves for the rook and the bishop

                            //for the rook
                            int posRow = currentRow + 1;
                            int posColumn = currentColumn;
                            while (board.GetPieceAtPosition(posRow, posColumn) == null && posRow < 8 &&
                                posColumn < 8 && posRow >= 0 && posColumn >= 0)
                            {
                                possibleMoves.Add((posRow, posColumn));
                                posRow++;
                            }

                            posRow = currentRow;
                            posColumn = currentColumn + 1;
                            while (board.GetPieceAtPosition(posRow, posColumn) == null && posRow < 8 &&
                                posColumn < 8 && posRow >= 0 && posColumn >= 0)
                            {
                                possibleMoves.Add((posRow, posColumn));
                                posColumn++;
                            }
                            //and for the bishop
                            posRow = currentRow;
                            posColumn = currentColumn;
                            while (board.GetPieceAtPosition(posRow + 1, posColumn + 1) == null
                                && posRow + 1 < 8 && posRow + 1 >= 0 && posColumn + 1 < 8 &&
                                posColumn + 1 >= 0)
                            {
                                posRow++;
                                posColumn++;
                                possibleMoves.Add((posRow, posColumn));
                            }

                            posRow = currentRow;
                            posColumn = currentColumn;
                            while (board.GetPieceAtPosition(posRow - 1, posColumn - 1) == null
                                && posRow - 1 < 8 && posRow - 1 >= 0 && posColumn - 1 < 8 &&
                                posColumn - 1 >= 0)
                            {
                                posRow--;
                                posColumn--;
                                possibleMoves.Add((posRow, posColumn));
                            }

                            posRow = currentRow;
                            posColumn = currentColumn;
                            while (board.GetPieceAtPosition(posRow - 1, posColumn + 1) == null
                                && posRow - 1 < 8 && posRow - 1 >= 0 && posColumn + 1 < 8 &&
                                posColumn + 1 >= 0)
                            {
                                posRow--;
                                posColumn++;
                                possibleMoves.Add((posRow, posColumn));
                            }

                            posRow = currentRow;
                            posColumn = currentColumn;
                            while (board.GetPieceAtPosition(posRow + 1, posColumn - 1) == null
                                && posRow + 1 < 8 && posRow + 1 >= 0 && posColumn - 1 < 8 &&
                                posColumn - 1 >= 0)
                            {
                                posRow++;
                                posColumn--;
                                possibleMoves.Add((posRow, posColumn));
                            }
                            break;
                        }
                    case PieceType.King:
                        {
                            int[] positions1 = { -1, 1 };
                            int[] positions2 = { -1, 1 };
                            for (int i = 0; i < 2; i++)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    if ((board.GetPieceAtPosition(currentRow + positions1[i], currentColumn + positions2[j]) == null
                                        || board.GetPieceAtPosition(currentColumn + positions2[i], currentRow + positions1[j]) == null)
                                        && currentRow + positions1[i] < 8 && currentRow + positions1[i] >= 0 &&
                                        currentColumn + positions2[i] < 8 && currentColumn + positions2[i] >= 0)
                                    {
                                        possibleMoves.Add((currentRow + positions1[i], currentColumn + positions2[j]));
                                        possibleMoves.Add((currentColumn + positions2[j], currentRow + positions1[i]));
                                    }
                                }
                            }
                            break;
                        }
                }
            }
            return possibleMoves;
        }
    }

   
}
