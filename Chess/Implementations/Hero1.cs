using System;
using System.Collections.Generic;
using System.Text;
using Chess.Models;

namespace Chess.Implementations
{
    class Hero1: Token
    {
        private string[] moveNames = { "L", "R", "F", "B" };
        private int[,] moves = new int[4, 2] { { -2, 0 }, { 2, 0 }, { 0, 2 }, { 0, -2 } };
        public readonly bool killInPath = true;
        private Position2D currentPosition;
        private string name;
        public Hero1(Position2D position, string name)
        {
            this.currentPosition = position;
            this.name = name;
        }
        public override string[] getMoveNames()
        {
            return this.moveNames;
        }
        public override int[,] getMoves()
        {
            return this.moves;
        }
        public override Position2D getCurrentPosition()
        {
            return this.currentPosition;
        }
        public override string getName()
        {
            return this.name;
        }
        public override void setCurrentPosition(Position2D newPosition)
        {
            this.currentPosition = newPosition;
        }
        public override bool getIfPathKill()
        {
            return this.killInPath;
        }
    }
}
