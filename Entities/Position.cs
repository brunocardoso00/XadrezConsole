using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.ChessGame;

namespace xadrez_console.Entities
{
    class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return "Line: " + Line + "Column: " + Column;
        }
        public void DefinirValores(int x, int y)
        {
            Line = x;
            Column = y;

        }

    }
}
