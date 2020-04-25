using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.Entities;

namespace xadrez_console.ChessGame
{
    class Queen : Piece
    {
        public Queen(Color color,ChessBoard chessBoard) : base(color,chessBoard) {

        }

        public override bool[,] MovimentValidate()
        {
            bool[,] matrix = new bool[8,8];

            Position position = new Position(0,0);
            position = this.position;
            Position auxiliar = new Position(this.position.Line-1,this.position.Column);


            //mover-la-émos em linha reta 
            while (CanMove(auxiliar) && chessBoard.ValidatePosition(auxiliar))
            {
               
                matrix[auxiliar.Line, auxiliar.Column] = true;
                if (chessBoard.GetPiece(auxiliar) != null && chessBoard.GetPiece(auxiliar).Color != this.Color || auxiliar.Line == 0)
                {
                    break;
                }

                auxiliar.Line--;
            }

            auxiliar.Line = position.Line + 1;
            auxiliar.Column = position.Column;


            while (CanMove(auxiliar) && chessBoard.ValidatePosition(auxiliar))
            {

                matrix[auxiliar.Line, auxiliar.Column] = true;
                if (chessBoard.GetPiece(auxiliar) != null && chessBoard.GetPiece(auxiliar).Color != this.Color || auxiliar.Line == 7)
                {
                    break;
                }
                auxiliar.Line++;
            }

            auxiliar.Line = position.Line;
            auxiliar.Column = position.Column + 1;


            while (CanMove(auxiliar) && chessBoard.ValidatePosition(auxiliar))
            {

                matrix[auxiliar.Line, auxiliar.Column] = true;
                if (chessBoard.GetPiece(auxiliar) != null && chessBoard.GetPiece(auxiliar).Color != this.Color || auxiliar.Column == 7)
                {
                    break;
                }
                auxiliar.Column++;
            }
            auxiliar.Line = position.Line;
            auxiliar.Column = position.Column - 1;


            while (CanMove(auxiliar) && chessBoard.ValidatePosition(auxiliar))
            {

                matrix[auxiliar.Line, auxiliar.Column] = true;
                if (chessBoard.GetPiece(auxiliar) != null && chessBoard.GetPiece(auxiliar).Color != this.Color || auxiliar.Column == 0)
                {
                    break;
                }
                auxiliar.Column--;
            }
            //mover-la-émos na diagonal
            auxiliar = new Position(this.position.Line, this.position.Column);
            position = new Position(auxiliar.Line - 1, auxiliar.Column - 1);
            while (chessBoard.ValidatePosition(position) && CanMove(position))
            {
                if (chessBoard.GetPiece(position) != null && chessBoard.GetPiece(position).Color != this.Color)
                {
                    matrix[position.Line, position.Column] = true;
                    break;
                }
                matrix[position.Line--, position.Column--] = true;
            }

            auxiliar = new Position(this.position.Line, this.position.Column);
            position = new Position(auxiliar.Line + 1, auxiliar.Column + 1);

            while (chessBoard.ValidatePosition(position) && CanMove(position))
            {
                if (chessBoard.GetPiece(position) != null && chessBoard.GetPiece(position).Color != this.Color)
                {
                    matrix[position.Line, position.Column] = true;
                    break;
                }
                matrix[position.Line++, position.Column++] = true;
            }


            auxiliar = new Position(this.position.Line, this.position.Column);
            position = new Position(auxiliar.Line + 1, auxiliar.Column - 1);


            while (chessBoard.ValidatePosition(position) && CanMove(position))
            {
                if (chessBoard.GetPiece(position) != null && chessBoard.GetPiece(position).Color != this.Color)
                {
                    matrix[position.Line, position.Column] = true;
                    break;
                }

                matrix[position.Line++, position.Column--] = true;
            }


            auxiliar = new Position(this.position.Line, this.position.Column);
            position = new Position(auxiliar.Line - 1, auxiliar.Column + 1);



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

        public override string ToString()
        {
            return "Q";
        }
        private bool CanMove(Position position)
        {
            Piece piece = chessBoard.GetPiece(position);
            if (piece == null || piece.Color != this.Color)
                return true;
            else
                return false;

        }
    }
}
