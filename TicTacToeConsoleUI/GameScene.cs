using System;
using System.Collections.Generic;
using System.Drawing;
using TicTacToeLogic;

namespace TicTacToeConsoleUI
{
    internal class GameScene : Scene
    {
        protected FieldButton[,] fieldButton = new FieldButton[3, 3];
        protected readonly ITicTacToeLogic gameLogic;
        protected Point selectedField;

        public GameScene(ITicTacToeLogic LogicClass)
        {
            Console.ResetColor();
            Console.Clear();
            selectedField.X = 1;
            selectedField.Y = 1;
            gameLogic = LogicClass;

            for (int Y = 0; Y < 3; Y++)
            {
                for (int X = 0; X < 3; X++)
                {
                    //Hack: Position in center of screen instead of guessing position
                    fieldButton[Y, X] = new FieldButton(30 + X * 2, 10 + Y * 2);
                }
            }

            fieldButton[selectedField.Y, selectedField.X].IsSelected = true;

            foreach (var item in fieldButton)
                uiElements.Add(item);
            
        }
        internal override void Update()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                TurnResult result = TurnResult.Invalid;
                fieldButton[selectedField.Y, selectedField.X].IsSelected = false;
                switch (key)
                {
                    case ConsoleKey.Escape:
                        SceneManager.Remove(this);//todo: add ingame menu
                        break;
                    case ConsoleKey.DownArrow:
                        selectedField.Y = selectedField.Y == 2 ? 0 : selectedField.Y + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        selectedField.Y = selectedField.Y == 0 ? 2 : selectedField.Y - 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        selectedField.X = selectedField.X == 0 ? 2 : selectedField.X - 1;
                        break;
                    case ConsoleKey.RightArrow:
                        selectedField.X = selectedField.X == 2 ? 0 : selectedField.X + 1;
                        break;
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        result = gameLogic.Turn(selectedField.X, selectedField.Y);
                        break;
                }
                fieldButton[selectedField.Y, selectedField.X].IsSelected = true;
                fieldButton[selectedField.Y, selectedField.X].CurrentPlayer = gameLogic.CurrentPlayer;
                fieldButton[selectedField.Y, selectedField.X].CurrentStone = gameLogic.GameBoard[selectedField.Y, selectedField.X];
                if (result is TurnResult.Win or TurnResult.Draw)
                {
                    Draw();
                    SceneManager.Remove(this);
                    SceneManager.Add(new EndGameScene());
                }

            }
        }
    }
}
