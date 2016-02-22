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

        public static SolidColorBrush WhiteSquare = Brushes.White;
        public static SolidColorBrush ColoredSquare = Brushes.SandyBrown;
        public static SolidColorBrush HoverSquare = Brushes.LightCyan;

        private Rectangle Rec;        
        private Pon Pon;
        private Board Board;
        private int Column;
        private int Row;
        private bool Colored;
        private bool Selected;

        public Square(int column, int row, Board Board)
        {
            this.Rec = new Rectangle();
            this.Rec.Height = this.Rec.Width = 75;
            this.Rec.HorizontalAlignment = HorizontalAlignment.Center;
            this.Rec.VerticalAlignment = VerticalAlignment.Center;
            this.Rec.Stroke = Brushes.Black;
            DefineColor();

            this.Rec.MouseLeftButtonDown += OnMouseLeftClick;

            this.Column = column;
            this.Row = row;
            this.Board = Board;
            this.Selected = false;
        }

        private void OnMouseLeftClick(object sender, MouseEventArgs m)
        {
            if (this.Pon == null || this.Pon != null && this.Pon.GetPlayer().GetIa()) return;
            Console.WriteLine("Click on Square");
        }

        private void DefineColor()
        {            
            if (WHITE)
            {
                this.Rec.Fill = WhiteSquare;
                Colored = false;
                WHITE = false;
            }
            else
            {
                this.Rec.Fill = ColoredSquare;
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

        public void Select()
        {
            this.Rec.Fill = HoverSquare;
            this.Selected = true;
        }

        public void Deselect()
        {
            if (this.Colored)
            {
                this.Rec.Fill = ColoredSquare;
            }
            else
            {
                this.Rec.Fill = WhiteSquare;
            }
            this.Selected = false;
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

        public Board GetBoard()
        {
            return this.Board;
        }

        public bool GetColored()
        {
            return this.Colored;
        }

        public bool GetSelected()
        {
            return this.Selected;
        }

        public void SetSelected(bool Selected)
        {
            this.Selected = Selected;
        }
    }
}
