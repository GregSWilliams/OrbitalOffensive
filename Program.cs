using System;
using System.Numerics;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using SplashKitSDK;
using static System.Net.Mime.MediaTypeNames;

namespace OrbitalOffensive
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Orbital Offensive", 1000, 800);

            GameManager gameManager = new GameManager();

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);

                if (SplashKit.KeyTyped(KeyCode.QKey))
                {
                    gameManager.QuitGame();
                }

                gameManager.GameLoop();

                SplashKit.RefreshScreen(60);
            } while (gameManager.GameRunning);
        }
    }
}
