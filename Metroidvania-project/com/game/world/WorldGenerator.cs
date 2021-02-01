using System;
using com.mrmichelr;

namespace com.game.world
{
    public class WorldGenerator
    {
        public static Room[,] rooms;
        public int[] tileMap;
        public static int rows, columns;
        public Random pickARoom;

        public int SpawnRoom;

        public int forceSunHeat;
        public int starGalaxy, starSystem, starID;

        public static int worldSeed, worldStartedSeed;


        public WorldGenerator(int _forceSunHeat, int _starGalaxy, int _starSystem, int _starID)
        {

            forceSunHeat = _forceSunHeat;
            starGalaxy = _starGalaxy;
            starSystem = _starSystem;
            starID = _starID;

            Initialize();

            GenerateWorld();

            //LoadRooms();

        }

        public virtual void Initialize()
        {
            pickARoom = new Random();

            rows = 3;
            columns = 3;
        }

        public virtual void GenerateWorld()
        {
            // Generate seed
            int seed = starGalaxy * 640 + starSystem * 16 + starID;

            worldSeed = seed;
            worldStartedSeed = seed;

            Globals.debug("PLANET #:" + seed);

            GenerateWorldName();

            GenerateGridRoom();

            SetupNature();

            SpawnRoom = pickARoom.Next(0, columns - 1);
            //player position = -1, -1

            DefineMainRoad(SpawnRoom);
            GenerateRooms();
            AssembleRooms();
        }

        public virtual void GenerateWorldName()
        {

        }

        public virtual void SetupNature()
        {

        }

        public virtual void GenerateGridRoom()
        {
            rooms = new Room[columns, rows];
            int id = 0;

            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    Room room = new Room();
                    room.X = x;
                    room.Y = y;
                    room.ID = id;

                    rooms[x, y] = room;
                    id++;
                }
            }

            // attribute neighboors
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (y > 0 && rooms[x, y - 1] != null)
                    {
                        rooms[x, y].top = rooms[x, y - 1];
                        rooms[x, y].bitmask += 1;

                        //Globals.debug("Room {" + x + ":" + y + "} -> Top Neighboor Room ID :" + rooms[x, y].top.ID, ConsoleColor.Yellow);
                    }
                    if (x < columns - 1 && rooms[x + 1, y] != null)
                    {
                        rooms[x, y].right = rooms[x + 1, y];
                        rooms[x, y].bitmask += 2;

                        //Globals.debug("Room {" + x + ":" + y + "} -> Right Neighboor Room ID :" + rooms[x, y].right.ID, ConsoleColor.Yellow);
                    }
                    if (y < rows - 1 && rooms[x, y + 1] != null)
                    {
                        rooms[x, y].bottom = rooms[x, y + 1];
                        rooms[x, y].bitmask += 4;

                        //Globals.debug("Room {" + x + ":" + y + "} -> Bottom Neighboor Room ID :" + rooms[x, y].bottom.ID, ConsoleColor.Yellow);
                    }
                    if (x > 0 && rooms[x - 1, y] != null)
                    {
                        rooms[x, y].left = rooms[x - 1, y];
                        rooms[x, y].bitmask += 8;

                        //Globals.debug("Room {" + x + ":" + y + "} -> Left Neighboor Room ID :" + rooms[x, y].left.ID, ConsoleColor.Yellow);
                    }
                }
            }

        }

        public static void DefineMainRoad(int _spawnRoom)
        {
            #region draft
            //bool firstRoom = true;
            //bool dropped = true;
            //int y = 0;

            //for (int x = 0; x < columns; x++)
            //{
            //    rooms[x, y].pick = 6;

            //    if(x == _spawnRoom)
            //    {
            //        Globals.debug("First Room:" + x + " " + y);
            //    }
            //}

            //y++;

            //int direction = -1;
            //int X = _spawnRoom;

            //while(y < rows)
            //{
            //    rooms[X, y].pick = 1;

            //    if (firstRoom)
            //    {
            //        rooms[X, y].pick = 5;
            //        firstRoom = false;

            //        direction = getMyRandombySeed(4);
            //        if (X < 2) { direction = 2; }
            //        else if (X >= columns - 2) { direction = 0; }

            //    }else if (dropped)
            //    {
            //        dropped = false;
            //        rooms[X, y].pick = 3;
            //    }



            //    y++;
            //}

            //y--;

            //rooms[X, y].pick = 3;
            //Globals.debug("Room " + X + ":" + y);
            ////rooms[X, y].isLastRoom = true;


            //for (int x = 0; x < columns; x++)
            //{
            //    for (int Y = 0; Y < rows; Y++)
            //    {
            //        //for the rest
            //    }
            //}
            #endregion

            bool firstRoom = true;

        }

        public virtual void GenerateRooms()
        {
            int roomID = 0;
            foreach (var room in rooms)
            {
                room.fillTileMap();

                if (room.X == 0)
                {
                    //Change the top rooms

                    
                }
                
                roomID++;
            }

        }

        public virtual void AssembleRooms()
        {

        }

        public static int getMyRandombySeed(int value)
        {
            int result = worldSeed % value;
            return result;
        }


    }
}
