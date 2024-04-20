﻿using SplashKitSDK;
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

        Ship(string[] ids, Bitmap bitmap, float x, float y, float speed)
            : base (ids, bitmap, x, y)
        {
            Speed = speed;
        }

        public float Speed 
        {
            set
            {
                _speed = value;
            }
        }
    }
}
