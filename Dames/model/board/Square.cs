using Dames.model.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Dames.model.board
{
    class Square
    {
        private static bool WHITE = true;

        private Rectangle Rec;
        private int Column;
        private int Row;
        private Pon Pon;
        private bool Colored;

        public Square(int column, int row)
        {
            this.Rec = new Rectangle();
            this.Rec.Height = this.Rec.Width = 75;
            this.Rec.HorizontalAlignment = HorizontalAlignment.Center;
            this.Rec.VerticalAlignment = VerticalAlignment.Center;
            this.Rec.Stroke = Brushes.Black;
            DefineColor();

            this.Column = column;
            this.Row = row;
        }       

        private void DefineColor()
        {            
            if (WHITE)
            {
                this.Rec.Fill = Brushes.White;
                Colored = false;
                WHITE = false;
            }
            else
            {
                this.Rec.Fill = Brushes.SandyBrown;
                Colored = true;
                WHITE = true;
            }
        }

        public static void OffsetColor()
        {
            if (WHITE)
            {                
                WHITE = false;
            }
            else
            {
                WHITE = true;
            }
        }

        public Rectangle Get()
        {
            return this.Rec;
        }

        public void SetPon(Pon Pon)
        {
            this.Pon = Pon;
        }
        
        public Pon GetPon()
        {
            return this.Pon;
        }

        public int GetColumn()
        {
            return this.Column;
        }

        public int GetRow()
        {
            return this.Row;
        }

        public bool GetColored()
        {
            return this.Colored;
        }
    }
}
