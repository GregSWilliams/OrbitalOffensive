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
        private ProjectileManager _projManager;
        private SplashKitSDK.Timer _fireTimer;
        private SplashKitSDK.Timer _scoreTimer;
        private int _score;

        public PlayerManager(ProjectileManager projMan) 
        {
            _projManager = projMan;
            _fireTimer = SplashKit.CreateTimer("FireTimer");
            _scoreTimer = SplashKit.CreateTimer("ScoreTimer");
            _score = 100000;
        }

        public Ship Player
        {
            get
            {
                return _player;
            }
        }

        public int GetHealth
        {
            get
            {
                return _player.Health;
            }
        }

        public int GetScore
        {
            get
            {
                return (_score - (int)_scoreTimer.Ticks);
            }
        }

        public void SpawnPlayer()
        {
            float _startX = SplashKit.ScreenWidth() / 2;
            float _startY = SplashKit.ScreenHeight() - 64;
            Bitmap bitmap = SplashKit.LoadBitmap("player", "Resources\\player.png");
            _player = new Ship(new string[] { "player", "ship" }, bitmap, _startX, _startY, 5f, 3);
            SplashKit.StartTimer(_fireTimer);
            SplashKit.StartTimer(_scoreTimer);
        }

        public void Update()
        {
            if (_player.Health > 0)
            {
                CheckForInput();
            }
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
                if (SplashKit.TimerTicks(_fireTimer) > 1000)
                {
                    Fire();
                    SplashKit.ResetTimer(_fireTimer);
                }
            }
        }

        public void Fire()
        {
            Bitmap bitmap = SplashKit.LoadBitmap("projectile1", "Resources\\projectile1.png");
            float projX = _player.X + (Player.Sprite.Width/2) - (bitmap.Width/2);
            float projY = _player.Y - bitmap.Height;
            Projectile projectile = new Projectile(new string[] { "player", "projectile" }, bitmap, projX, projY, 5f, 1);
            _projManager.AddProjectile(projectile);
        }

        public void StopTimer()
        {
            _scoreTimer.Pause();
        }
    }
}
