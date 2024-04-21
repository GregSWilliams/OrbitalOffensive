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

        public ObjectsManager()
        {
            _playerManager = new PlayerManager();
            _enemyManager = new EnemyManager();
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
        }
    }
}
