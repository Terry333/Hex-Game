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
            string path = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory.ToString()).ToString()) + "\\Data\\Map.data";
            string MapData = File.ReadAllText(path);
            string[] sections = MapData.Split('-');
            X = int.Parse(sections[0]);
            Y = int.Parse(sections[1]);
            Hexes = new Hex[Y, X];
            Tiles = new Tile[Y, X];
            HexColors = new Color[Y, X];
            string[] roadData = sections[2].Split(' ');
            string[] riverData = sections[3].Split(' ');
            string[] biomeData = sections[4].Split(' ');
            string[] buildingData = sections[5].Split(' ');

            

            int write = 0;
            for (int y = 0; y < Y; y++)
            {
                for(int x = 0; x < X; x++)
                {
                    roadData[write].Replace(Environment.NewLine, "");
                    roadData[write].Replace("\0", "");
                    riverData[write].Trim(' ', '\n');
                    biomeData[write].Trim(' ', '\n');
                    buildingData[write].Trim(' ', '\n');
                    Tiles[y, x] = new Tile(x, y);
                    Console.WriteLine(write.ToString());
                    Console.WriteLine(roadData[write]);
                    Tiles[y, x].RoadLevel = int.Parse(roadData[write]);
                    Tiles[y, x].BiomeModifier = int.Parse(biomeData[write]);
                    int buildingId = int.Parse(buildingData[write]);
                    Tiles[y, x].Buildings.Add((Buildings)buildingId);
                    Tiles[y, x].HasRiver = Convert.ToBoolean(int.Parse(riverData[write++]));
                    Color color = Colors.Black;
                    switch (Tiles[y,x].BiomeModifier)
                    {
                        case 1:
                            color = Colors.DarkGray;
                            break;
                        case 2:
                            color = Colors.LightGray;
                            break;
                        case 3:
                            color = Colors.DarkSeaGreen;
                            break;
                        case 4:
                            color = Colors.DarkOliveGreen;
                            break;
                        case 5:
                            color = Colors.OliveDrab;
                            break;
                        case 6:
                            color = Colors.Wheat;
                            break;
                    }
                    HexColors[y, x] = color;
                }
            }
            InitializeComponent();
            GenerateMap(25, 25);
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
            
