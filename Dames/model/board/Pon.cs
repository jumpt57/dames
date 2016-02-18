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

namespace Dames.model
{
    class Pon
    {
        public static SolidColorBrush ColorHover = Brushes.Gray;

        private Rectangle Rec;
        private Player Player;

        public Pon(Player Player)
        {
            this.Rec = new Rectangle();
            this.Rec.Height = this.Rec.Width = 65;
            this.Rec.HorizontalAlignment = HorizontalAlignment.Center;
            this.Rec.VerticalAlignment = VerticalAlignment.Center;
            this.Rec.RadiusX = 50;
            this.Rec.RadiusY = 50;
            this.Rec.Stroke = Brushes.Black;
            this.Player = Player;

            this.Rec.MouseEnter += OnMouseEnter;
            this.Rec.MouseLeave += OnMouseLeave;
            this.Rec.MouseLeftButtonDown += OnMouseLeftClick;
        }

        private void OnMouseLeftClick(object sender, MouseEventArgs m)
        {
            Console.WriteLine("Click !");
        }

        private void OnMouseEnter(object sender, MouseEventArgs m)
        {
            this.SetColor(Pon.ColorHover);            
        }

        private void OnMouseLeave(object sender, MouseEventArgs m)
        {           
            if (this.GetPlayer() is Ia)
            {
                this.SetColor(Ia.Color);
            }
            else
            {
                this.SetColor(Human.Color);
            }
        }

        public Brush GetColor()
        {
            return this.Rec.Fill;
        }

        public void SetColor(Brush Color)
        {
            this.Rec.Fill = Color;
        }

        public Rectangle Get()
        {
            return this.Rec;
        }

        public Player GetPlayer()
        {
            return this.Player;
        }
    }
}
