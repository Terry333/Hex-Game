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
using _2008.Structs;
using _2008.UI;
using _2008.Enums;

namespace _2008.Classes
{
    class Tile : Control
    {
        public int X, Y;
        public double MaxWidth, SupplyWidth, RoadLevel, BiomeModifier, MudModifier, SnowModifier, RainModifier, Radiation;
        public List<Company> Units;
        public List<Buildings> Buildings;
        public Button Hex;
        public bool HasRiver;
        public Tile(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.BiomeModifier = 1;
            this.RoadLevel = 1;
            Units = new List<Company>();
            Buildings = new List<Buildings>();

            MaxWidth = 0;
            SupplyWidth = 0;
            MudModifier = 0;
            SnowModifier = 0;
            RainModifier = 0;
            Radiation = 0;
            HasRiver = false;

            Hex = new Hex().Button;
        }
        private void UpdateWidth()
        {
            double weatherMod = MudModifier + SnowModifier + RainModifier;
            MaxWidth = RoadLevel * BiomeModifier / weatherMod;
            SupplyWidth = MaxWidth * 2;
        }
        public bool MoveUnit(Company company, int newX, int newY)
        {

            return false;
        }
    }
}
