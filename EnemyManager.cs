using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrbitalOffensive
{
    internal class EnemyManager
    {
        private List<Ship> _enemyShips;
        private List<Bitmap> _enemyBitmaps;
        private SplashKitSDK.Timer _moveTimer;
        private int _moveCount;
        private bool _firstMove;
        private int _timeBetweenTicks;
        private ProjectileManager _projManager;
        private SplashKitSDK.Timer _fireTimer;

        public EnemyManager(ProjectileManager projMan)
        {
            _enemyShips = new List<Ship>();
            _enemyBitmaps = new List<Bitmap>();
            _enemyBitmaps.Add(SplashKit.LoadBitmap("green", "Resources\\green.png"));
            _enemyBitmaps.Add(SplashKit.LoadBitmap("yellow", "Resources\\yellow.png"));
            _enemyBitmaps.Add(SplashKit.LoadBitmap("red", "Resources\\red.png"));
            _moveTimer = SplashKit.CreateTimer("EnemyMoveTimer");
            _moveCount = 0;
            _firstMove = true;
            _timeBetweenTicks = 1000;
            _projManager = projMan;
            _fireTimer = SplashKit.CreateTimer("EnemyFireTimer");
        }

        public List<Ship> EnemyShips
        {
            get
            {
                return _enemyShips;
            }
        }

        public int RemainingShips
        {
            get
            {
                return _enemyShips.Count;
            }
        }

        public void AddShip(Ship ship)
        {
            _enemyShips.Add(ship);
        }

        public void RemoveShip(Ship ship) 
        {
            _enemyShips.Remove(ship);
        }

        public void SpawnShips()
        {
            int shipsToSpawn = 55;
            int rows = 5;
            int y = _enemyBitmaps[0].Height * 3;
            int rowCount = 0;
            int enemyBitmapIndex = 0;
            int xOffset = (SplashKit.ScreenWidth() - (58 * 11)) / 2;

            for (int i = 0; i < shipsToSpawn; i++) 
            {
                if (i != 0 && i % (shipsToSpawn/rows) == 0)
                {
                    rowCount = 0;
                    y = y + 60;
                    if (i == 11 || i == 33)
                    {
                        enemyBitmapIndex++;
                    }
                }
                int x = (60 * rowCount) + xOffset;
                Ship ship = new Ship(new string[] { "enemy", "ship" }, _enemyBitmaps[enemyBitmapIndex], x, y, 20f, 1);
                AddShip(ship);
                rowCount++;
            }

            _moveTimer.Start();
            _fireTimer.Start();
        }

        public void UpdateEnemies()
        {
            if (RemainingShips >= 1)
            {
                Move();
                Fire();
            }
        }

        public void Move()
        {
            if (SplashKit.TimerNamed("EnemyMoveTimer").Ticks > _timeBetweenTicks)
            {
                foreach (Ship ship in _enemyShips)
                {
                    if ((_moveCount == 8 && _firstMove == true) || _moveCount == 16)
                    {
                        foreach (Ship s in _enemyShips)
                        {
                            s.Speed = s.Speed * -1;
                            s.Y = s.Y + 30;
                        }
                        _moveCount = 0;
                        _firstMove = false;
                        if (_timeBetweenTicks > 100)
                        {
                            _timeBetweenTicks = _timeBetweenTicks - 100;
                        }
                    }
                    ship.X = ship.X + ship.Speed;
                }
                SplashKit.ResetTimer("EnemyMoveTimer");
                _moveCount++;
            }
        }

        public void Fire()
        {
            if (SplashKit.TimerTicks(_fireTimer) > 1000)
            {
                Random random = new Random();
                int rand = random.Next(0, RemainingShips);
                Bitmap bitmap = SplashKit.LoadBitmap("projectile2", "Resources\\projectile2.png");
                float projX = _enemyShips[rand].X + (_enemyShips[rand].Sprite.Width / 2) - (bitmap.Width / 2); ;
                float projY = _enemyShips[rand].Y + bitmap.Height;
                Projectile projectile = new Projectile(new string[] { "enemy", "projectile" }, bitmap, projX, projY, -5f, 1);
                _projManager.AddProjectile(projectile);
                SplashKit.ResetTimer(_fireTimer);   
            }
        }

        public bool ReachedBottom()
        {
            if (_enemyShips.Count > 1)
            {
                if (_enemyShips.Last().Y >= 600)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
