using System;
namespace com.mrmichelr.inputs
{
    public class Key
    {
        public int state;
        public string key, print, display;


        public Key(string _key, int _state)
        {
            key = _key;
            state = _state;
            MakePrint(key);
        }

        public virtual void Update()
        {
            state = 2;

        }


        public void MakePrint(string _key)
        {
            display = _key;

            string tempStr = "";

            if (_key == "A" || _key == "B" || _key == "C" || _key == "D" || _key == "E" || _key == "F" || _key == "G" || _key == "H" || _key == "I" || _key == "J" || _key == "K" || _key == "L" || _key == "M" || _key == "N" || _key == "O" || _key == "P" || _key == "Q" || _key == "R" || _key == "S" || _key == "T" || _key == "U" || _key == "V" || _key == "W" || _key == "X" || _key == "Y" || _key == "Z")
            {
                tempStr = _key;
            }
            if (_key == "Space")
            {
                tempStr = " ";
            }
            if (_key == "OemCloseBrackets")
            {
                tempStr = "]";
                display = tempStr;
            }
            if (_key == "OemOpenBrackets")
            {
                tempStr = "[";
                display = tempStr;
            }
            if (_key == "OemMinus")
            {
                tempStr = "-";
                display = tempStr;
            }
            if (_key == "OemPeriod" || _key == "Decimal")
            {
                tempStr = ".";
            }
            if (_key == "D1" || _key == "D2" || _key == "D3" || _key == "D4" || _key == "D5" || _key == "D6" || _key == "D7" || _key == "D8" || _key == "D9" || _key == "D0")
            {
                tempStr = _key.Substring(1);
            }
            else if (_key == "NumPad1" || _key == "NumPad2" || _key == "NumPad3" || _key == "NumPad4" || _key == "NumPad5" || _key == "NumPad6" || _key == "NumPad7" || _key == "NumPad8" || _key == "NumPad9" || _key == "NumPad0")
            {
                tempStr = _key.Substring(6);
            }


            print = tempStr;
        }
    }
}
