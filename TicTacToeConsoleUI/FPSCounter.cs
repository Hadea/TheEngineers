using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsoleUI
{
    internal class FPSCounter
    {
        DateTime timeLastMeasure = DateTime.Now;
        int frameCount;
        public int LastFPS { get; protected set; }
        internal void Update()
        {
            frameCount++;
            if ((DateTime.Now - timeLastMeasure).TotalSeconds > 1d)
            {
                LastFPS = frameCount;
                frameCount = 0;
                timeLastMeasure = DateTime.Now;
            }
        }

        internal void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($"FPS: {LastFPS:D4}");
        }
    }
}
