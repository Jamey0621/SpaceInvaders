using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Engine;
using Microsoft.Xna.Framework.Input;

namespace Space_Invaders.Gane_Content
{
   public class Player : GameObject
    {
        private float speed = 2f;
        private float shootTimer = 0f;
        private float timer;

        public Player(Texture2D _texture, Vector2 _pos, Vector2 _scale, string _tag) : base(_texture, _pos, _scale, _tag)
        {
            isVisible = true;
        }

        //-----------------Draw / Update
        public override void Update()
        {
            Move();
            Position += Velocity * speed;
            Velocity = Vector2.Zero;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, GetRect(), Color.White);
        }


        //--------------Core Mechanics

        private void Move()
        {
            if (Input.GetKey(Keys.Left))
            {
                Velocity.X -= 1;
            }

            if (Input.GetKey(Keys.Right))
            {
                Velocity.X += 1;
            }

            timer += MainManager.deltaTime;
            if (Input.GetKeyDown(Keys.Space))
            {
                Shoot();
                timer = 0f;
            }

            CheckCollision();

        }

        private void Shoot()
        {
            //handle shooting here
            float xPos = (Scale.X / 2f) + Position.X;
            float yPos = Position.Y;
            Bullet goBullet = new Bullet(Loader.GetTexture("missile"), new Vector2(xPos, yPos), new Vector2(10f, 20f), "Bullet");
            SceneManager.currentScene.AddGameobject(goBullet);
        }

        //-----------Collison Helpers

        private void CheckCollision()
        {
            for (int i = 0; i < SceneManager.currentScene.gameObjects.Count; i++)
            {
                GameObject currentEnemy = SceneManager.currentScene.gameObjects[i];
                if (currentEnemy.tag == "Enemy" && currentEnemy.isVisible)
                {
                    if (IsCollison(currentEnemy))
                    {
                        //trigger a game over
                        SceneManager.ChangeScene(2);
                    }
                }
            }
        }

        private bool IsCollison(GameObject _go)
        {
            Rectangle buttlet = GetRect();
            Rectangle enemy = _go.GetRect();

            if (buttlet.Intersects(enemy))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
