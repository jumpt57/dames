using Dames.model.board;
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
        public static SolidColorBrush ColorClick = Brushes.LightGreen;

        private Rectangle Rec;
        private Player Player;
        private Square Square;
        private bool Dame;
        private bool Selected;
        private bool Hovered;

        public Pon(Player Player)
        {
            this.Rec = new Rectangle();
            this.Rec.Height = this.Rec.Width = 65;
            this.Rec.HorizontalAlignment = HorizontalAlignment.Center;
            this.Rec.VerticalAlignment = VerticalAlignment.Center;
            this.Rec.RadiusX = 50;
            this.Rec.RadiusY = 50;
            this.Rec.Stroke = Brushes.Black;                     
            
            this.Rec.MouseEnter += OnMouseEnter;
            this.Rec.MouseLeave += OnMouseLeave;
            this.Rec.MouseLeftButtonDown += OnMouseLeftClick;

            this.Player = Player;
            this.Dame = false;
            this.Selected = false;
            this.Hovered = false;
        }

        private void OnMouseLeftClick(object sender, MouseEventArgs m)
        {
            if (this.Player.GetIa()) return;
                      
            if (!this.Selected && CanBePlayed())
            {                       
                Select();
                Player.DeselectPons(this);
                return;
            }
            else if(this.Selected)
            {
                Deselect();
                this.Square.GetBoard().ResetSelectedSquares();
            }
        }        

        private void OnMouseEnter(object sender, MouseEventArgs m)
        {
            if (this.Player.GetIa()) return;
            ActionHovered();
        }

        private void OnMouseLeave(object sender, MouseEventArgs m)
        {
            if (this.Player.GetIa()) return;
            ActionHovered();
        }

        private void ActionHovered()
        {
            if (this.Hovered && !this.Selected)
            {
                this.SetColor(Player.GetColor());
                this.Hovered = false;
            }
            else if(!this.Hovered && !this.Selected)
            {
                this.SetColor(Pon.ColorHover);
                this.Hovered = true;
            }
        }

        public void Select()
        {
            this.Selected = true;            
            this.SetColor(Pon.ColorClick);            
        }

        public void Deselect()
        {
            this.Selected = false;
            this.SetColor(this.Player.GetColor());            
        }

        private bool CanBePlayed()
        {
            return this.Square.GetBoard().PossibleToMove(this.GetSquare());
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

        public void SetSquare(Square Square)
        {
            this.Square = Square;
        }

        public Square GetSquare()
        {
            return this.Square;
        }

        public bool GetDame()
        {
            return this.Dame;
        }

        public void SetDame(bool Dame)
        {
            this.Dame = Dame;
        }

        public bool GetSelected()
        {
            return this.Selected;
        }

        public void SetSelected(bool Selected)
        {
            this.Selected = Selected;
        }

        public bool GetHovered()
        {
            return this.Hovered;
        }

        public void SetHovered(bool Hovered)
        {
            this.Hovered = Hovered;
        }
    }
}
