using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Dames.model.player
{
    class Player
    {
        private List<Pon> Pons;

        public Player()
        {
            Pons = new List<Pon>(12);
        }
        
        public void AddPon(Pon Pon)
        {
            this.Pons.Add(Pon);
        }

        public void MIN()
        {

        }
        
        public void MAX()
        {

        }
        
    }
}
