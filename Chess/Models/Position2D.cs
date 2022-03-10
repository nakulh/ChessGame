using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Models
{
    public class Position2D
    {
        public Position2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int x { get; set; }
        public int y { get; set; }
    }
}
