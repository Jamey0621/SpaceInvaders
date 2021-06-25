using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space_Invaders;
using Space_Invaders.Gane_Content;

namespace Space_Invaders.Engine
{
    public static class SceneManager
    {

        /// <summary>
        /// Controls what scene is currently playing 
        /// This is where you would initialize any scene
        /// 
        /// Notice we are not adding any scene to the List of scenes below
        /// Each scene will handle that on its own when it is created
        /// </summary>

        public static Scene currentScene;
        public static List<Scene> scenes = new List<Scene>();

        public static void LoadScenes()//add new scenes here.....
        {
            Scene main = new MainMenu(0, "MainMenu");
            Scene gameScene = new GameScene(1, "GameScene");
            Scene gameOver = new GameOver(2, "GameOver");
        }

        public static void AddScene(Scene _scene)
        {
            scenes.Add(_scene);
        }

        public static void ChangeScene(int _id)
        {
            if (currentScene != null)
            {
                currentScene.UnloadContent();
            }
            currentScene = scenes[_id];
            currentScene.LoadContent();
        }

        public static void UpdateScene()
        {
            currentScene.UpdateScene();
        }

        public static void DrawScene(SpriteBatch spriteBatch)
        {
            currentScene.DrawScene(spriteBatch);
        }

    }
}

