using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
   public static class Loader
    {
        private static Game1 game;

        public static void Init(Game1 _game)
        {
            game = _game;
        }

        public static Texture2D GetTexture(string _path)
        {
            Texture2D texture = game.Content.Load<Texture2D>(_path);
            return texture;
        }

        public static SpriteFont GetFont(string _path)
        {
            SpriteFont font;
                font = game.Content.Load<SpriteFont>("SpaceFont");
            return font;
        }
    }
}
