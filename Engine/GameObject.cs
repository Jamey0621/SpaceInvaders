using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders.Engine
{
  public abstract class GameObject
    {
        public Texture2D texture;
        public Vector2 Position;
        public Vector2 Scale;
        public Vector2 Velocity;
        public bool isCollidable;
        public bool isVisible = true;
        public string tag;

        public GameObject(Texture2D _texture, Vector2 _pos, Vector2 _scale, string _tag)
        {
            texture = _texture;
            Position = _pos;
            Scale = _scale;
            tag = _tag;
            Velocity = Vector2.Zero;
        }
        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
        public Rectangle GetRect()
        {
            Rectangle r = new Rectangle((int)Position.X, (int)Position.Y, (int)Scale.X, (int)Scale.Y);
            return r;
        }
    }
}
