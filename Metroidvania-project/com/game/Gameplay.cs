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
                    worldGenerator = new WorldGenerator(1, 3, 4, 5);

                    //Loading screen ?

                    gameplayState = 2;
                    break;

                case 2:
                    //Globals.debug("STATE 2: In Game", ConsoleColor.Blue);

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
                    break;
            }

        }
    }
}
