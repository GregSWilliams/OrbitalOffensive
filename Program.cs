using System;
using System.Numerics;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using SplashKitSDK;

namespace OrbitalOffensive
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Orbital Offensive", 1000, 800);
            bool running = true;

            ObjectsManager objMan = new ObjectsManager();
            objMan.SpawnAll();

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);

                if (SplashKit.KeyTyped(KeyCode.QKey))
                {
                    SplashKit.FreeAllSprites();
                    SplashKit.CloseAllWindows();
                    running = false;
                }

                objMan.Update();

                SplashKit.DrawAllSprites();
                SplashKit.UpdateAllSprites();

                SplashKit.RefreshScreen(60);
            } while (running);
        }
    }
}
