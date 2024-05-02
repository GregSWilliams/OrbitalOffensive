using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOffensive
{
    internal class ObstacleManager
    {
        private List<Obstacle> _obstacles;

        public ObstacleManager()
        {
            _obstacles = new List<Obstacle>();
        }

        public List<Obstacle> Obstacles
        {
            get
            {
                return _obstacles;
            }
        }

        public void SpawnObstacles()
        {
            _obstacles.Add(new Obstacle(150, 600));
            _obstacles.Add(new Obstacle(350, 600));
            _obstacles.Add(new Obstacle(550, 600));
            _obstacles.Add(new Obstacle(750, 600));
            foreach (Obstacle obs in _obstacles) 
            {
                obs.SpawnParts();
            }
        }
    }
}
