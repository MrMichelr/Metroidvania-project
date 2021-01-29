using System;
using com.mrmichelr.inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace com.mrmichelr
{
    public delegate void PassObject(object i);
    public delegate object PassObjectAndReturn(object i);

    public class Globals
    {
        public static bool DEBUGGING;

        public static ContentManager content;
        public static SpriteBatch spriteBatch;
        public static GameTime gameTime;

        public static int screenHeight, screenWidth, gameState = 0;

        public static Keyboard keyboard;
        public static MouseControl mouse;

        public static System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");

        public Globals()
        {
        }

        #region Debugging

        public static void debug(string _message)
        {
            if (DEBUGGING)
            {
                Console.WriteLine("Debug: " + _message);
            }
        }

        public static void debug(object _object)
        {
            if (DEBUGGING)
            {
                Console.WriteLine("Debug: " + _object);
            }
        }

        public static void debug(string _message, ConsoleColor _color)
        {
            if (DEBUGGING)
            {
                Console.ForegroundColor = _color;
                Console.WriteLine("Debug: " + _message);
            }
        }

        #endregion

        #region Methods

        public static float GetDistance(Vector2 _position, Vector2 _target)
        {
            return (float)Math.Sqrt(Math.Pow(_position.X - _target.X, 2) + Math.Pow(_position.Y - _target.Y, 2));
        }

        public static Vector2 RadialMovement(Vector2 _focus, Vector2 _position, float speed)
        {
            float dist = Globals.GetDistance(_position, _focus);

            if (dist <= speed)
            {
                return _focus - _position;
            }
            else
            {
                return (_focus - _position) * speed / dist;
            }
        }


        public static float RotateTowards(Vector2 _position, Vector2 _focus)
        {

            float h, sineTheta, angle;
            if (_position.Y - _focus.Y != 0)
            {
                h = (float)Math.Sqrt(Math.Pow(_position.X - _focus.X, 2) + Math.Pow(_position.Y - _focus.Y, 2));
                sineTheta = (float)(Math.Abs(_position.Y - _focus.Y) / h); //* ((item._position.Y-_focus.Y)/(Math.Abs(item._position.Y-_focus.Y))));
            }
            else
            {
                h = _position.X - _focus.X;
                sineTheta = 0;
            }

            angle = (float)Math.Asin(sineTheta);

            // Drawing diagonial lines here.
            //Quadrant 2
            if (_position.X - _focus.X > 0 && _position.Y - _focus.Y > 0)
            {
                angle = (float)(Math.PI * 3 / 2 + angle);
            }
            //Quadrant 3
            else if (_position.X - _focus.X > 0 && _position.Y - _focus.Y < 0)
            {
                angle = (float)(Math.PI * 3 / 2 - angle);
            }
            //Quadrant 1
            else if (_position.X - _focus.X < 0 && _position.Y - _focus.Y > 0)
            {
                angle = (float)(Math.PI / 2 - angle);
            }
            else if (_position.X - _focus.X < 0 && _position.Y - _focus.Y < 0)
            {
                angle = (float)(Math.PI / 2 + angle);
            }
            else if (_position.X - _focus.X > 0 && _position.Y - _focus.Y == 0)
            {
                angle = (float)Math.PI * 3 / 2;
            }
            else if (_position.X - _focus.X < 0 && _position.Y - _focus.Y == 0)
            {
                angle = (float)Math.PI / 2;
            }
            else if (_position.X - _focus.X == 0 && _position.Y - _focus.Y > 0)
            {
                angle = (float)0;
            }
            else if (_position.X - _focus.X == 0 && _position.Y - _focus.Y < 0)
            {
                angle = (float)Math.PI;
            }

            return angle;
        }

        #endregion
    }
}
