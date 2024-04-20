using System;
using System.Runtime.CompilerServices;
using SplashKitSDK;

namespace OrbitalOffensive
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Orbital Offensive", 800, 600);
            bool running = true;

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);

                if (SplashKit.KeyTyped(KeyCode.QKey))
                {
                    SplashKit.CloseAllWindows();
                    running = false;
                }

                SplashKit.UpdateAllSprites();

                SplashKit.RefreshScreen(60);
            } while (running);
        }
    }
}
