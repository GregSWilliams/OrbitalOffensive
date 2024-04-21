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
            Window window = new Window("Orbital Offensive", 800, 600);
            bool running = true;

            ObjectsManager objMan = new ObjectsManager();
            objMan.SpawnAll();

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);

                if (SplashKit.KeyTyped(KeyCode.QKey))
                {
                    SplashKit.CloseAllWindows();
                    running = false;
                }


                objMan.PlayerManager.CheckForInput();

                SplashKit.DrawAllSprites();
                SplashKit.UpdateAllSprites();

                SplashKit.RefreshScreen(60);
            } while (running);
        }
    }
}
