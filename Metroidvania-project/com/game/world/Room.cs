using System;
using com.mrmichelr;

namespace com.game.world
{
    public class Room
    {
        public int X, Y;
        public int pick;
        public Room top, right, bottom, left;
        public int bitmask, ID, direction, roomTypeID;
        public bool isOutside, isLastRoom, isMainPath, isPlayerSpawn, isSet = false;
        public Random percentTiles;
        public bool Keep33, Keep50 = false;
        public static int worldSeed, worldStartedSeed;

        public int WorldSeed { get => worldSeed; set => worldSeed = value;}
        public int WorldStartedSeed { get => worldStartedSeed; set => worldStartedSeed = value;}


        public Room()
        {
            pick = 0;
            percentTiles = new Random();

            bitmask = 0;
            worldSeed = worldStartedSeed = 0;
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
                    roomTypeID = getMyRandombySeed(1);
                    TranslateTextToRoom(roomTypeID, Flip, HaveASecret);
                    break;

                case 1:
                    roomTypeID = getMyRandombySeed(1);
                    TranslateTextToRoom(roomTypeID, Flip, HaveASecret);
                    break;

                case 2:
                    roomTypeID = getMyRandombySeed(1);
                    TranslateTextToRoom(roomTypeID, Flip, HaveASecret);
                    break;

                case 3:
                    roomTypeID = getMyRandombySeed(1);
                    TranslateTextToRoom(roomTypeID, Flip, HaveASecret);
                    break;

                case 4:
                    roomTypeID = getMyRandombySeed(1);
                    TranslateTextToRoom(roomTypeID, Flip, HaveASecret);
                    break;

            }

        }

        public virtual void TranslateTextToRoom(int _id, bool _isFlip, bool _HasASecret)
        {
            //load TextFile
            //Read File
            //Parse File
            
            

            //test:
            Globals.debug("Room: " + bitmask + "-----------------------", ConsoleColor.Magenta);
            Globals.debug("Room type: " + pick + "," + _id, ConsoleColor.Magenta);
            Globals.debug("is Main Path: " + isMainPath, ConsoleColor.Magenta);
            Globals.debug("Flip?: " + _isFlip, ConsoleColor.DarkMagenta);
            Globals.debug("Have a secret: " + _HasASecret, ConsoleColor.DarkMagenta);
            
        }

        public static int getMyRandombySeed(int value)
        {
            int result = (18 * worldSeed) % value;
            worldSeed = (worldSeed ^ value) + 18;
            return result;
        }
    }
}
