using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.Entities;


namespace xadrez_console.ChessGame
{
    class Bishop : Piece
    {
        public Bishop(Color color, ChessBoard chessBoard) : base(color, chessBoard)
        {

        }



        public override bool[,] MovimentValidate()
        {
            bool[,] matrix = new bool[8, 8];


            //mover-lo-émos em cateziano para a diagonal,
            //o incremento deve ser de x = (n e N ^ -1<n<8) <-> y=x (+/-)y
            Position aux = new Position(this.position.Line, this.position.Column);
            Position position = new Position(aux.Line - 1, aux.Column - 1);


            while (chessBoard.ValidatePosition(position) && CanMove(position))
            {
                if (chessBoard.GetPiece(position) != null && chessBoard.GetPiece(position).Color != this.Color)
                {
                    matrix[position.Line, position.Column] = true;
                    break;
                }
                matrix[position.Line--, position.Column--] = true;
            }

            aux = new Position(this.position.Line, this.position.Column);
            position = new Position(aux.Line + 1, aux.Column + 1);

            while (chessBoard.ValidatePosition(position) && CanMove(position))
            {
                if (chessBoard.GetPiece(position) != null && chessBoard.GetPiece(position).Color != this.Color)
                {
                    matrix[position.Line, position.Column] = true;
                    break;
                }
                matrix[position.Line++, position.Column++] = true;
            }


            aux = new Position(this.position.Line, this.position.Column);
            position = new Position(aux.Line + 1, aux.Column - 1);


            while (chessBoard.ValidatePosition(position) && CanMove(position))
            {
                if (chessBoard.GetPiece(position) != null && chessBoard.GetPiece(position).Color != this.Color)
                {
                    matrix[position.Line, position.Column] = true;
                    break;
                }

                matrix[position.Line++, position.Column--] = true;
            }


            aux = new Position(this.position.Line, this.position.Column);
            position = new Position(aux.Line - 1, aux.Column + 1);



            while (chessBoard.ValidatePosition(position) && CanMove(position))
            {
                if (chessBoard.GetPiece(position) != null && chessBoard.GetPiece(position).Color != this.Color)
                {
                    matrix[position.Line, position.Column] = true;
                    break;
                }
                matrix[position.Line--, position.Column++] = true;
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
            return "B";
        }

    }
}
