using System;

namespace TicTacToeConsoleUI
{
    internal static class Program
    {
        private static void Main()
        {
            SceneManager.Add(new MainMenuScene());
            Console.CursorVisible = false;

            while (SceneManager.SceneCount > 0)
            {
                SceneManager.Draw();
                SceneManager.Update();
            }
            Console.ResetColor();
        }
    }
}
