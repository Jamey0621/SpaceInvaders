using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Engine;

namespace Space_Invaders.Gane_Content
{
    public class Bullet : GameObject
    {
        private float deathTimer = 3f;
        private float timer;
        private float speed = 4f;


        public Bullet(Texture2D _texture, Vector2 _pos, Vector2 _scale, string _tag) : base(_texture, _pos, _scale, _tag)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, GetRect(), Color.White);
        }

        public override void Update()
        {
            timer += MainManager.deltaTime;
            if (timer >= deathTimer)
            {
                this.isVisible = false;
            }
            Velocity.Y -= 1f * speed;
            Position += Velocity;
            Velocity = Vector2.Zero;

            CheckCollision();

        }

        private void CheckCollision()
        {
            for (int i = 0; i < SceneManager.currentScene.gameObjects.Count; i++)
            {
                GameObject currentEnemy = SceneManager.currentScene.gameObjects[i];
                if (currentEnemy.tag == "Enemy" && currentEnemy.isVisible)
                {
                    if (IsCollison(currentEnemy))
                    {
                        MainManager.score += 1;
                        currentEnemy.isVisible = false;
                        this.isVisible = false;
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
