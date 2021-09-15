using System;

namespace TicTacToeConsoleUI
{
    internal class Button : UIElement
    {
        protected Action executeOnClick;
        protected const ConsoleColor colorSelected = ConsoleColor.Yellow;
        protected const ConsoleColor colorNotSelected = ConsoleColor.Black;
        protected const ConsoleColor colorAvailable = ConsoleColor.DarkGray;
        protected const ConsoleColor colorDisabled = ConsoleColor.DarkRed;
        internal bool IsSelected;
        protected readonly string text;

        public Button(int PositionX, int PositionY, string Caption, Action MethodToExecute) : base(PositionX, PositionY)
        {
            text = Caption;
            executeOnClick = MethodToExecute;
        }

        internal override void Draw()
        {
            if (executeOnClick is null)
            {
                Console.ForegroundColor = colorDisabled;
            }
            else
            {
                Console.ForegroundColor = colorAvailable;
            }

            if (IsSelected)
            {
                Console.BackgroundColor = colorSelected;
            }
            else
            {
                Console.BackgroundColor = colorNotSelected;
            }
            Console.SetCursorPosition(posX, posY);
            Console.Write(text);
        }

        internal void HandleInput(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter && executeOnClick != null)
            {
                executeOnClick();
            }
        }
    }
}
