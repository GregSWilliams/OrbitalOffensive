using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalOffensive
{
    internal class ObjectsManager
    {
        private PlayerManager _playerManager;
        private EnemyManager _enemyManager;
        private ProjectileManager _playerProjManager;
        private ProjectileManager _enemyProjManager;
        private ObstacleManager _obstacleManager;

        public ObjectsManager()
        {
            _playerProjManager = new ProjectileManager();
            _enemyProjManager = new ProjectileManager();
            _playerManager = new PlayerManager(_playerProjManager);
            _enemyManager = new EnemyManager(_enemyProjManager);
            _obstacleManager = new ObstacleManager();
        }

        public PlayerManager PlayerManager
        {
            get
            {
                return _playerManager;
            }
        }

        public EnemyManager EnemyManager
        {
            get
            {
                return _enemyManager;
            }
        }

        public void SpawnAll()
        {
            _playerManager.SpawnPlayer();
            _enemyManager.SpawnShips();
            _obstacleManager.SpawnObstacles();
        }

        public void Update()
        {
            _playerManager.Update();
            _enemyManager.UpdateEnemies();
            _playerProjManager.Update();
            _enemyProjManager.Update();
            CheckForCollisions();
        }

        public void CheckForCollisions()
        {
            foreach (Projectile p in _playerProjManager.Projectiles)
            {
                foreach (Ship s in _enemyManager.EnemyShips)
                {
                    if (p.CheckCollision(s.Sprite) && s.AreYou("enemy"))
                    {
                        p.Destroy();
                        s.Destroy();
                        _enemyManager.RemoveShip(s);
                        _playerProjManager.RemoveProjectile(p);
                        return;
                    }
                }
            }

            foreach (Projectile p in _enemyProjManager.Projectiles)
            {
                Ship player = _playerManager.Player;
                if (p.CheckCollision(player.Sprite) && player.AreYou("player"))
                {
                    if (player.Health >= 1)
                    {
                        player.TakeDamage(1);
                    }
                    else
                    {
                        player.Destroy();
                        //game over
                    }
                    p.Destroy();
                    _enemyProjManager.RemoveProjectile(p);
                    return;
                }
            }

            foreach (Projectile p in _enemyProjManager.Projectiles)
            {
                foreach (Obstacle ob in _obstacleManager.Obstacles)
                {
                    foreach (ObstaclePart op in ob.ObstacleParts)
                    {
                       if (p.CheckCollision(op.Sprite))
                        {
                            p.Destroy();
                            op.Destroy();
                            ob.RemovePart(op);
                            _enemyProjManager.RemoveProjectile(p);
                            return;
                        }
                    }
                }
            }

            foreach (Projectile p in _playerProjManager.Projectiles)
            {
                foreach (Obstacle ob in _obstacleManager.Obstacles)
                {
                    foreach (ObstaclePart op in ob.ObstacleParts)
                    {
                        if (p.CheckCollision(op.Sprite))
                        {
                            p.Destroy();
                            op.Destroy();
                            ob.RemovePart(op);
                            _playerProjManager.RemoveProjectile(p);
                            return;
                        }
                    }
                }
            }
        }
    }
}
