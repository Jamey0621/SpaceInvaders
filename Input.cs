using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Space_Invaders
{
   public static class Input
    {
        private static KeyboardState currentKeyboard;
        private static KeyboardState previouseKeyboard;

        private static MouseState previouseMouse;
        private static MouseState currentMouse;
        private static Vector2 mousePosition;

        //-------------Game1 calls this function every frame to update which keys are pressed/release
        public static void UpdateInput()
        {
            previouseKeyboard = currentKeyboard;
            currentKeyboard = Keyboard.GetState();

            previouseMouse = currentMouse;
            currentMouse = Mouse.GetState();

            //current mouse position is a Point, and we are using a Vector2 to represent our current mousePos
            //so we have to set the values this way
            mousePosition.X = currentMouse.Position.X;
            mousePosition.Y = currentMouse.Position.Y;

            if (GetKeyDown(Keys.P))//show/hide mouse cursor key
            {
                MainManager.showCursor = !MainManager.showCursor;
            }
        }


        //------------Keyboard Stuff
        public static bool GetKeyDown(Keys _key)
        {
            if (currentKeyboard.IsKeyDown(_key) && previouseKeyboard.IsKeyUp(_key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool GetKeyUp(Keys _key)
        {
            if (currentKeyboard.IsKeyUp(_key) && previouseKeyboard.IsKeyDown(_key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool GetKey(Keys _key)
        {
            if (previouseKeyboard.IsKeyDown(_key) && currentKeyboard.IsKeyDown(_key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //-----------------Mouse Stuff
        public static bool MouseButtonDown(int _index)//LMB = 0, RMB = 1;
        {
            if (currentMouse.LeftButton == ButtonState.Pressed && previouseMouse.LeftButton == ButtonState.Released && _index == 0)
            {
                //lmb
                return true;
            }

            if (currentMouse.RightButton == ButtonState.Pressed && previouseMouse.RightButton == ButtonState.Released && _index == 1)
            {
                //rmb
                return true;
            }

            return false;

        }

        public static bool MouseButtonUp(int _index)//LMB = 0, RMB = 1;
        {
            if (currentMouse.LeftButton == ButtonState.Released && previouseMouse.LeftButton == ButtonState.Pressed && _index == 0)
            {
                //lmb
                return true;
            }

            if (currentMouse.RightButton == ButtonState.Released && previouseMouse.RightButton == ButtonState.Pressed && _index == 1)
            {
                //rmb
                return true;
            }

            return false;

        }

        public static Vector2 GetMousePosition()
        {
            return mousePosition;
        }
    }
}
