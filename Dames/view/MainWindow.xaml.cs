using Dames.controller;
using Dames.model.board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dames
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int LENGTH_GRID = 10;

        private Grid BoardXML;

        private BoardController boardController;

        public MainWindow()
        {
            InitializeComponent();

            InitalizeWindow();

            InitalizeGrid();

            boardController = new BoardController(BoardXML);            

            InitalizeSquare();
        }

        private void InitalizeWindow()
        {
            RootWindow.Height = 800;
            RootWindow.Width = 800;
            RootWindow.MinHeight = 800;
            RootWindow.MinWidth = 800;
            RootWindow.MaxHeight = 800;
            RootWindow.MaxWidth = 800;            
        }

        private void InitalizeGrid()
        {
            BoardXML = new Grid();
            BoardXML.HorizontalAlignment = HorizontalAlignment.Center;
            BoardXML.VerticalAlignment = VerticalAlignment.Center;
            BoardXML.ShowGridLines = true;
            BoardXML.Background = new SolidColorBrush(Colors.White);            

            for (int i = 0; i < LENGTH_GRID; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                column.Width = new GridLength(1, GridUnitType.Auto);
                BoardXML.ColumnDefinitions.Add(column);

                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(1, GridUnitType.Auto);
                BoardXML.RowDefinitions.Add(row);
            }

            RootWindow.Content = BoardXML;
        }

        private void InitalizeSquare()
        {
            foreach (Square square in boardController.GetBoard().GetSquares())
            {
                Grid.SetColumn(square.Get(), square.GetColumn());
                Grid.SetRow(square.Get(), square.GetRow());

                BoardXML.Children.Add(square.Get());

                if (square.GetPon() != null)
                {
                    Grid.SetColumn(square.GetPon().Get(), square.GetColumn());
                    Grid.SetRow(square.GetPon().Get(), square.GetRow());

                    BoardXML.Children.Add(square.GetPon().Get());
                }              
            }
        }


    }
}
