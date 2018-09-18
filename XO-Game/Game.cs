using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XO_Game
{
     static class Game
    {
        //Player = 1, Computer = 2, Empty = 0
        public static bool First;
        static public bool isStarted = false;
        static public int Computer;
        static public int Player;
        
        public static int Winner;

        static public int Choice = 0;

        static  int CurrentTurn = 1;

        static int[,] WinConditions = new int[8, 3]
        {
        { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 },
        { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 },
        { 0, 4, 8 }, { 2, 4, 6 }
        };

        static public int[] Grid = new int[9];

        public static void Reset(bool isFirst)
        {
            if (isFirst)
                CurrentTurn = 1;
            else
                CurrentTurn = 2;
            Player = 1;
            Winner = 0;
            SetPlayer(1);
            Grid = new int[9];
            First = isFirst;
            for (int i = 0; i < 9; i++)
                Grid[i] = 0;

            isStarted = true;
        }

        /*public*/
        static void SetPlayer(int NPlayer)
        {
            Player = NPlayer;
            Computer = switchPlayer(NPlayer);
        }

        public static void Win(int winner)                 //true - человек
        {
            isStarted = false;
            Winner = winner;
        }

        static int switchPlayer(int Player)
        {
            if (Player == 1) return 2;
            else return 1;
        }

        public static void MakeMove(int Move)
        {
            if (CurrentTurn == Player)
            {
                Grid = makeGridMove(Grid, CurrentTurn, Move);
                CurrentTurn = switchPlayer(CurrentTurn);
                isStarted = !checkGameEnd(Grid) && !checkGameWin(Grid, Player);

                if (checkGameWin(Grid, Player))
                    Winner = 1;

                
            }
            else if (CurrentTurn == Computer)
            {
                minimax(cloneGrid(Grid), CurrentTurn);
                Grid = makeGridMove(Grid, CurrentTurn, Choice);
                CurrentTurn = switchPlayer(CurrentTurn);
                isStarted = !checkGameEnd(Grid) && !checkGameWin(Grid, Computer);
                if (checkGameWin(Grid, Computer))
                    Winner = 2;
                
            }
            
        }

        /*public*/ static int minimax(int[] InputGrid, int Player)
        {
            int[] Grid = cloneGrid(InputGrid);

            if (checkScore(Grid, Computer) != 0)
                return checkScore(Grid, Computer);
            else if (checkGameEnd(Grid))
                return 0;

            List<int> scores = new List<int>();
            List<int> moves = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                if (Grid[i] == 0)
                {
                    scores.Add(minimax(makeGridMove(Grid, Player, i), switchPlayer(Player)));
                    moves.Add(i);
                }
            }

            if (Player == Computer)
            {
                int MaxScoreIndex = scores.IndexOf(scores.Max());
                Choice = moves[MaxScoreIndex];
                return scores.Max();
            }
            else
            {
                int MinScoreIndex = scores.IndexOf(scores.Min());
                Choice = moves[MinScoreIndex];
                return scores.Min();
            }
        }

        static int checkScore(int[] Grid, int Player)
        {
            if (checkGameWin(Grid, Player)) return 10;

            else if (checkGameWin(Grid, switchPlayer(Player))) return -10;

            else return 0;
        }

        static bool checkGameWin(int[] Grid,int Player)
        {

            /*
            if (Grid[0] == Player && Grid[1] == Player && Grid[2] == Player ||
                Grid[3] == Player && Grid[4] == Player && Grid[5] == Player ||
                Grid[6] == Player && Grid[7] == Player && Grid[8] == Player ||
                Grid[0] == Player && Grid[3] == Player && Grid[6] == Player ||
                Grid[1] == Player && Grid[4] == Player && Grid[7] == Player ||
                Grid[2] == Player && Grid[5] == Player && Grid[8] == Player ||
                Grid[0] == Player && Grid[4] == Player && Grid[8] == Player ||
                Grid[2] == Player && Grid[4] == Player && Grid[6] == Player 
                )


            */

           
            for (int i = 0; i < 8; i++)
            {
                if
                (
                    Grid[WinConditions[i, 0]] == Player &&
                    Grid[WinConditions[i, 1]] == Player &&
                    Grid[WinConditions[i, 2]] == Player
                )
                {
                    return true;
                }
            }
            return false;
        }

        static bool checkGameEnd(int[] Grid)
        {
            foreach (int p in Grid) if (p == 0) return false;
            return true;
        }

        static int[] cloneGrid(int[] Grid)
        {
            int[] Clone = new int[9];
            for (int i = 0; i < 9; i++) Clone[i] = Grid[i];

            return Clone;
        }

        static int[] makeGridMove(int[] Grid, int Move, int Position)
        {
            int[] newGrid = cloneGrid(Grid);
            newGrid[Position] = Move;
            return newGrid;
        }

        public static int WinLine()
        {
            if (Grid[0] !=0 && Grid[0] == Grid[1] && Grid[1] == Grid[2])
                return 1;
            if (Grid[3] != 0 && Grid[3] == Grid[4] && Grid[4] == Grid[5])
                return 2;
            if (Grid[6] != 0 && Grid[6] == Grid[7] && Grid[7] == Grid[8])
                return 3;
            if (Grid[0] != 0 && Grid[0] == Grid[3] && Grid[3] == Grid[6])
                return 4;
            if (Grid[1] != 0 && Grid[1] == Grid[4] && Grid[4] == Grid[7])
                return 5;
            if (Grid[2] != 0 && Grid[2] == Grid[5] && Grid[5] == Grid[8])
                return 6;
            if (Grid[0] != 0 && Grid[0] == Grid[4] && Grid[4] == Grid[8])
                return 7;
            if (Grid[2] != 0 && Grid[2] == Grid[4] && Grid[4] == Grid[6])
                return 8;
            return 0;







        }

    }
}
