using System;
using System.Collections.Generic;

namespace TicTacToeLogic
{
    public class Logic
    {
        public Field[,] GameBoard;

        public bool GetCurrentPlayer() { return false; }
        public TurnResult Turn(int X, int Y) { return TurnResult.Invalid; }
        protected bool checkWin() { return true; }
        public List<Score> GetHighscore() { return new List<Score>(); }
    }
}
