using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Models
{
    public static class AllowedTokenTypes
    {
        public static string[] getTokenNames()
        {
            string[] tokenNames = { "P", "H1", "H2", "H3" };
            return tokenNames;
        }
    }
}
