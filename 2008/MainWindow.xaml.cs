using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using _2008.Classes;
using _2008.UI;
using _2008.Enums;

namespace _2008
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int X = 25;
        private const int Y = 32;
        private string Username;
        private string Password;
        private Hex[,] Hexes;
        private Color[,] HexColors;
        Tile[,] Tiles;
        public MainWindow()
        {
            MapData map = new MapData(100, 100);
            InitializeComponent();
            //GenerateMap(25, 25);
            this.Show();
            TurnControl ctrl = new TurnControl();
        }

        public void GenerateMap(double length, double height)
        {
            ScrollViewer scroller = new ScrollViewer();
            scroller.BorderThickness = new Thickness(0);
            Canvas canvas = new Canvas();
            scroller.Content = canvas;
            canvas.Width = X * length;
            canvas.Height = Y * height;
            double xMod = 0;
            double yMod = 0;

            AddChild(scroller);
        }
    }
}
            
