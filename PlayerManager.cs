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
        private ProjectileManager _projManager;

        public PlayerManager(ProjectileManager projMan) 
        {
            _startX = SplashKit.ScreenWidth()/2;
            _startY = SplashKit.ScreenHeight()-64;
            _projManager = projMan;
        }

        public void SpawnPlayer()
        {
            Bitmap bitmap = SplashKit.LoadBitmap("player", "Resources\\player.png");
            _player = new Ship(new string[] { "player", "ship" }, bitmap, _startX, _startY, 5f);
        }

        public void CheckForInput()
        {
            if (SplashKit.KeyDown(KeyCode.LeftKey) || SplashKit.KeyDown(KeyCode.AKey))
            {
                if (_player.X > 0)
                { 
                    _player.X = _player.X - _player.Speed;
                }
            }
            if (SplashKit.KeyDown(KeyCode.RightKey) || SplashKit.KeyDown(KeyCode.DKey))
            {
                if (_player.X < (SplashKit.ScreenWidth() - 60))
                {
                    _player.X = _player.X + _player.Speed;
                }
            }
            if (SplashKit.KeyDown(KeyCode.SpaceKey))
            {
                Fire();
            }
        }

        public void Fire()
        {
            Bitmap bitmap = SplashKit.LoadBitmap("player", "Resources\\player.png");
            float projX = _player.X;
            float projY = _player.Y;
            Projectile projectile = new Projectile(new string[] { "player", "projectile" }, bitmap, projX, projY, 5f);
            _projManager.AddProjectile(projectile);
        }
    }
}
