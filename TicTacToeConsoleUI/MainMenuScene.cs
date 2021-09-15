using System;
using System.Collections.Generic;
using System.IO;
using TicTacToeLogic;

namespace TicTacToeConsoleUI
{
    internal class MainMenuScene : Scene
    {
        protected List<Button> buttonList = new();
        protected int ActiveButtonID
        {
            get => _activeButtonID;
            set
            {
                buttonList[_activeButtonID].IsSelected = false;
                if (value < 0)
                {
                    _activeButtonID = buttonList.Count - 1;
                }
                else if (value > buttonList.Count - 1)
                {
                    _activeButtonID = 0;
                }
                else
                {
                    _activeButtonID = value;
                }
                buttonList[_activeButtonID].IsSelected = true;
            }
        }
        protected int _activeButtonID; // do not use directly
        protected string[] logo;
        public MainMenuScene()
        {
            drawLogo();

            // create buttons below logo
            buttonList.Add(new Button(40, 20, "New Game", NewGameMethod ));
            buttonList.Add(new Button(40, 22, "Credits", null));
            buttonList.Add(new Button(40, 24, "HighScore", null));
            buttonList.Add(new Button(40, 26, "Exit", () => SceneManager.Remove(this)));
            uiElements.AddRange(buttonList);
            ActiveButtonID = 0;
        }

        void NewGameMethod()
        {
            SceneManager.Add(new GameScene(new Logic()));
        }

        protected void drawLogo()
        {
            logo = File.ReadAllLines("Logo.txt");
            int offset = Console.BufferWidth / 2 - logo[0].Length / 2;

            for (int counter = 0; counter < logo.Length; counter++)
            {
                Console.SetCursorPosition(offset, counter + 5);
                Console.Write(logo[counter]);
            }
        }

        internal override void Update()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Escape:
                        SceneManager.Remove(this);
                        break;
                    case ConsoleKey.DownArrow:
                        ActiveButtonID++;
                        break;
                    case ConsoleKey.UpArrow:
                        ActiveButtonID--;
                        break;
                    default:
                        buttonList[ActiveButtonID].HandleInput(key);
                        break;
                }
            }
        }
    }
}
