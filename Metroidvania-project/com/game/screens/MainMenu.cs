using System;
using com.mrmichelr;

namespace com.game.screens
{
    public class MainMenu
    {
        public PassObject clickPlay, clickExit;

        public MainMenu(PassObject _clickPlay, PassObject _clickExit)
        {
            clickPlay = _clickPlay;
            clickExit = _clickExit;

        }

        public virtual void Update()
        {
            clickPlay(1);
        }

        public virtual void Draw()
        {

        }
    }
}
