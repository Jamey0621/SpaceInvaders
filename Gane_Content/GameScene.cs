using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Engine;
using Microsoft.Xna.Framework;


namespace Space_Invaders.Gane_Content
{
  public class GameScene : Scene 
    {
        private SpriteFont font;
        private string text = "Score: ";
        private GameObject player;
        private EnemyController controller;

        public GameScene(int _id, string _name) : base(_id, _name)
        {
        }

        public override void LoadContent()
        {
            font = Loader.GetFont("font");
            player = new Player(Loader.GetTexture("ship"), new Vector2(200f, 100f), new Vector2(100f, 100f), "Player");
            player.Position.Y = MainManager.screenHeight - player.Scale.Y;
            gameObjects.Add(player);

            GenEnemy();
            MainManager.showCursor = false;
        }

        private void GenEnemy()
        {
            controller = new EnemyController(5, 2, this);
        }

        public override void UpdateScene()
        {
            controller.CheckEnemyCount();//have to check the enemy count so we can get a game over
            base.UpdateScene();
        }

        public override void DrawScene(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text + MainManager.score.ToString(), new Vector2(100f, 10f), Color.White);
            base.DrawScene(spriteBatch);
        }

    }
}
