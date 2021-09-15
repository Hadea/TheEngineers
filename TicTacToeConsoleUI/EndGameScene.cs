using System;

namespace TicTacToeConsoleUI
{
    internal class EndGameScene : Scene
    {
        protected Button exitButton;
        internal EndGameScene()
        {
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("End of Game");
            exitButton = new(30, 20, "Back to Main Menu", () => SceneManager.Remove(this));
            uiElements.Add(exitButton);
            exitButton.IsSelected = true;
        }
        internal override void Update()
        {

            if (Console.KeyAvailable)
            {
                exitButton.HandleInput(Console.ReadKey(true).Key);
            }
        }
    }
}
