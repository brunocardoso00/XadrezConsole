using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.Entities;

namespace xadrez_console.ChessGame
{
    class King : Piece
    {
        public King(Color color, ChessBoard chessBoard) : base(color, chessBoard)
        {

        }
   

        public override bool[,] MovimentValidate()
        {
            bool[,] matrix = new bool[this.chessBoard.Line, this.chessBoard.Column];
            Position position = this.position;
            int line=0, column=0;
            Position position_aux = new Position(0,0);
            //acima
            position_aux.DefinirValores(position.Line-1, position.Column);
            if (chessBoard.ValidatePosition(position_aux) && CanMove(position_aux)) {
                matrix[position_aux.Line, position_aux.Column] = true;
            }
            //ne 
            position_aux.DefinirValores(position.Line-1, position.Column+1);
            if (chessBoard.ValidatePosition(position_aux) && CanMove(position_aux))
            {
                matrix[position_aux.Line, position_aux.Column] = true;
            }
            //se
            position_aux.DefinirValores(position.Line+1, position.Column+1);
            if (chessBoard.ValidatePosition(position_aux) && CanMove(position_aux))
            {
                matrix[position_aux.Line, position_aux.Column] = true;
            }
            //abaixo
            position_aux.DefinirValores(position.Line+1, position.Column);
            if (chessBoard.ValidatePosition(position_aux) && CanMove(position_aux))
            {
                matrix[position_aux.Line, position_aux.Column] = true;
            }
            //no 
            position_aux.DefinirValores(position.Line + 1, position.Column - 1);
            if (chessBoard.ValidatePosition(position_aux) && CanMove(position_aux))
            {
                matrix[position_aux.Line, position_aux.Column] = true;
            }
            //so
            position_aux.DefinirValores(position.Line - 1, position.Column - 1);
            if (chessBoard.ValidatePosition(position_aux) && CanMove(position_aux))
            {
                matrix[position_aux.Line, position_aux.Column] = true;
            }
            //esq
            position_aux.DefinirValores(position.Line , position.Column - 1);
            if (chessBoard.ValidatePosition(position_aux) && CanMove(position_aux))
            {
                matrix[position_aux.Line, position_aux.Column] = true;
            }
            //dir
            position_aux.DefinirValores(position.Line , position.Column + 1);
            if (chessBoard.ValidatePosition(position_aux) && CanMove(position_aux))
            {
                matrix[position_aux.Line, position_aux.Column] = true;
            }





            return matrix;
        }
        private bool CanMove(Position position) {
            Piece piece = chessBoard.GetPiece(position);
            if (piece == null || piece.Color != this.Color)
                return true;
            else
                return false;

            
        }
        
        public override string ToString()
        {
            return "K";
        }
    }
}
