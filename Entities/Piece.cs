using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.Entities
{
    abstract class Piece
    {


        public Color Color { get; protected set; }
        public Position position { get; set; }
        public int MoveQuantity { get; protected set; }
        public ChessBoard chessBoard { get; protected set; }
       
        public Piece(Color color, ChessBoard chessBoard)
        {
            this.Color = color;
            this.position = null;
            MoveQuantity = 0;
            this.chessBoard = chessBoard;
        }
        public Piece() { }
        public void SetColor(Color color)
        {
            this.Color = (Color)color;

        }
        public override string ToString()
        {
            return "" + this.Color;
        }
        
        public abstract bool[,] MovimentValidate();

    }
}
