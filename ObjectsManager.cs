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

        public ObjectsManager()
        {
            _playerProjManager = new ProjectileManager();
            _enemyProjManager = new ProjectileManager();
            _playerManager = new PlayerManager(_playerProjManager);
            _enemyManager = new EnemyManager(_enemyProjManager);
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
        }

        public void Update()
        {
            _playerManager.CheckForInput();
            _enemyManager.Move();
            _playerProjManager.Update();
            _enemyProjManager.Update();
        }
    }
}
