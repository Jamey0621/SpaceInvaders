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
    class MainMenu : Scene
    {
        public Button playButton;
        public GameObject thing;
        private SpriteFont titleFont;

        public MainMenu(int _id, string _name) : base(_id, _name)
        {
        }

        public override void LoadContent()
        {
            titleFont = Loader.GetFont("TitleFont");

            playButton = new Button(Loader.GetTexture("Button"), new Vector2(190, 180), new Vector2(190, 60), "Play", "Button");
            playButton.Position.X = (MainManager.screenWidth / 2)  - (playButton.Scale.X / 2 );
            playButton.Click += PlayButton_Click;

            gameObjects.Add(playButton);

            MainManager.showCursor = true;
            MainManager.score = 0;
        }

        public override void UpdateScene()
        {
            base.UpdateScene();
        }

        public override void DrawScene(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(titleFont, "Welcome To Space Invaders", new Vector2(200, 40), Color.White);
            base.DrawScene(spriteBatch);
            spriteBatch.DrawString(titleFont, "Made By Jamey! Lets Get It", new Vector2(200, 400), Color.Red);

        }


        private void PlayButton_Click(object sender, EventArgs e)
        {
            //load the game scene
            SceneManager.ChangeScene(1);
        }

    }
}
