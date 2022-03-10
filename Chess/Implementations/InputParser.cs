using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Implementations
{
    public static class InputParser
    {
        public static List<string> getTokenNames(string input)
        {
            List<string> names = new List<string>(input.Split(','));
            for(int i = 0; i < names.Count; i++)
            {
                names[i] = names[i].Trim();
            }
            return names;
        }
        public static List<string> getMove(string input)
        {
            List<string> move = new List<string>(input.Split(':'));
            for (int i = 0; i < move.Count; i++)
            {
                move[i] = move[i].Trim();
            }
            return move;
        }
    }
}
