using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOffensive
{
    internal class Ship : GameObject
    {
        private float _speed;

        public Ship(string[] ids, Bitmap bitmap, float x, float y, float speed, int health)
            : base (ids, bitmap, x, y, health)
        {
            Speed = speed;
        }

        public float Speed 
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }
    }
}
