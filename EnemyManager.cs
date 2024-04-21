using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOffensive
{
    internal class EnemyManager
    {
        private List<Ship> _enemyShips;
        private List<Bitmap> _enemyBitmaps;

        public EnemyManager()
        {
            _enemyShips = new List<Ship>();
            _enemyBitmaps = new List<Bitmap>();
            _enemyBitmaps.Add(SplashKit.LoadBitmap("green", "Resources\\green.png"));
            _enemyBitmaps.Add(SplashKit.LoadBitmap("yellow", "Resources\\yellow.png"));
            _enemyBitmaps.Add(SplashKit.LoadBitmap("red", "Resources\\red.png"));
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
            int xOffset = SplashKit.ScreenWidth() - (60*12);

            for (int i = 0; i < shipsToSpawn; i++) 
            {
                if (i != 0 && i % (shipsToSpawn/rows) == 0)
                {
                    rowCount = 0;
                    y = (y+60);
                    if(i == 11 || i == 33)
                    {
                        enemyBitmapIndex++;
                    }
                }
                int x = (60 * rowCount) + xOffset;
                Ship ship = new Ship(new string[] { "enemy", "ship" }, _enemyBitmaps[enemyBitmapIndex], x, y, 5f);
                AddShip(ship);
                rowCount++;
            }
        }
    }
}
