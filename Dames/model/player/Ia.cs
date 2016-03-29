using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Dames.model.board;

namespace Dames.model.player
{
    class Ia : Player
    {        
        public Ia()
        {
            this.Color = Brushes.Wheat;
            this.CreatePons();
            this.Ia = true;
        }

        public override bool PossibleMovements(Board board, Square Square)
        {
            return true;
        }
    }
}
