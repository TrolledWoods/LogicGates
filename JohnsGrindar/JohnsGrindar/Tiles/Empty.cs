using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnsGrindar.Tiles
{
    public class Empty : Tile
    {
        public override char GetGraphicChar(int x, int y)
        {
            return ' ';
        }

        public override ConsoleColor GetGraphicColor(int x, int y)
        {
            return ConsoleColor.Black;
        }
    }
}
