using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Engine
{
   public abstract class Scene
    {
        public int sceneIndex;
        public string sceneName;
        public List<GameObject> gameObjects = new List<GameObject>();


        public Scene(int _id, string _name)
        {
            sceneIndex = _id;
            sceneName = _name;
            SceneManager.AddScene(this);
        }

        public void AddGameobject(GameObject _go)
        {
            gameObjects.Add(_go);
        }

        public abstract void LoadContent();
        public void UnloadContent()
        {
            gameObjects.Clear();
        }
        public virtual void UpdateScene()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].isVisible)
                {
                    gameObjects[i].Update();
                }
            }
        }
        public virtual void DrawScene(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].isVisible)
                {
                    gameObjects[i].Draw(spriteBatch);
                }
            }
        }
    }
}
