using System;
using com.game.world;
using com.mrmichelr;

namespace com.game
{
    public class Gameplay
    {
        int gameplayState;
        PassObject ChangeGameState;

        WorldGenerator worldGenerator;

        public Gameplay(PassObject _changeGameState)
        {
            gameplayState = 1; // Right now always new game

            ChangeGameState = _changeGameState;
        }

        public virtual void Update()
        {
            switch (gameplayState)
            {
                case 0:
                    Globals.debug("STATE 0: ", ConsoleColor.Blue);
                    break;

                case 1:
                    Globals.debug("STATE 1: New Game", ConsoleColor.Blue);

                    //World Generation
                    Random rd = new Random();
                    worldGenerator = new WorldGenerator(rd.Next(0,1000), rd.Next(0, 20), rd.Next(0, 200), rd.Next(0, 10));

                    //Loading screen ?

                    gameplayState = 2;
                    break;

                case 2:
                    //Globals.debug("STATE 2: In Game", ConsoleColor.Blue);
                    //world.Update();
                    break;
            }

        }

        public virtual void Draw()
        {
            switch (gameplayState)
            {
                case 0:
                    break;

                case 1:
                    //world.Draw();
                    break;
            }

        }
    }
}
