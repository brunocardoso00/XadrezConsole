using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.Entities;

namespace xadrez_console.ChessGame
{
    class PositionChess
    {

        Position position;
        public char Column { get; private set; }
        public int Line { get; private set; }
         public PositionChess(char column, int line)
        {
            Column = column;
            Line = line;
        }
        public PositionChess(string position) {
            try
            {
                if (position.Length == 2) {
                    Column = (char)position[0];
                    Line = int.Parse(position[1].ToString());
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
        


    }
}
