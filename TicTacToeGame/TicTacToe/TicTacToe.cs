using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame.TicTacToe
{
    public  class TicTacToe
    {
        public GameField gameField;
        GameAiAgent agent;
        public string player1 = "X";
        public string player2 = "O";

        public TicTacToe() 
        { 
            agent = new GameAiAgent();
            gameField = new GameField();
            gameField.printField();
                    
        }


        // Game Super loop
        public void play()
        {

            while(true)
            {
                // user input
                Console.WriteLine("\n1-9 arasinda yapacaginiz hamleyi giriniz: ");
                int movePos = Convert.ToInt32(Console.ReadLine());
                int row = (movePos - 1) / 3;
                int col = (movePos - 1) % 3;

                // alana x in yazilmasi
                gameField.gameField[row, col] = player1;

                //kazanan olup olmadigi kontrol ediliyor. Varsa bitiriyor.
                if (checkWinner()) break;

                // Bilgisayar tarafindan gecici olarak musait yere O konulmasi
                /* int[] nextAvailableMove = searchFirstAvailable();
                 if (nextAvailableMove != null) gameField.gameField[nextAvailableMove[0], nextAvailableMove[1]] = player2;
                */
                int[] moveByAi = agent.bestMove(this.gameField);
                Console.WriteLine(moveByAi[0] + " " + moveByAi[1]);
                gameField.gameField[moveByAi[0], moveByAi[1]] = player2;


                // Alanin hamelerden sonra tekrar yazilmasi
                gameField.printField();

                //kazanan olup olmadigi kontrol ediliyor. Varsa bitiriyor.
                if (checkWinner()) break;
                

            }
            Console.ReadLine();

        }


        // Gecici olarak bilgisayarin hamle yapmasi icin kullanilan fonskiyon.
        // Muasit olan ilk yeri bulup konumunu return ediyor.
        public int[] searchFirstAvailable()
        {
            for( int i = 0; i < 3 ; i++ ) 
            {
                for (int j = 0; j < 3 ; j++ )
                {
                    if (gameField.gameField[i, j].Equals(" "))
                    {
                        return  new int[] { i, j };
                    }    
                }
            }
            return null;
        }

        public bool checkWinner()
        {
            string won = gameField.hasWon();
            if (won == "X" || won == "O") { Console.WriteLine(won + " has won The game"); return true; }
            if (won == "tie") { Console.WriteLine("TIE"); return true; }
            return false;
        }

    }
}
