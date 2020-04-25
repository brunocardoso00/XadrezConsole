using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez_console.Entities
{
    class BoardException : ApplicationException
    {
        public BoardException(string message) :base(message){
            
        }

    }
}
