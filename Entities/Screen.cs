using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.ChessGame;

namespace xadrez_console.Entities
{
    class Screen
    {

        public static void PrintBoard(ChessBoard chessBoard)
        {
           
            int aux=8;
            Console.WriteLine("\n\n");

            for (int i = 0; i < chessBoard.Line; i++) {
                Screen.RestoreColor();
                Console.Write("\t\t\t\t\t"+aux--+" ");
                for (int j = 0; j < chessBoard.Column; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Screen.ChessColorBoard(i,j);
                    if (chessBoard.GetPiece(i, j) == null)
                        Console.Write(" " + "  ");
                    else
                    {

                        if (chessBoard.GetPiece(i, j).Color == Color.Black)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" " + chessBoard.GetPiece(i, j) + " ");
                            
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(" " + chessBoard.GetPiece(i, j) + " ");
                           
                        }
                    }
                }
                Console.WriteLine();
            }
            Screen.RestoreColor();
            aux = 65;
            Console.Write("\t\t\t\t\t  ");
            for (int i = aux; i < 73; i++)
                Console.Write(" " + (char)i + " ");
            



        }
        public static void PrintBoard(ChessBoard chessBoard,bool [,] moves)
        {

            int aux = 8;
            Console.WriteLine("\n\n");

            for (int i = 0; i < chessBoard.Line; i++)
            {
                Screen.RestoreColor();
                Console.Write("\t\t\t\t\t" + aux-- + " ");
                for (int j = 0; j < chessBoard.Column; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Screen.ChessColorBoard(i, j);
                    if (moves[i, j] == true && ((i+j)%2)==1)
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    else if (moves[i, j] == true && ((i + j) % 2) == 0)
                        Console.BackgroundColor = ConsoleColor.Blue;

                    if (chessBoard.GetPiece(i, j) == null)
                        Console.Write(" " + "  ");
                    else
                    {

                        if (chessBoard.GetPiece(i, j).Color == Color.Black)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" " + chessBoard.GetPiece(i, j) + " ");

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(" " + chessBoard.GetPiece(i, j) + " ");

                        }
                       
                    }
                  
                }
                Console.WriteLine();
            }
            Screen.RestoreColor();
            aux = 65;
            Console.Write("\t\t\t\t\t  ");
            for (int i = aux; i < 73; i++)
                Console.Write(" " + (char)i + " ");




        }



        private static void ChessColorBoard(int x, int y) {
            if ((x + y) % 2 == 0)
                Console.BackgroundColor = ConsoleColor.White;
            else
                Console.BackgroundColor = ConsoleColor.Gray;

        }
        private static void RestoreColor() {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static PositionChess getMoviment(ChessMatch match,ChessBoard chessBoard){
            string move = "  ";
            Console.WriteLine("\nInforme a Posição da Da Peça que deseja mover:");
             move = Console.ReadLine();
            return new PositionChess(move);
        }
        
    }
}
