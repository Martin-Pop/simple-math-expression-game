using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationGame
{
    public class Priklad
    {
        private int x;
        private int y;
        private int vysledek;
        public int X { get => x; }
        public int Y { get => y; }
        public int Vysledek { get => vysledek; }

        public Priklad(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.vysledek = x + y;
        }
    }
}
