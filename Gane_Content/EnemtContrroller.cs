using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Gane_Content
{
    public class EnemyController
    {
        private int enemiesWide;//how many enemies along the X Axis
        private int enemiesHight;//how many enemies alog the Y Axis
        private float spacing = 20f;//how far apart are they

        private int visibleEnemies;//use this later to determin a game over situation

        private List<GameObject> enemyList = new List<GameObject>();//use this later for a game over situation

        private Scene gameScene;//the scene this script belongs to

        public EnemyController(int _enemiesWide, int _enemiesHigh, Scene _gameScene)
        {
            enemiesWide = _enemiesWide;
            enemiesHight = _enemiesHigh;
            gameScene = _gameScene;
            GenEnemies();
        }

        private void GenEnemies()
        {
            Texture2D enemyTexture = Loader.GetTexture("invader_blue");//cache the texture 

            for (int x = 0; x < enemiesWide; x++)
            {
                for (int y = 0; y < enemiesHight; y++)
                {
                    Vector2 _scale = new Vector2(75f, 75f);//scale(size)
                    float xPos = ((_scale.X + spacing) * x) + 100f;//calculate x position
                    float yPos = ((_scale.Y + spacing) * y) + 100f;//calculate y position
                    GameObject enemy = new Enemy(enemyTexture, new Vector2(xPos, yPos), _scale, "Enemy");//make a new enemy
                    gameScene.AddGameobject(enemy);//adding enemy to the game scene
                    enemyList.Add(enemy);//add enemy to this list so we can easily count them later
                }
            }
        }


        public void CheckEnemyCount()
        {
            visibleEnemies = 0;//reset to zero

            for (int i = 0; i < enemyList.Count; i++)//count total visible enemies
            {
                GameObject currentEnemy = enemyList[i];

                if (currentEnemy.isVisible)
                {
                    visibleEnemies += 1;//add 1 for each visible enemy
                }
            }

            if (visibleEnemies == 0)//if visibleEnemies is still zero we have a game over
            {
                GenEnemies();
            }

        }
    }
}
