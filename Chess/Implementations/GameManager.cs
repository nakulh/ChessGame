using System;
using System.Collections.Generic;
using System.Text;
using Chess.Models;
using Chess.Interfaces;

namespace Chess.Implementations
{
    public class GameManager
    {
        int boardLength, boardWidth;
        readonly int playerCount = 2;
        List<Token> playerATokens = new List<Token>();
        List<Token> playerBTokens = new List<Token>();
        IPlayerInteractor interactor;
        bool isPlayerATurn = true;
        Token lastMovedToken = new Pawn(new Position2D(-1, -1), "P0");
        Position2D oldPositionOfLastToken = new Position2D(0, 0);
        public GameManager(int boardLength, int boardWidth, IPlayerInteractor interactor)
        {
            this.boardLength = boardLength;
            this.boardWidth = boardWidth;
            this.interactor = interactor;
        }
        public void beginNewGame()
        {
            this.interactor.sendMessage("Player A input your tokens");
            List<string> playerATokenNames = InputParser.getTokenNames(this.interactor.getUserInput());
            this.assignTokensToPlayer(playerATokenNames, this.playerATokens, 0, 0);
            this.interactor.sendMessage("Player B input your tokens");
            List<string> playerBTokenNames = InputParser.getTokenNames(this.interactor.getUserInput());
            this.assignTokensToPlayer(playerBTokenNames, this.playerBTokens, 0, boardWidth - 1);
            this.showBoardStatus();
            while(this.playerATokens.Count > 0 && this.playerBTokens.Count > 0)
            {
                if (isPlayerATurn)
                {
                    interactor.sendMessage("Player A input your move");
                    bool isValidMove = this.initiateMove(this.playerATokens, false);
                    if (!isValidMove)
                    {
                        interactor.sendMessage("Invalid Move, try again");
                        continue;
                    }
                    isPlayerATurn = !isPlayerATurn;
                    this.killOpponent(this.playerBTokens);
                    this.showBoardStatus();
                }
                else
                {
                    interactor.sendMessage("Player B input your move");
                    bool isValidMove = this.initiateMove(this.playerBTokens, true);
                    if (!isValidMove)
                    {
                        interactor.sendMessage("Invalid Move, try again");
                        continue;
                    }
                    isPlayerATurn = !isPlayerATurn;
                    this.killOpponent(this.playerATokens);
                    this.showBoardStatus();
                }
            }
            interactor.sendMessage("Game Over");
        }
        private void assignTokensToPlayer(List<string> tokenNames, List<Token> tokenList, int x, int y)
        {
            foreach (string tokenName in tokenNames)
            {
                if (tokenName.StartsWith("P"))
                {
                    tokenList.Add(new Pawn(new Position2D(x++, y), tokenName));
                    continue;
                }
                switch (tokenName)
                {
                    case "H1":
                        tokenList.Add(new Hero1(new Position2D(x++, y), tokenName));
                        break;
                    case "H2":
                        tokenList.Add(new Hero2(new Position2D(x++, y), tokenName));
                        break;
                    case "H3":
                        tokenList.Add(new Hero3(new Position2D(x++, y), tokenName));
                        break;
                }
            }
        }
        private void showBoardStatus()
        {
            this.interactor.sendBoardStatus(this.playerATokens, this.playerBTokens, this.boardWidth, this.boardLength);
        }
        private bool initiateMove(List<Token> tokens, bool isMirrored)
        {
            List<string> move = InputParser.getMove(interactor.getUserInput());
            string tokenName = move[0];
            string tokenMove = move[1];
            if (isMirrored)
            {
                tokenMove = MoveMirror.getMirror(tokenMove);
            }
            foreach(Token t in tokens)
            {
                if (t.getName().Equals(tokenName))
                {
                    Position2D newPosition = t.GetNewPosition(tokenMove);
                    if(newPosition.x < this.boardWidth && newPosition.x >= 0 && newPosition.y < this.boardLength && newPosition.y >= 0 && 
                        tokens.Find(t => t.getCurrentPosition().x == newPosition.x && t.getCurrentPosition().y == newPosition.y) == null)
                    {
                        this.oldPositionOfLastToken = t.getCurrentPosition();
                        this.lastMovedToken = t;
                        t.setCurrentPosition(newPosition);
                        return true;
                    }
                }
            }
            return false;
        }
        private void killOpponent(List<Token> opponentTokens)
        {
            this.initiateKill(opponentTokens, this.lastMovedToken.getCurrentPosition());
            if (this.lastMovedToken.getIfPathKill())
            {
                Position2D newPosition = this.lastMovedToken.getCurrentPosition();
                if(newPosition.x == this.oldPositionOfLastToken.x) 
                {
                    if(this.oldPositionOfLastToken.y < newPosition.y)
                    {
                        initiateKill(opponentTokens, new Position2D(this.oldPositionOfLastToken.x, this.oldPositionOfLastToken.y + 1));
                    }
                    else
                    {
                        initiateKill(opponentTokens, new Position2D(this.oldPositionOfLastToken.x, this.oldPositionOfLastToken.y - 1));
                    }
                }
                else if(newPosition.y == this.oldPositionOfLastToken.y)
                {
                    if (this.oldPositionOfLastToken.x < newPosition.x)
                    {
                        initiateKill(opponentTokens, new Position2D(this.oldPositionOfLastToken.x + 1, this.oldPositionOfLastToken.y));
                    }
                    else
                    {
                        initiateKill(opponentTokens, new Position2D(this.oldPositionOfLastToken.x - 1, this.oldPositionOfLastToken.y));
                    }
                }
                else if (newPosition.y > this.oldPositionOfLastToken.y && newPosition.x > this.oldPositionOfLastToken.x)
                {
                    initiateKill(opponentTokens, new Position2D(this.oldPositionOfLastToken.x + 1, this.oldPositionOfLastToken.y + 1));
                }
                else if (newPosition.y < this.oldPositionOfLastToken.y && newPosition.x < this.oldPositionOfLastToken.x)
                {
                    initiateKill(opponentTokens, new Position2D(this.oldPositionOfLastToken.x - 1, this.oldPositionOfLastToken.y - 1));
                }
                else if (newPosition.y < this.oldPositionOfLastToken.y && newPosition.x > this.oldPositionOfLastToken.x)
                {
                    initiateKill(opponentTokens, new Position2D(this.oldPositionOfLastToken.x + 1, this.oldPositionOfLastToken.y - 1));
                }
                else if (newPosition.y > this.oldPositionOfLastToken.y && newPosition.x < this.oldPositionOfLastToken.x)
                {
                    initiateKill(opponentTokens, new Position2D(this.oldPositionOfLastToken.x - 1, this.oldPositionOfLastToken.y + 1));
                }
            }
        }
        private void initiateKill(List<Token> opponentTokens, Position2D position)
        {
            for (int i = 0; i < opponentTokens.Count; i++)
            {
                if (opponentTokens[i].getCurrentPosition().x == position.x &&
                                opponentTokens[i].getCurrentPosition().y == position.y)
                {
                    opponentTokens.RemoveAt(i);
                }
            }
        }
    }
}
