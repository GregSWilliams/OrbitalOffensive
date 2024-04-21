using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrbitalOffensive
{
    internal class EnemyManager
    {
        private List<Ship> _enemyShips;
        private List<Bitmap> _enemyBitmaps;
        private SplashKitSDK.Timer _timer;
        private int _moveCount;
        private bool _firstMove;
        private int _timeBetweenTicks;

        public EnemyManager()
        {
            _enemyShips = new List<Ship>();
            _enemyBitmaps = new List<Bitmap>();
            _enemyBitmaps.Add(SplashKit.LoadBitmap("green", "Resources\\green.png"));
            _enemyBitmaps.Add(SplashKit.LoadBitmap("yellow", "Resources\\yellow.png"));
            _enemyBitmaps.Add(SplashKit.LoadBitmap("red", "Resources\\red.png"));
            _timer = SplashKit.CreateTimer("MoveTimer");
            _moveCount = 0;
            _firstMove = true;
            _timeBetweenTicks = 1000;
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
                    if(i == 11 || i == 33)
                    {
                        enemyBitmapIndex++;
                    }
                }
                int x = (60 * rowCount) + xOffset;
                Ship ship = new Ship(new string[] { "enemy", "ship" }, _enemyBitmaps[enemyBitmapIndex], x, y, 20f);
                AddShip(ship);
                rowCount++;
            }

            _timer.Start();
        }

        public void Move()
        {
            if (SplashKit.TimerNamed("MoveTimer").Ticks > _timeBetweenTicks)
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
                SplashKit.ResetTimer("MoveTimer");
                _moveCount++;
            }
        }

    }
}
