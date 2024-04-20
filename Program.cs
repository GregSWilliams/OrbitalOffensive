using System;
using SplashKitSDK;

namespace OrbitalOffensive
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Orbital Offensive", 800, 600);

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);

                if (SplashKit.KeyTyped(KeyCode.QKey))
                {
                    SplashKit.CloseAllWindows();
                }

                SplashKit.RefreshScreen(60);
            } while (true);
        }
    }
}
