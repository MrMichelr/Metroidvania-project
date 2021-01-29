using System;
using com.mrmichelr;

namespace com.game.world
{
    public class WorldGenerator
    {
        public Room[,] rooms;
        public int[] tileMap;
        public int rows, columns;
        public static int myRandom;
        public Random pickARoom;

        public int forceSunHeat;
        public int starGalaxy, starSystem, starID;


        public WorldGenerator(int _forceSunHeat, int _starGalaxy, int _starSystem, int _starID)
        {

            Initialize();

            GenerateWorld();

            LoadRooms();

        }

        public virtual void Initialize()
        {
            pickARoom = new Random();

            rows = 3;
            columns = 3;
        }

        public virtual void LoadRooms()
        {
            rooms = new Room[columns, rows];

            Globals.debug("Room Picking -------------");

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    Room room = new Room();
                    room.X = x;
                    room.Y = y;

                    room.pick = pickARoom.Next(0, room.numberOfRooms);

                    rooms[x,y] = room;

                    Globals.debug(rooms[x, y].pick);
                }
            }

        }

        public virtual void GenerateWorld()
        {

        }

        public static int getMyRandom(int _value)
        {
            int result = myRandom % _value;
            int t = 1 + (myRandom ^ myRandom << 11);
            myRandom = myRandom ^ myRandom >> 19 ^ t ^ t >> 8;
            return result;
        }
    }
}
