using Dames.model.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dames.model.board
{
    class Board
    {
        private static int LENGTH_GRID = 10;

        private List<Square> Squares;

        public Board()
        {
            Squares = new List<Square>(100);
            InitalizeSquares();
        }

        public void InitalizeSquares()
        {
            for (int i = 0; i < LENGTH_GRID; i++)
            {
                for (int j = 0; j < LENGTH_GRID; j++)
                {
                    Square square = new Square(j, i, this);
                    this.Squares.Add(square);
                }
                Square.OffsetColor();
            }
        }

        public List<Square> GetSquares()
        {
            return this.Squares;
        }

        public bool PossibleToMove(Square Square)
        {            
            bool possible = false;
            bool reset = false;
            for (int i = Square.GetColumn() - 1; i <= Square.GetColumn() + 1; i++)
            {
                var SquareTMP = this.SquareAt(i, Square.GetRow() - 1);
                if (SquareTMP != null && SquareTMP.GetColored() && SquareTMP.GetPon() == null)
                {                    
                    if (!reset)
                    {
                        this.ResetSelectedSquares();
                        reset = true;
                    }
                    SquareTMP.Select();
                    possible = true;  
                }
            }            
            return possible;
        }

        private Square SquareAt(int column, int row)
        {            
            foreach (Square Square in Squares)
            {
                if (Square.GetColumn() == column && Square.GetRow() == row)
                {
                    return Square;
                }
            }
            return null;
        }

        public void ResetSelectedSquares()
        {
            foreach (Square Square in Squares)
            {
                if (Square.GetSelected())
                {
                    Square.Deselect();
                }
                
            }
        }
    }
}
