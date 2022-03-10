using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Models
{
    public static class MoveMirror
    {
        public static string getMirror(string move)
        {
            Dictionary<string, string> mirror = new Dictionary<string, string>();

            // For Pawn, Hero1, Hero2
            mirror.Add("F", "B");
            mirror.Add("B", "F");
            mirror.Add("R", "L");
            mirror.Add("L", "R");

            // For Hero3
            mirror.Add("FL", "BR");
            mirror.Add("FR", "BL");
            mirror.Add("BL", "FR");
            mirror.Add("BR", "FL");
            mirror.Add("RF", "LB");
            mirror.Add("RB", "LF");
            mirror.Add("LF", "RB");
            mirror.Add("LB", "RF");

            return mirror[move];
        }
    }
}
