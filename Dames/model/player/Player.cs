using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Dames.model.player
{
    abstract class Player
    {
        protected static int MAX_PONS = 20;

        protected SolidColorBrush Color;

        protected List<Pon> Pons;

        protected bool Ia;

        protected void CreatePons()
        {
            this.Pons = new List<Pon>(MAX_PONS);

            for (int i = 0; i < Player.MAX_PONS; i++)
            {
                var Pon = new Pon(this);
                Pon.SetColor(Color);
                this.Pons.Add(Pon);
            }
        }

        public void DeselectPons(Pon Pon)
        {
            foreach (Pon pon in Pons)
            {
                if (!Pon.Equals(pon))
                {
                    pon.Deselect();
                }
            }
        }

        public List<Pon> GetPons()
        {
            return this.Pons;
        }

        public SolidColorBrush GetColor()
        {
            return this.Color;
        }

        public bool GetIa()
        {
            return this.Ia;
        }

        protected void MIN()
        {

        }

        protected void MAX()
        {

        }        
    }
}
