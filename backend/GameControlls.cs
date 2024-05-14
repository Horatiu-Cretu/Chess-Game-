
using ChessBoard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ChessBoard.Models;
using ChessBoard.Controllers;

namespace ChessBoard.Controllers
{
    public class GameControlls
    {

        [Route("api/[controller")]
        [ApiController]
        public class GameController : ControllerBase
        {
            private readonly Board _board;

            public GameController( )
            {
                _board = new Board();  
            }
            
            //Endpoint to receive click position from frontend 
            [HttpPost("click")]
            public ActionResult<List<(int, int)>> HandleClubClick(PositionDTO clickPosition) 
            {
                var piece = new Piece();
                //extract position from DTO 
                int row = clickPosition.Row;
                int column = clickPosition.Column;

                // Get valid moves for clicked position
                List<(int,int)> validMoves = piece.PieceMove(_board,row,column);

                //return valid moves to the frontend
                return Ok(validMoves);
            }

            [HttpPost("move")]
            public ActionResult<string> HandleMove(MoveDTO moveInfo)
            {
                var board = new Board();
                //extract information from the DTO
                int fromRow = moveInfo.FromRow;
                int toRow = moveInfo.ToRow;
                int fromColumn = moveInfo.FromColumn;
                int toColumn = moveInfo.ToColumn;

                // Perform move on board 
                board.MovePiece(fromRow,fromColumn, toRow, toColumn);

                return Ok("Move made");
            }
        }
    }
}
public class PositionDTO
{
    public int Row { get; set; }
    public int Column { get; set; }
}

public class MoveDTO
{
    public int FromRow { get; set; }
    public int FromColumn { get; set; }
    public int ToRow { get; set; }
    public int ToColumn { get; set; }
}
