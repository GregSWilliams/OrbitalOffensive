using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace OrbitalOffensive
{
    internal class TextManager
    {
        private Font _font;

        public TextManager() 
        {
            _font = SplashKit.LoadFont("retrotech", "Resources\\RETROTECH.ttf");
        }

        public void DrawScore(int score)
        {
            string scoreText = String.Format("Score: {0}", score);
            SplashKit.DrawText(scoreText, Color.BrightGreen, _font, 60, 10, 10);
        }

        public void DrawLife(int life)
        {
            SplashKit.DrawText("Life:", Color.BrightGreen, _font, 60, 600, 10);
            Bitmap bitmap = SplashKit.LoadBitmap("player", "Resources\\player.png");
            int x = 680;
            int y = 15;
            for (int i = 0; i < life; i++) 
            {
                x = x + bitmap.Width + 12;
                SplashKit.DrawBitmap(bitmap, x, y);
            }
        }

        public void DrawGameOver(GameState gameState, int score)
        {
            SplashKit.DrawText("GAME OVER", Color.BrightGreen, _font, 60, 350, 275);
            switch (gameState)
            {
                case GameState.PlayerWins:
                    SplashKit.DrawText("PLAYER WINS", Color.BrightGreen, _font, 60, 320, 350);
                    SplashKit.DrawText(string.Format("Score: {0}", score), Color.BrightGreen, _font, 60, 330, 420);
                    break;
                case GameState.PlayerLoses:
                    SplashKit.DrawText("YOU LOSE", Color.BrightGreen, _font, 60, 370, 350);
                    break;
            }
        }
    }
}
