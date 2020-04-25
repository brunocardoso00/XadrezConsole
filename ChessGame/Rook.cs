using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.Entities;

namespace xadrez_console.ChessGame
{
    class Rook : Piece
    {
        public Rook(Color color,ChessBoard chessBoard) : base(color,chessBoard) {

        }

        public override bool[,] MovimentValidate()
        {
            bool[,] matrix = new bool[8, 8];
            Position position = this.position;
            Position aux_position = new Position(0, 0);
            aux_position.Line = position.Line - 1;
            aux_position.Column = position.Column;


            while (CanMove(aux_position) && chessBoard.ValidatePosition(aux_position)) {
                
                matrix[aux_position.Line, aux_position.Column] = true;
                if (chessBoard.GetPiece(aux_position) != null && chessBoard.GetPiece(aux_position).Color != this.Color || aux_position.Line==0)
                {
                    break;
                }
                
                aux_position.Line--;
    }

            aux_position.Line = position.Line + 1;
            aux_position.Column = position.Column;


            while (CanMove(aux_position) && chessBoard.ValidatePosition(aux_position) )
            {

                matrix[aux_position.Line, aux_position.Column] = true;
                if (chessBoard.GetPiece(aux_position) != null && chessBoard.GetPiece(aux_position).Color != this.Color || aux_position.Line == 7)
                {
                    break;
                }
                aux_position.Line++;
            }

            aux_position.Line = position.Line;
            aux_position.Column = position.Column+1;


            while (CanMove(aux_position) && chessBoard.ValidatePosition(aux_position))
            {

                matrix[aux_position.Line, aux_position.Column] = true;
                if (chessBoard.GetPiece(aux_position) != null && chessBoard.GetPiece(aux_position).Color != this.Color || aux_position.Column == 7)
                {
                    break;
                }
                aux_position.Column++;
            }
            aux_position.Line = position.Line;
            aux_position.Column = position.Column-1;


            while (CanMove(aux_position) && chessBoard.ValidatePosition(aux_position))
            {

                matrix[aux_position.Line, aux_position.Column] = true;
                if (chessBoard.GetPiece(aux_position) != null && chessBoard.GetPiece(aux_position).Color != this.Color || aux_position.Column == 0)
                {
                    break;
                }
                aux_position.Column--;
            }

            return matrix;
        }
        private bool CanMove(Position position)
        {
            Piece piece = chessBoard.GetPiece(position);
            return (piece == null || piece.Color != this.Color);
                


        }

        public override string ToString()
        {
            return "R";
        }
    }
}
