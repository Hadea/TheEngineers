using System;
using System.Collections.Generic;

namespace TicTacToeConsoleUI
{
    internal class SceneManager
    {
        protected static List<Scene> sceneList = new();
        public static int SceneCount { get => sceneList.Count;}
        protected static FPSCounter fps = new();
        internal static void Add(Scene SceneToAdd)
        {
            sceneList.Add(SceneToAdd);
        }

        internal static void Draw()
        {
            fps.Draw();
            sceneList[sceneList.Count - 1].Draw();
        }

        internal static void Update()
        {
            fps.Update();
            sceneList[sceneList.Count - 1].Update();
        }

        internal static void Remove(Scene SceneToRemove)
        {
            sceneList.Remove(SceneToRemove);
        }
    }
}
