using Chess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Implementations
{
    public class ConsoleInteractor: IPlayerInteractor
    {
        public void sendMessage(string msg)
        {
            Console.WriteLine(msg);
        }
        public string getUserInput()
        {
            string inp = Console.ReadLine();
            return inp;
        }
        public void sendBoardStatus(List<Token> playerATokens, List<Token> playerBTokens, int x, int y)
        {
            this.sendMessage("Current Grid Status:");
            for (int i = y-1; i >= 0; i--)
            {
                string toPrint = String.Empty;
                for(int j = 0; j < x; j++)
                {
                    Token currToken = playerATokens.Find(t => t.getCurrentPosition().y == i && t.getCurrentPosition().x == j);
                    bool wasAToken = true;
                    if(currToken == null)
                    {
                        wasAToken = false;
                        currToken = playerBTokens.Find(t => t.getCurrentPosition().y == i && t.getCurrentPosition().x == j);
                    }
                    if(currToken != null)
                    {
                        toPrint += (wasAToken ? "A-" : "B-") + currToken.getName() + "   ";
                    }
                    else
                    {
                        toPrint += "-      ";
                    }
                }
                this.sendMessage(toPrint);
            }
        }
    }
}
