using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.Entities;

namespace xadrez_console.ChessGame
{
    class Knight : Piece
    {
        public Knight(Color color, ChessBoard chessBoard) : base(color, chessBoard)
        {

        }

        public override bool[,] MovimentValidate()
        {
            bool[,] matrix = new bool[8, 8];
            Position position = new Position(this.position.Line, this.position.Column);
            Position aux = new Position(this.position.Line, this.position.Column);


            position.Line -= 2;
            position.Column--;

            if (CanMove(position) && chessBoard.ValidatePosition(position))
            {
                matrix[
                position.Line,
                position.Column] = true;
            }

            position = new Position(this.position.Line, this.position.Column);
            position.Line -= 2;
            position.Column += 1;


            if (CanMove(position) && chessBoard.ValidatePosition(position))
            {
                matrix[
                position.Line,
                position.Column] = true;
            }
            position = new Position(this.position.Line, this.position.Column);
            position.Line -= 1;
            position.Column += 2;


            if (CanMove(position) && chessBoard.ValidatePosition(position))
            {
                matrix[
                position.Line,
                position.Column] = true;
            }
            position = new Position(this.position.Line, this.position.Column);
            position.Line += 1;
            position.Column += 2;


            if (CanMove(position) && chessBoard.ValidatePosition(position))
            {
                matrix[
                position.Line,
                position.Column] = true;
            }
            position = new Position(this.position.Line, this.position.Column);
            position.Line += 2;
            position.Column += 1;


            if (CanMove(position) && chessBoard.ValidatePosition(position))
            {
                matrix[
                position.Line,
                position.Column] = true;
            }
            position = new Position(this.position.Line, this.position.Column);
            position.Line += 2;
            position.Column -= 1;


            if (CanMove(position) && chessBoard.ValidatePosition(position))
            {
                matrix[
                position.Line,
                position.Column] = true;
            }
            position = new Position(this.position.Line, this.position.Column);
            position.Line += 1;
            position.Column -= 2;


            if (CanMove(position) && chessBoard.ValidatePosition(position))
            {
                matrix[
                position.Line,
                position.Column] = true;
            }
            position = new Position(this.position.Line, this.position.Column);
            position.Line -= 1;
            position.Column -= 2;


            if (CanMove(position) && chessBoard.ValidatePosition(position))
            {
                matrix[
                position.Line,
                position.Column] = true;
            }


            return matrix;

        }
        private bool CanMove(Position position)
        {
            Piece piece = chessBoard.GetPiece(position);
            if (piece == null || piece.Color != this.Color)
                return true;
            else
                return false;


        }

        public override string ToString()
        {
            return "N";
        }
    }
}
