using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Dames.model.board;

namespace Dames.model.player
{
    class Human : Player
    {
        public Human()
        {
            this.Color = Brushes.SaddleBrown;
            this.CreatePons();
            this.Ia = false;
        }

        public override bool PossibleMovements(Board board, Square Square)
        {
            bool possible = false;
            bool reset = false;
            bool left = false;
            for (int i = Square.GetColumn() - 1; i <= Square.GetColumn() + 1; i++)
            {
                var SquareTMP = board.SquareAt(i, Square.GetRow() - 1);

                if (SquareTMP != null && !SquareTMP.GetColored()) continue;
                left = !left;

                if (!reset)
                {
                    board.ResetSelectedSquares();
                    reset = true;
                }

                if (SquareTMP.GetPon() == null)
                {
                    SquareTMP.IsHovered();
                    possible = true;                                 
                }
                else if (SquareTMP.GetPon() != null && SquareTMP.GetPon().GetPlayer().GetIa())
                {
                    Square SquareTMPPlus1 = null;
                    if (left)
                    {
                        SquareTMPPlus1 = board.SquareAt(i - 1, Square.GetRow() - 2);
                    }
                    else
                    {
                        SquareTMPPlus1 = board.SquareAt(i + 1, Square.GetRow() + 2);
                    }

                    if (SquareTMPPlus1 != null && SquareTMPPlus1.GetPon() == null)
                    {
                        SquareTMP.IsPossibleManger();
                        possible = true;
                    }               
                }

            }
            return possible;
        }
        
    }
}
