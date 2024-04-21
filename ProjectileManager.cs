using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOffensive
{
    internal class ProjectileManager
    {
        private List<Projectile> _projectiles;

        public ProjectileManager()
        {
            _projectiles = new List<Projectile>();
        }

        public List<Projectile> Projectiles
        {
            get
            {
                return _projectiles;
            }
        }

        public void AddProjectile(Projectile p)
        {

            _projectiles.Add(p);
        }

        public void RemoveProjectile(Projectile p) 
        { 
            _projectiles.Remove(p);
        }

        public void Update()
        {
            foreach (Projectile p in _projectiles) 
            {
                p.Y = p.Y - 10;
            }
        }
    }
}
