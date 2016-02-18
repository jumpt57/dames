using Dames.model;
using Dames.model.board;
using Dames.model.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dames.controller
{
    class BoardController
    {
        private Human Human;
        private Ia Ia;
        private Board Board;

        public BoardController()
        {
            Human = new Human();
            Ia = new Ia();
            Board = new Board();

            InitalizePons();
        }

        private void InitalizePons()
        {
            foreach (Square Square in Board.GetSquares())
            {
                if (Square.GetColored() && Square.GetRow() > 5)
                {
                    foreach (Pon Pon in Human.GetPons())
                    {
                        if (Pon.GetSquare() == null)
                        {
                            Pon.SetSquare(Square);
                            Square.SetPon(Pon);
                            break;
                        }
                        
                    }                   
                }
                else if (Square.GetColored() && Square.GetRow() < 4)
                {
                    foreach (Pon Pon in Ia.GetPons())
                    {
                        if (Pon.GetSquare() == null)
                        {
                            Pon.SetSquare(Square);
                            Square.SetPon(Pon);
                            break;
                        }

                    }
                }
            }
        }

        public Board GetBoard()
        {
            return this.Board;
        }

    }
}
