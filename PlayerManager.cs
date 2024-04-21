using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOffensive
{
    internal class PlayerManager
    {
        private Ship _player;
        private float _startX;
        private float _startY;

        public PlayerManager() 
        {
            _startX = SplashKit.ScreenWidth()/2;
            _startY = SplashKit.ScreenHeight()-64;
        }

        public void SpawnPlayer()
        {
            Bitmap bitmap = SplashKit.LoadBitmap("player", "Resources\\player.png");
            _player = new Ship(new string[] { "player" }, bitmap, _startX, _startY, 20f);
        }
    }
}
