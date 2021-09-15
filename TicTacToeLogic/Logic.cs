using System;
using System.Collections.Generic;

namespace TicTacToeLogic
{
    public class Logic : ITicTacToeLogic
    {
        public Field[,] GameBoard { get; init; }
        public bool CurrentPlayer { get; set; }
        public bool GameRunning { get; protected set; }
        protected int turnNumber;

        public Logic()
        {
            GameBoard = new Field[3, 3];
            ResetGame();
        }
        
        public TurnResult Turn(int X, int Y)
        {
            if (X < 0 || X > 2 || Y < 0 || Y > 2 || GameBoard[Y, X] != Field.Empty || !GameRunning)
                return TurnResult.Invalid;

            Field playerStone = (CurrentPlayer ? Field.X : Field.O);
            GameBoard[Y, X] = playerStone;
            turnNumber++;

            if (checkWin(playerStone))
            {
                GameRunning = false;
                return TurnResult.Win;
            }
            else
            {
                if (turnNumber < 9)
                {
                    CurrentPlayer = !CurrentPlayer;
                    return TurnResult.Valid;
                }
                else
                {
                    GameRunning = false;
                    return TurnResult.Draw;
                }
            }
        }

        protected bool checkWin(Field playerStone)
        {
            return
                // Horizontal
                (GameBoard[0, 0] == playerStone && playerStone == GameBoard[0, 1] && playerStone == GameBoard[0, 2]) ||
                (GameBoard[1, 0] == playerStone && playerStone == GameBoard[1, 1] && playerStone == GameBoard[1, 2]) ||
                (GameBoard[2, 0] == playerStone && playerStone == GameBoard[2, 1] && playerStone == GameBoard[2, 2]) ||
                // Vertikal
                (GameBoard[0, 0] == playerStone && playerStone == GameBoard[1, 0] && playerStone == GameBoard[2, 0]) ||
                (GameBoard[0, 1] == playerStone && playerStone == GameBoard[1, 1] && playerStone == GameBoard[2, 1]) ||
                (GameBoard[0, 2] == playerStone && playerStone == GameBoard[1, 2] && playerStone == GameBoard[2, 2]) ||
                // Diagonal
                (GameBoard[0, 0] == playerStone && playerStone == GameBoard[1, 1] && playerStone == GameBoard[2, 2]) ||
                (GameBoard[0, 2] == playerStone && playerStone == GameBoard[1, 1] && playerStone == GameBoard[2, 0]);
        }

        public List<Score> GetHighscore() { return new List<Score>(); }

        public void ResetGame()
        {
            for (int Y = 0; Y < 3; Y++)
            {
                for (int X = 0; X < 3; X++)
                {
                    GameBoard[Y, X] = Field.Empty;
                }
            }
            GameRunning = true;
            turnNumber = 0;
        }
    }
}
