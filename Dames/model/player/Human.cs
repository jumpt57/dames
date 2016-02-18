using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
    }
}
