using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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
    }
}
