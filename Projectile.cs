using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOffensive
{
    internal class Projectile : GameObject
    {
        private SplashKitSDK.Timer _timer;

        public Projectile(string[] ids, Bitmap bitmap, float x, float y, float speed)
            : base(ids, bitmap, x, y)
        {
            _timer = SplashKit.CreateTimer("AliveTimer");
            _timer.Start();
        }

        public int AliveTime
        {
            get
            {
                return (int)_timer.Ticks;
            }
        }

        public bool CheckCollision(Sprite sprite)
        {
            return SplashKit.SpriteCollision(this.Sprite, sprite);
        }
    }
}
