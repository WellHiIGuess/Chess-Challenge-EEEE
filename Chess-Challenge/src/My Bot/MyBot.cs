using System;
using ChessChallenge.API;

public class MyBot : IChessBot
{
    public Move Think(Board board, Timer timer)
    {
        Move[] moves = board.GetLegalMoves();

        foreach (Move i in moves)
        {
            // Captures pieces that are of more value or pawns
            if (i.IsCapture && (i.CapturePieceType >= i.MovePieceType || i.CapturePieceType == PieceType.Pawn))
            {
                return i;
            }
            // Castles
            if (i.IsCastles)
            {
                return i;
            }
            // Captures pieces or same value
            if (i.CapturePieceType == i.MovePieceType)
            {
                return i;
            }
            // Makes it so that pawn in the middle of the board will forward 2 squares
            if (i.MovePieceType == PieceType.Pawn && i.StartSquare.File > 1 && i.StartSquare.File < 6 && i.TargetSquare.Rank < 5)
            {
                return i;
            }
        }

        Random rnd = new Random();
        int number = rnd.Next(0, moves.Length);
        return moves[number];
    }
}