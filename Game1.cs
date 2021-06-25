using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Space_Invaders.Engine;
using System;

namespace Space_Invaders
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.TargetElapsedTime = new TimeSpan(333333);
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Loader.Init(this);//need to pass the Game1 to the Loader

            MainManager.screenWidth = graphics.PreferredBackBufferWidth;
            MainManager.screenHeight = graphics.PreferredBackBufferHeight;

            SceneManager.LoadScenes();//load all the scenes
            SceneManager.ChangeScene(MainManager.firstScene);//start the first scene in the list
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            MainManager.deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;//setting delta time

            Input.UpdateInput();//updating the Input keyboard stuff

            SceneManager.UpdateScene();

            IsMouseVisible = MainManager.showCursor;//should we show/hide the cursor

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            SceneManager.DrawScene(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
