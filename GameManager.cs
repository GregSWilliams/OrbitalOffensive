using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (_gameState == GameState.Started) 
            {
                _objectsManager.Update();
                _textManager.DrawLife(_objectsManager.PlayerManager.GetHealth());
                _textManager.DrawScore(1000);
                SplashKit.DrawAllSprites();
                SplashKit.UpdateAllSprites();
            }
            else if (_gameState == GameState.PlayerWins || _gameState == GameState.PlayerLoses)
            {
                _textManager.DrawGameOver(_gameState);
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
