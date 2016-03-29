using Dames.model.player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Dames.model.board
{
    class Board
    {
        private static int LENGTH_GRID = 10;

        private List<Square> Squares;

        private Grid BoardXML;

        private bool WaitTurn;

        public Board(Grid BoardXML)
        {
            this.Squares = new List<Square>(100);
            this.BoardXML = BoardXML;
            InitalizeSquares();
            WaitTurn = false;
        }

        public void InitalizeSquares()
        {
            for (int i = 0; i < LENGTH_GRID; i++)
            {
                for (int j = 0; j < LENGTH_GRID; j++)
                {
                    Square square = new Square(j, i, this);
                    this.Squares.Add(square);
                }
                Square.OffsetColor();
            }
        }

        public List<Square> GetSquares()
        {
            return this.Squares;
        }

        public bool CheckMovements(Square Square, Player Player)
        {
            return Player.PossibleMovements(this, Square);
        }

        public void MoveSelectedPonTo(Square NewSquare)
        {
            var Pon = RemoveSelectedPonFromTheBoard();
            if (Pon != null)
            {
                BoardXML.Children.Remove(Pon.Get());
                NewSquare.SetPon(Pon);
                Pon.SetSquare(NewSquare);

                Grid.SetColumn(NewSquare.GetPon().Get(), NewSquare.GetColumn());
                Grid.SetRow(NewSquare.GetPon().Get(), NewSquare.GetRow());
                BoardXML.Children.Add(Pon.Get());

                ResetSelectedSquares();
                Pon.Deselect();
            }         
        }

        public void Manger()
        {
            Console.WriteLine("Try to eat !");
        }

        public Square SquareAt(int column, int row)
        {            
            foreach (Square Square in Squares)
            {
                if (Square.GetColumn() == column && Square.GetRow() == row)
                {
                    return Square;
                }
            }
            return null;
        }

        public void ResetSelectedSquares()
        {
            foreach (Square Square in Squares)
            {
                if (Square.GetHovered())
                {
                    Square.NotHovered();
                }      
                else if (Square.GetPossibleManger())
                {
                    Square.NotPossibleManger();
                }          
            }
        }
        
        private Pon RemoveSelectedPonFromTheBoard()
        {
            foreach (Square Square in Squares)
            {
                if (Square.GetPon() != null && Square.GetPon().GetSelected())
                {                    
                    return Square.RemovePon();                   
                }
            }
            return null;
        }

        public Pon WhatIsTheSelectedPon()
        {
            foreach (Square Square in Squares)
            {
                if (Square.GetPon() != null && Square.GetPon().GetSelected())
                {
                    return Square.GetPon();
                }
            }
            return null;
        }

        public void IaTurn()
        {
            Console.WriteLine("tour de l'ia");
            this.WaitTurn = true;
            var Ia = GetIa();

            var column = 9; //Random
            var row = 3; // Random

            var Square = this.SquareAt(column, row);
            var Playable = false;
            while (!Playable)
            {
                if (this.CheckMovements(Square, Ia))
                {
                    Playable = true;
                }
            }
            

            this.WaitTurn = false;
            Console.WriteLine("fin du tour de l'ia");
        }

        private Ia GetIa()
        {
            foreach (Square Square in Squares)
            {
                if (Square.GetPon() != null && Square.GetPon().GetPlayer().GetIa())
                {
                    return (Ia) Square.GetPon().GetPlayer();
                }
            }
            return null;
        }

        public bool GetWaitTurn()
        {
            return this.WaitTurn;
        }

        public void SetWaiTurn(bool WaitTurn)
        {
            this.WaitTurn = WaitTurn;
        }
    }
}
