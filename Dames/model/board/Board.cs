using Dames.model.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dames.model.board
{
    class Board
    {
        private static int LENGTH_GRID = 10;

        private List<Square> Squares;

        public Board(Human Human, Ia Ia)
        {
            Squares = new List<Square>(100);
            InitalizeSquares();
            InitalizePonsIa(Ia);
            InitalizePonsHuman(Human);
        }

        private void InitalizePonsHuman(Human human)
        {
            foreach (Square square in Squares)
            {
                if (square.GetColored() && square.GetRow() > 6)
                {
                    Pon pon = new Pon(human);
                    pon.SetColor(Human.Color);
                    square.SetPon(pon);
                    human.AddPon(pon);
                }
            }
        }

        private void InitalizePonsIa(Ia ia)
        {
            foreach (Square square in Squares)
            {
                if (square.GetColored() && square.GetRow() < 3)
                {
                    Pon pon = new Pon(ia);
                    pon.SetColor(Ia.Color);
                    square.SetPon(pon);
                    ia.AddPon(pon);
                }
            }
        }

        public void InitalizeSquares()
        {
            for (int i = 0; i < LENGTH_GRID; i++)
            {
                for (int j = 0; j < LENGTH_GRID; j++)
                {
                    Square square = new Square(j, i);
                    this.Squares.Add(square);
                }
                Square.OffsetColor();
            }
        }

        public List<Square> GetSquares()
        {
            return this.Squares;
        }
    }
}
