using Chess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Implementations
{
    class Pawn : Token
    {
        private string[] moveNames = {"L", "R", "F", "B"};
        private int[,] moves = new int[4, 2] { { -1, 0 }, { 1, 0 }, { 0, 1 }, { 0, -1 } };
        public readonly bool killInPath = false;
        private Position2D currentPosition;
        private string name;
        public Pawn(Position2D position, string name)
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
