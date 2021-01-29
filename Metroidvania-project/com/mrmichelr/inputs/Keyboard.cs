using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace com.mrmichelr.inputs
{
    public class Keyboard
    {

        public KeyboardState newKeyboard, oldKeyboard;

        public List<Key> pressedKeys = new List<Key>(), previousPressedKeys = new List<Key>();

        public Keyboard()
        {

        }

        public virtual void Update()
        {
            newKeyboard = Microsoft.Xna.Framework.Input.Keyboard.GetState();

            GetPressedKeys();

        }

        public void UpdateOld()
        {
            oldKeyboard = newKeyboard;

            previousPressedKeys = new List<Key>();
            for (int i = 0; i < pressedKeys.Count; i++)
            {
                previousPressedKeys.Add(pressedKeys[i]);
            }
        }


        public bool GetPress(string _key)
        {

            for (int i = 0; i < pressedKeys.Count; i++)
            {

                if (pressedKeys[i].key == _key)
                {
                    return true;
                }

            }


            return false;
        }


        public virtual void GetPressedKeys()
        {
            bool found = false;

            pressedKeys.Clear();
            for (int i = 0; i < newKeyboard.GetPressedKeys().Length; i++)
            {

                pressedKeys.Add(new Key(newKeyboard.GetPressedKeys()[i].ToString(), 1));

            }
        }

        public bool GetSinglePress(string _key)
        {

            for (int i = 0; i < pressedKeys.Count; i++)
            {
                bool isIn = false;

                for (int j = 0; j < previousPressedKeys.Count; j++)
                {
                    if (pressedKeys[i].key == previousPressedKeys[j].key)
                    {
                        isIn = true;
                        break;
                    }
                }


                if (!isIn && (pressedKeys[i].key == _key || pressedKeys[i].print == _key))
                {
                    return true;
                }
            }



            return false;
        }

    }
}
