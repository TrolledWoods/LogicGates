using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnsGrindar.Tiles
{
    public abstract class Tile
    {
        public abstract char GetGraphicChar(int x, int y);
        public abstract ConsoleColor GetGraphicColor(int x, int y);
    }
}
