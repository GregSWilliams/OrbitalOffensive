using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOffensive
{
    internal class ObstaclePart : GameObject
    {
        public ObstaclePart(string[] ids, Bitmap bitmap, float x, float y, int health)
            : base (ids, bitmap, x, y, health)
        {
        }
    }
}
