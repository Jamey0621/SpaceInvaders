using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Space_Invaders.Engine;


namespace Space_Invaders.UI
{
    public class Button : GameObject
    {
        private Color DrawColor;
        private Color normalColor = Color.Gray;
        private Color highlightColor = Color.Yellow;
        public event EventHandler Click;
        public string text;
        private SpriteFont font;

        public Button(Texture2D _texture, Vector2 _pos, Vector2 _scale, string _text, string _tag) : base(_texture, _pos, _scale, _tag)
        {
            isCollidable = false;//need to set this here because by default it IS collidable
            text = _text;
            font = Loader.GetFont("font");
        }

        //-------------Draw / Update

        public override void Update()
        {
            if (MouseIntersects())
            {
                MouseEnter();
            }
            else
            {
                MouseExit();
            }

            if (MouseIntersects() && Input.MouseButtonDown(0))
            {
                Click?.Invoke(this, new EventArgs());//this is the click event 
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, GetRect(), DrawColor);
            spriteBatch.DrawString(font, text, FontPos(), Color.White);
        }

        //--------------------Helper for getting text centered on the button.....needs more work
        private Vector2 FontPos()
        {
            Vector2 MiddlePoint = new Vector2(Position.X + Scale.X / 2, Position.Y + Scale.Y / 2);
            Vector2 textSize = font.MeasureString(text);
            Vector2 TextMiddlePoint = new Vector2(textSize.X / 2, textSize.Y / 2);
            Vector2 textPosition = new Vector2((int)(MiddlePoint.X - textSize.X), (int)(MiddlePoint.Y) - textSize.Y);
            return textPosition;
        }


        public virtual void MouseEnter()
        {
            DrawColor = highlightColor;
        }

        public virtual void MouseExit()
        {
            DrawColor = normalColor;
        }

        public virtual void MouseClick()//left this empty incase I wanted to change the color of the button when mouse was clicked
        {

        }

        //----------------Checks if mouse is over the button or not
        private bool MouseIntersects()
        {
            Vector2 mousePos = Input.GetMousePosition();
            Rectangle mouseRect = new Rectangle((int)mousePos.X, (int)mousePos.Y, 1, 1);
            if (mouseRect.Intersects(GetRect()))
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
