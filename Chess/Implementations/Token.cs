using System;
using System.Collections.Generic;
using System.Text;
using Chess.Models;


namespace Chess.Implementations
{
    public abstract class Token
    {
        public Position2D GetNewPosition(string command)
        {
            Position2D oldPosition = getCurrentPosition();
            string[] moveNames = getMoveNames();
            int[,] moves = getMoves();
            for (int i = 0; i < moveNames.Length; i++)
            {
                if (command.Equals(moveNames[i]))
                {
                    int x = moves[i, 0] + oldPosition.x;
                    int y = moves[i, 1] + oldPosition.y;
                    return new Position2D(x, y);
                }
            }
            return new Position2D(-1, -1);
        }
        public abstract string[] getMoveNames();
        public abstract int[,] getMoves();
        public abstract Position2D getCurrentPosition();
        public abstract void setCurrentPosition(Position2D newPosition);
        public abstract string getName();
        public abstract bool getIfPathKill();
    }
}
