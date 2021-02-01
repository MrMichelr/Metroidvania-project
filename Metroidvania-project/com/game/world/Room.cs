using System;
using com.mrmichelr;

namespace com.game.world
{
    public class Room
    {
        public int X, Y;
        public int pick, numberOfRooms;
        public Room top, right, bottom, left;
        public int bitmask, ID;

        public static int tileWidth = 12;
        public static int tileHeight = 10;
        public int[][] tileMap;

        public Random percentTiles;
        public bool Keep33, Keep50 = false;

        public Room()
        {
            numberOfRooms = 6;
            percentTiles = new Random();

            bitmask = 0;

            tileMap = new int[tileWidth][];

        }


        public virtual void fillTileMap()
        {
            bool Flip = false;
            bool HaveASecret = false;

            if (percentTiles.Next(0,100) < 25) { HaveASecret = true; }
            if (percentTiles.Next(0,100) < 33) { Keep33 = true; }
            if (percentTiles.Next(0,100) < 50) { Keep50 = true; }
            if (percentTiles.Next(0,100) > 50) { Flip = true; }

            switch (pick)
            {
                case 0:
                    TranslateTextToRoom(Flip, HaveASecret);
                    break;

                case 1:
                    TranslateTextToRoom(Flip, HaveASecret);
                    break;

                case 2:
                    TranslateTextToRoom(Flip, HaveASecret);
                    break;

                case 3:
                    TranslateTextToRoom(Flip, HaveASecret);
                    break;

                case 4:
                    TranslateTextToRoom(Flip, HaveASecret);
                    break;

                case 5:
                    Globals.debug("Placing firstroom (TYPE 5)");
                    TranslateTextToRoom(Flip, HaveASecret);
                    break;

                case 6:
                    TranslateTextToRoom(Flip, HaveASecret);
                    break;

            }

        }

        public virtual void TranslateTextToRoom(bool _isFlip, bool _HasASecret)
        {
            Globals.debug("Room: " + pick + "-----------------------", ConsoleColor.Magenta);
            Globals.debug("Flip ?: " + _isFlip, ConsoleColor.DarkMagenta);
            Globals.debug("Have a secret: " + _HasASecret, ConsoleColor.DarkMagenta);

            //test:

            
        }
    }
}
