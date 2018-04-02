using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JohnsGrindar
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffer b = new Buffer(30, 30);

            while (true)
            {
                b.DrawBuffer();
            }
        }

        public static void KeyPressed(ConsoleKeyInfo key)
        {

        }
    }
}
