using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OrbitalOffensive
{
    public enum GameState
    {
        Started,
        PlayerWins,
        PlayerLoses,
        Quit
    }

    internal class GameManager
    {
        private GameState _gameState;
        private ObjectsManager _objectsManager;
        private TextManager _textManager;
        private bool _gameRunning;

        public GameManager() 
        {
            _gameState = GameState.Started;
            _gameRunning = true;
            _objectsManager = new ObjectsManager();
            _textManager = new TextManager();
            _objectsManager.SpawnAll();
        }

        public bool GameRunning
        {
            get
            {
                return _gameRunning;
            }
        }

        public void GameLoop()
        {
            int playerLife = _objectsManager.PlayerManager.GetHealth;
            int playerScore = _objectsManager.PlayerManager.GetScore;
            int enemiesRemaining = _objectsManager.EnemyManager.RemainingShips;
            bool enemiesReachedBottom = _objectsManager.EnemyManager.ReachedBottom();
            //debug
            Console.WriteLine(_objectsManager.PlayerManager.GetScore);
            if (playerLife <= 0 || enemiesReachedBottom) 
            {
                _gameState = GameState.PlayerLoses;
            }
            if (enemiesRemaining <= 0)
            {
                _gameState = GameState.PlayerWins;
            }
            if (_gameState == GameState.Started) 
            {
                _objectsManager.Update();
                _textManager.DrawLife(playerLife);
                _textManager.DrawScore(playerScore);
                SplashKit.DrawAllSprites();
                SplashKit.UpdateAllSprites();
            }
            else if ((_gameState == GameState.PlayerWins || _gameState == GameState.PlayerLoses) && _gameRunning)
            {
                _objectsManager.PlayerManager.StopTimer();
                _textManager.DrawGameOver(_gameState, playerScore);
            }
        }

        public void QuitGame()
        {
            _gameState = GameState.Quit;
            SplashKit.FreeAllSprites();
            SplashKit.CloseAllWindows();
            _gameRunning = false;
        }
    }
}
