using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOffensive
{
    internal class Obstacle
    {
        private List<ObstaclePart> _obstacleParts;
        private float _startX;
        private float _startY;
        private List<bool> _structure;

        public Obstacle(float x, float y)
        {
            _obstacleParts = new List<ObstaclePart>();
            _startX = x;
            _startY = y;
            _structure = new List<bool>() 
            {false, true, true, true, true, false,
            true, true, true, true, true, true,
            true, true, false, false, true, true,
            true, false, false, false, false, true,
            true, false, false, false, false, true};
        }

        public float StartX
        {
            set
            {
                _startX = value;
            }
        }

        public float StartY
        {
            set
            {
                _startY = value;
            }
        }

        public List<ObstaclePart> ObstacleParts
        {
            get
            {
                return _obstacleParts;
            }
        }

        public void SpawnParts()
        {
            Bitmap bitmap = SplashKit.LoadBitmap("obstacle", "Resources\\obstacle.png");
            float x = _startX;
            float y = _startY;
            for (int i = 0; i < 24; i++)
            {
                if (i % 6 == 0)
                {
                    x = _startX;
                    y = y + bitmap.Width;
                }
                else
                {
                    x = x + bitmap.Width;
                }
                if (_structure[i] == true)
                {
                    _obstacleParts.Add(new ObstaclePart(new string[] { "obstacle" }, bitmap, x, y, 1));
                }
            }
        }

        public void RemovePart(ObstaclePart op)
        {
            _obstacleParts.Remove(op);
        }
    }
}
