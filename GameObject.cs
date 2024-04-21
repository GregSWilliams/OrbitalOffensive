using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOffensive
{
    internal class GameObject : Object
    {
        private Sprite _sprite;
        private int _health;

        public GameObject(string[] ids, Bitmap bitmap, float x, float y, int health)
            : base(ids)
        {
            _sprite = SplashKit.CreateSprite(bitmap);
            X = x;
            Y = y;
            Health = health;
        }

        public float X
        {
            get
            {
                return _sprite.X;
            }
            set 
            { 
                _sprite.X = value;
            }
        }

        public float Y
        {
            get
            {
                return _sprite.Y;
            }
            set
            {
                _sprite.Y = value;
            }
        }

        public Sprite Sprite
        {
            get
            {
                return _sprite;
            }
        }

        public int Health
        {
            get 
            {
                return _health;
            }
            set
            {
                _health = value;
            }
        }

        public void TakeDamage(int damage)
        {
            Health = Health - damage;
        }

        public void Destroy()
        {
            SplashKit.FreeSprite(_sprite);
        }
    }
}
