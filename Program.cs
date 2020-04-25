using System;
using xadrez_console.Entities;
using xadrez_console.ChessGame;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const byte boardChessDimension = 8;
                ChessBoard chessBoard = new ChessBoard(boardChessDimension, boardChessDimension);//cria o tabuleiro
                ChessBoard.OrganizeBoard(ref chessBoard); //coloca as peças 
                ChessMatch  match= new ChessMatch(chessBoard);// inicia os parametros de uma partida
                Queen cavalo = new Queen(Color.White, chessBoard);
                chessBoard.SetPiece(cavalo,new Position(3,4));


                do
                {
                    Console.Clear();
                    Screen.PrintBoard(chessBoard);
                    /*------------------------------------------------------------------*/
                    Console.WriteLine("\nInforme a Posição da Da Peça que deseja mover:");
                    String move = Console.ReadLine();
                    Console.WriteLine(" show "+move[1]+" "+ move[0]+" "+(int)move[0]);
                    PositionChess p1= new PositionChess(move);
                    Console.Clear();
                    bool[,] mat = chessBoard.GetPiece(match.ConvertPosition(p1)).MovimentValidate();
                    Screen.PrintBoard(chessBoard, mat);
                    /*------------------------------------------------------------------*/
                    Console.WriteLine("\nPara onde deseja mover:");
                    string set_piece = Console.ReadLine();
                    match.MovePiece(new PositionChess(move), new PositionChess(set_piece));
                    Console.ReadKey();

                } while (!match.Winner);
            }
            catch (BoardException e) {
                Console.WriteLine(e);
            }


            /*principais desafios de implementar o jogo de xadrez , refatorar modificações com forme a necessidade
             -->movimentos especiais EN PASSENT, ROQUE
             -->jogadas especiais CHEQUE, CHEQUE MATE
             -->Movimento e captura do Peão, e movimentos de não cheque do Rei
             */
             //AO FINALIZAR ESTE PROJETO SERÁ TOTALMENTE REFATORADO
             /*será aplicado o SOLID, e posteriormente uma IA, que trabalharei separadamente
              --> provavelmente em algoritimo genetico 
              --> investigar qual a melhor IA para este caso, divergente do tic tac toe, a valiação do xadres
              variando das jogadas possiveis e validas é de (~e^120) então uma implementação de IA Burra está fora de
              cogitação
              
            
             --> as classes foram geradas sem um previo planejamento, por tanto podem conter metodos não muito pertinentes
              ao escopo ideal da classe, e por sua vez quebrando o conceito SRP.


              */
        }
    }
}
