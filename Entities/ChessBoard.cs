using System;
using System.Collections.Generic;
using System.Text;
using xadrez_console.ChessGame;

namespace xadrez_console.Entities
{
    class ChessBoard
    {
        public int Line { get; set; }
        public int Column { get; set; }
        private Piece[,] pieces;
        public List<Piece> removed = new List<Piece>();

        public ChessBoard(int line, int column)
        {
            Line = line;
            Column = column;
            pieces = new Piece[line, column];
        }
        public Piece GetPiece(int line, int column)
        {
            return pieces[line, column];

        }
        public Piece GetPiece(Position position) {

            if (ValidatePosition(position))
            {
                var auxiliar = pieces[position.Line, position.Column];
                return auxiliar;
            }
            else {
                return null;
            }
            
        }
        public bool ExistPiece(Position position)
        {

            if (!ValidatePosition(position))
                return (GetPiece(position.Line, position.Column)) == null ? false : true;
            else
                return false;
        }
        public void SetPiece(Piece piece, Position position)
        {

            pieces[position.Line, position.Column] = piece;
            piece.position = position;
        }
        public static void OrganizeBoard(ref ChessBoard chessBoard)
        {
            Color color;
            for (int i = 0; i < chessBoard.Line; i++)
            {
                for (int j = 0; j < chessBoard.Column; j++)
                {
                    if ((i == 0 && j == 0) || (i == 0 && j == 7) || (i == 7 && j == 7) || (i == 7 && j == 0))
                    {

                        color = i > 2 ? Color.White : Color.Black;
                        Piece rook = new Rook(color, chessBoard);
                        chessBoard.SetPiece(rook, new Position(i, j));

                    }
                    else
                    if ((i == 0 && j == 1) || (i == 0 && j == 6) || (i == 7 && j == 6) || (i == 7 && j == 1))
                    {
                        color = i > 2 ? Color.White : Color.Black;
                        Piece knight = new Knight(color, chessBoard);
                        chessBoard.SetPiece(knight, new Position(i, j));
                    }
                    else
                    if ((i == 0 && j == 2) || (i == 0 && j == 5) || (i == 7 && j == 5) || (i == 7 && j == 2))
                    {
                        color = i > 2 ? Color.White : Color.Black;
                        Piece bishop = new Bishop(color, chessBoard);
                        chessBoard.SetPiece(bishop, new Position(i, j));
                    }
                    else
                    if ((i == 0 && j == 3) || (i == 7 && j == 3))
                    {
                        color = i > 2 ? Color.White : Color.Black;
                        Piece queen = new Queen(color, chessBoard);
                        chessBoard.SetPiece(queen, new Position(i, j));
                    }
                    else
                    if ((i == 0 && j == 4) || (i == 7 && j == 4))
                    {
                        color = i > 2 ? Color.White : Color.Black;
                        Piece king = new King(color, chessBoard);
                        chessBoard.SetPiece(king, new Position(i, j));

                    }
                    else
                    if (i == 1 || i == 6)
                    {
                        color = i > 5 ? Color.White : Color.Black;
                        Piece pawn = new Pawn(color, chessBoard);
                        chessBoard.SetPiece(pawn, new Position(i, j));

                    }

                }

            }

        }
        public bool ValidatePosition(Position position)
        {
            return !(position.Line < 0 || position.Column > 7 || position.Column < 0 || position.Line > 7);
        }
        public void ValidatedPosition(Position position) {
            if (!ValidatePosition(position)) {//valido


            } else {
                throw new BoardException("Error position, try again");
                    }
        }
        public Piece RemovePiece(Position position)
        {

            if (GetPiece(position) != null)
            {
                removed.Add((Piece)GetPiece(position));
                Piece aux = (Piece)GetPiece(position);
                aux.position = null;
                pieces[position.Line, position.Column] = null;
                return aux;
            }
            else { 
                return null;
        }
        }

        

    }

}
