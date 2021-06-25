using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Engine;
using Space_Invaders.UI;
using Microsoft.Xna.Framework;


namespace Space_Invaders.Gane_Content
{
    public class GameOver : Scene
    {
        SpriteFont font;
        Button retryButton;
        Button mainMenu;
        public string text = "Game Over";

        public GameOver(int _id, string _name) : base(_id, _name)
        {
        }

        public override void LoadContent()
        {
            font = Loader.GetFont("TitleFont");

            retryButton = new Button(Loader.GetTexture("button"), new Vector2(200f, 200f), new Vector2(150f, 50f), "Retry", "Button");
            retryButton.Click += RetryButton_Click;

            mainMenu = new Button(Loader.GetTexture("button"), new Vector2(200f, 300f), new Vector2(150f, 50f), "Main Menu", "Button");
            mainMenu.Click += MainMenu_Click;

            mainMenu.Position.X = (MainManager.screenWidth / 2f) - (mainMenu.Scale.X / 2f);
            retryButton.Position.X = (MainManager.screenWidth / 2f) - (retryButton.Scale.X / 2f);

            SceneManager.currentScene.gameObjects.Add(retryButton);
            SceneManager.currentScene.gameObjects.Add(mainMenu);

            MainManager.showCursor = true;

        }


        //---------------click handlers for buttons

        private void MainMenu_Click(object sender, EventArgs e)
        {
            SceneManager.ChangeScene(0);
        }

        private void RetryButton_Click(object sender, EventArgs e)
        {
            MainManager.score = 0;
            SceneManager.ChangeScene(1);
        }


        //-------------Draw/Update

        public override void DrawScene(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, new Vector2(275f, 100f), Color.White);
            base.DrawScene(spriteBatch);
        }

        public override void UpdateScene()
        {
            base.UpdateScene();
        }
    }
}

