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

        public ObjectsManager()
        {
            _playerManager = new PlayerManager();
        }

        PlayerManager PlayerManager
        {
            get
            {
                return _playerManager;
            }
        }

        public void SpawnAll()
        {
            _playerManager.SpawnPlayer();
        }
    }
}
