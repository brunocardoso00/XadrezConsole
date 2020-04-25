using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.Entities;

namespace xadrez_console.ChessGame
{
    class Pawn : Piece
    {
        public Pawn(Color color, ChessBoard chessBoard) : base(color, chessBoard) {

        }



        public override bool[,] MovimentValidate()
        {

            /*valida a cor de o turno e a posição do peão pois pode mover duas casas no inicio da partida*/
            bool[,] matrix = new bool[8, 8];
            Position position = this.position;
            Position aux_position = new Position(0, 0);
            int a=0;
            do {

                
               if ((position.Line + 1 == aux_position.Line && this.Color == Color.Black) || (position.Line - 1 == aux_position.Line && this.Color == Color.White) )
                {
                    
                    matrix[this.Color == Color.White ? position.Line - 1 : position.Line + 1, position.Column] = true;
                }else if ((this.Color == Color.Black && this.position.Line == 1 && aux_position.Line == this.position.Line) || (this.Color == Color.White && this.position.Line == 6 && aux_position.Line == this.position.Line))
                {
                    a = aux_position.Line == 6 ? aux_position.Line - 2 : aux_position.Line + 2;
                    matrix[a, this.position.Column] = true;
                }
                aux_position.Line++;
                aux_position.Column++;
            } while (chessBoard.ValidatePosition(aux_position));
            return matrix;
        }
        public bool CanMove(Position position) {

            Piece piece = chessBoard.GetPiece(position);
            if (piece == null || piece.Color != this.Color)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
