using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.TicTacToe
{
    public class GameAiAgent
    {
        private const string V = " ";
        public string agent = "O";
        public GameAiAgent() { }

        public enum Scores
        {
            X = -1,
            O = 1,
            tie = 0
        }

        public int evaluate(string value)
        {
            switch (value)
            {
                case "X":
                    return -1;
                case "O":
                    return 1;
                case "tie":
                    return 0;
            }
            return 0;
        }

        public int[] bestMove(GameField gameField) 
        {
            int[] move = new int[2];
            int bestScore = -10000;

            for(int i = 0; i < gameField.gameField.GetLength(0); i++)// güzel ama kontorl et
            {
                for(int j = 0; j < gameField.gameField.GetLength(0); j++)
                {
                    // If the spot available
                    if (gameField.gameField[i, j] == V)
                    {
                        gameField.gameField[i, j] = agent;
                        int score = minimax(gameField.gameField, 0, false);
                        gameField.gameField[i, j] = V;

                        //bestScore = Math.Max(score, bestScore);
                        if (score > bestScore)
                        {
                            bestScore = score;
                            move[0] = i; move[1] = j;

                        }
                        
                    }
                }
            }
            return move;
        }


        public int minimax(string[,] gameField, int depth, bool isMaximizing) 
        {
            GameField newGameField = new GameField();
            newGameField.gameField = gameField;

            string currentResult = newGameField.hasWon();
            if (currentResult != null) 
            {
                int score = evaluate(currentResult);
                return score;
            }

            if (isMaximizing)
            {

                int bestScore = -100000;

                for (int i = 0; i < newGameField.gameField.GetLength(0); i++)// güzel ama kontorl et
                {
                    for (int j = 0; j < newGameField.gameField.GetLength(0); j++)
                    {
                        // If the spot available
                        if (newGameField.gameField[i, j] == V)
                        {
                            newGameField.gameField[i, j] = agent;
                            int score = minimax(newGameField.gameField, 0, false);
                            newGameField.gameField[i, j] = V;

                            bestScore = Math.Max(score, bestScore);
                            
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = 100000;

                for (int i = 0; i < newGameField.gameField.GetLength(0); i++)// güzel ama kontorl et
                {
                    for (int j = 0; j < newGameField.gameField.GetLength(0); j++)
                    {
                        // If the spot available
                        if (newGameField.gameField[i, j] == V)
                        {
                            newGameField.gameField[i, j] = agent;
                            int score = minimax(newGameField.gameField, 0, true);
                            newGameField.gameField[i, j] = V;

                            bestScore = Math.Min(score, bestScore);
                           
                        }
                    }
                }
                return bestScore;
            }
        }


    }
}
