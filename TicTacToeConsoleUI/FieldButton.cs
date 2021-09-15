using System;
using TicTacToeLogic;

namespace TicTacToeConsoleUI
{
    internal class FieldButton : UIElement
    {
        // Background colors
        protected const ConsoleColor colorSelectedByX = ConsoleColor.DarkBlue;
        protected const ConsoleColor colorSelectedByO = ConsoleColor.DarkRed;
        protected const ConsoleColor colorSelectedByNone = ConsoleColor.Black;

        // Foreground Colors
        protected const ConsoleColor colorStoneX = ConsoleColor.Blue;
        protected const ConsoleColor colorStoneO = ConsoleColor.Red;
        
        // Visuals
        public bool IsSelected;
        public bool CurrentPlayer;
        public Field CurrentStone = Field.Empty;

        public FieldButton(int PositionX, int PositionY) : base(PositionX, PositionY)
        {

        }

        internal override void Draw()
        {
            Console.SetCursorPosition(posX, posY);
            if (IsSelected)
                Console.BackgroundColor = CurrentPlayer ? colorSelectedByX : colorSelectedByO;
            else
                Console.BackgroundColor = colorSelectedByNone;

            switch (CurrentStone)
            {
                case Field.X:
                    Console.ForegroundColor = colorStoneX;
                    Console.Write("X");
                    break;
                case Field.O:
                    Console.ForegroundColor = colorStoneO;
                    Console.Write("O");
                    break;
                default:
                    //Hack: make invisible
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("_");
                    break;
            }

        }
    }
}
