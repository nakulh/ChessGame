using Chess.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Interfaces
{
    public interface IPlayerInteractor
    {
        public void sendMessage(string msg);
        public string getUserInput();
        public void sendBoardStatus(List<Token> playerATokens, List<Token> playerBTokens, int x, int y);
    }
}
