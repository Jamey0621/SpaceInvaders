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
   public class Enemy : GameObject
    {
        private Vector2 moveVector = new Vector2(1f, 0f);
        private float speed = 2f;

        public Enemy(Texture2D _texture, Vector2 _pos, Vector2 _scale, string _tag) : base(_texture, _pos, _scale, _tag)
        {
        }

        public override void Update()
        {
            if (Position.X <= 50f || Position.X >= 700f)
            {
                moveVector.X *= -1f;
                moveVector.Y += 10f;
                speed += 0.5f;
            }

            Position += moveVector * speed;
            moveVector.Y = 0f;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, GetRect(), Color.White);
        }
    }
}
