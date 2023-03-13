using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.TicTacToe
{
    public class GameField 
    {


        public string[,] gameField = { { " ", " ", " " },
                                       { " ", " ", " " }, 
                                       { " ", " ", " " } };


        public void printField()
        {
            
            for (int i = 0; i < 3; i++)
            {   
                Console.WriteLine("\n-------");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("|" + gameField[i, j] );
                }
                Console.Write("|");
            } 
            Console.WriteLine("\n-------");
        }

        // Satir, Sutun ve caprazi kontrol edip kazanan olup olmadigini kontrol ediyor.
        public string hasWon()
        {
            // Won in rows
            if (gameField[0, 0] == gameField[0, 1] && gameField[0, 1] == gameField[0, 2] && gameField[0, 0] != " ") return gameField[0, 0];
            if (gameField[1, 0] == gameField[1, 1] && gameField[1, 1] == gameField[1, 2] && gameField[1, 0] != " ") return gameField[1, 0];
            if (gameField[2, 0] == gameField[2, 1] && gameField[2, 1] == gameField[2, 2] && gameField[2, 0] != " ") return gameField[2, 0];

            // Won in columns
            if (gameField[0, 0] == gameField[1, 0] && gameField[0, 0] == gameField[2, 0] && gameField[0, 0] != " ") return gameField[0, 0];
            if (gameField[0, 1] == gameField[1, 1] && gameField[0, 1] == gameField[2, 1] && gameField[0, 1] != " ") return gameField[0, 1];
            if (gameField[0, 2] == gameField[1, 2] && gameField[0, 2] == gameField[2, 2] && gameField[0, 2] != " ") return gameField[0, 2];

            // Won on diagoanl
            if (gameField[0, 0] == gameField[1, 1] && gameField[0, 0] == gameField[2, 2] && gameField[0, 0] != " ") return gameField[0, 0];
            if (gameField[0, 2] == gameField[1, 1] && gameField[0, 2] == gameField[2, 0] && gameField[0, 2] != " ") return gameField[0, 2];

            // Alan dolduysa ve kazanan yoksa berabere 
            if (isFullfilled(gameField)) return "tie";

            // Alan dolmadiysa ve oyun devam ediyorsa ?
            return null;
        }

        // BURADA BİR SIKINTI VAR GİBİ
        private bool isFullfilled(string[,] field)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (field[i, j].Equals(" ")) return false;
                }
            }
            return true;
        }

        public GameField() { }
    }


}
    