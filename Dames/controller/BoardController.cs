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
            Board = new Board(Human, Ia);
        }

        public Board GetBoard()
        {
            return this.Board;
        }

    }
}
