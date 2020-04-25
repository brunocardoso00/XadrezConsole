using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.ChessGame;
using xadrez_console.Entities;

namespace xadrez_console.ChessGame
{
    class ChessMatch
    {
        private ChessBoard chessBoard;
        private int turno;
        private Color player;
        const int dimension = 8;
        public bool Winner { get; private set; }

        public ChessMatch(ChessBoard chessBoard)
        {
            this.chessBoard = chessBoard;
            player = Color.White;
            turno = 0;
            Winner = false;
        }
        public void MovePiece(PositionChess startPosition, PositionChess endPosition)
        {

            var piece = (Piece)chessBoard.GetPiece(ConvertPosition(startPosition));
            if (ExistMove(ConvertPosition(startPosition)))
            {
                Position _Position = ConvertPosition(endPosition);



                if (ValidateColorPiece(piece))
                {

                    bool[,] matrix = chessBoard.GetPiece(ConvertPosition(startPosition)).MovimentValidate();
                    if (matrix[_Position.Line, _Position.Column])
                    {
                        TakePiece(_Position);//se capitura iremos remover a peça antes de colocarmos a peça para a posição
                        chessBoard.RemovePiece(ConvertPosition(startPosition));
                        chessBoard.SetPiece(piece, ConvertPosition(endPosition));
                        Console.WriteLine(ConvertPosition(startPosition).Line + " " + ConvertPosition(startPosition).Column);
                        Console.WriteLine(ConvertPosition(endPosition).Line + " " + ConvertPosition(endPosition).Column);
                        this.turno++;
                    }
                    else {

                        Console.WriteLine("Não é uma posição de jogada valida, seleciona uma das casas em destaque");
                    }


                   


                }
                else
                {
                    Console.WriteLine(turno + "A peça é do adversario : " + piece.Color.ToString());

                }
            }
            else {
                Console.WriteLine("Não é possivel mover está peça.");
            }


        }
        public bool ExistMove(Position position) {

            bool [,] vet=chessBoard.GetPiece(position).MovimentValidate();
            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++) {
                    if (vet[i, j] == true)
                        return true;
                    

                }
            }
            return false;
        }
        public Position ConvertPosition(PositionChess positionChess)
        {
            int aux = 0;
            int aux1 = 0;
            switch ((int)positionChess.Column)
            {
                //dá para substituir este case por (int)char - 65, apenas verificar neste caso se o valor gerado esta dentro dos parametros com o validate
                case 65://A
                    aux = 0;
                    break;
                case 66://B 
                    aux = 1;
                    break;
                case 67://C
                    aux = 2;
                    break;
                case 68://D
                    aux = 3;
                    break;
                case 69://E
                    aux = 4;
                    break;
                case 70://F
                    aux = 5;
                    break;
                case 71://G
                    aux = 6;
                    break;
                case 72://H
                    aux = 7;
                    break;
                default:
                    throw new BoardException("Error Convert move" + aux + " " + aux1);
                    break;

            }
            //o mesmo pode ser feito para a inversão do valor referece a subtração do elemento maximo e o elemento informado, vendo neste aspecto 
            // tal metodo não neceria nem mesmo necessario.
            switch (positionChess.Line)
            {
                case 8:
                    aux1 = 0;
                    break;
                case 7:
                    aux1 = 1;
                    break;
                case 6:
                    aux1 = 2;
                    break;
                case 5:
                    aux1 = 3;
                    break;
                case 4:
                    aux1 = 4;
                    break;
                case 3:
                    aux1 = 5;
                    break;
                case 2:
                    aux1 = 6;
                    break;
                case 1:
                    aux1 = 7;
                    break;
                default:
                    throw new BoardException("Error Convert move" + aux +" "+aux1);
                    break;


            }

            return chessBoard.ValidatePosition(new Position(aux1, aux)) ? new Position(aux1, aux) : null;




        }

        public bool ValidateColorPiece(Piece piece)
        {
            //retorna booleano validado se a peça coincide com o turno existe para suprir ,move e captura
            if (this.turno % 2 == 0)
            {//sempre que par é vez das Brancas
                return piece.Color == Color.White;
            }
            else
            {
                return piece.Color == Color.Black;
            }

        }
        public void TakePiece(Position position) {

            if (chessBoard.GetPiece(position)!=null) {
                /*não validaremos a cor pois isso já é validado no metodo de movimento como a peça
                 * não pode se mover para casas populadas por peças alidas a validação não se faz necessaria
                 há apenas uma exceção, que refere-se ao movimeto de EN PASSE, e a captura do peão que tem 
                 movimetos de captura diferente de seus respectivos movimentos de avanço*/
                
                Console.WriteLine(chessBoard.GetPiece(position).ToString()+" Capiturado \a");
                chessBoard.RemovePiece(position);
            }

        }


    }
}
