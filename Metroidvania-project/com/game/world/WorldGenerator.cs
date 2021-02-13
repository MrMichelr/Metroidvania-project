using System;
using com.mrmichelr;
using Microsoft.Xna.Framework;

namespace com.game.world
{
    public class WorldGenerator
    {
        public static Room[,] rooms;
        public int[] tileMap;
        public static int rows, columns;
        public static Random pickARoom, rNumber;

        public int SpawnRoom;

        public int forceSunHeat;
        public int starGalaxy, starSystem, starID;

        public static int worldSeed, worldStartedSeed;
        
        public static Vector2 TilebyRoom = new Vector2(18, 16);


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
            rNumber = new Random();

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
            AttributeNeighboor();
            GenerateRooms();
            RoomsToTileMap();
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
                    room.WorldSeed = worldSeed;
                    room.WorldStartedSeed = worldStartedSeed;

                    rooms[x, y] = room;
                    id++;
                }
            }



        }


        public void AttributeNeighboor()
        {
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
            /*  Room style
            **  0 = Side room, not on the main road
            **  1 = Room with at leat an exit at left and right
            °°  2 = Room with at leat an exit at left, right and bottom
            °°  3 = Room with at leat an exit at left, right and top
            */
            for (int x = 0; x < columns; x++)
            {
                if (x == _spawnRoom)
                {
                    rooms[x, 0].pick = 1;
                    rooms[x, 0].isMainPath = true;
                    rooms[x, 0].isPlayerSpawn = true;

                }
                rooms[x, 0].isSet = true;
                rooms[x, 0].isOutside = true;
            }

            int Y = 0;
            int X = _spawnRoom;
            while (Y < rows - 1)
            {

                int direction = getMyRandombySeed(5);
                Room lastSetRoom = rooms[X, Y];

                switch (direction + 1)
                {

                    case 1:
                        // left
                        //Globals.debug("left " + (direction + 1));
                        if (X <= 0)
                        {
                            X = 0;
                            Y = Y < rows ? Y++ : Y;
                        }
                        else
                        {
                            X--;
                        }
                        break;
                    case 2: goto case 1;
                    case 3:
                        // right
                        //Globals.debug("Right " + (direction + 1));
                        if (X >= columns - 1)
                        {
                            X = columns - 1;
                            Y = Y < rows ? Y++ : Y;
                        }
                        else
                        {
                            X++;
                        }
                        break;
                    case 4: goto case 3;
                    case 5:
                        // bottom
                        //Globals.debug("Bottom " + (direction + 1));
                        if (Y >= rows)
                        {
                            Y--;
                            rooms[X, Y].isLastRoom = true;
                            break;
                        }
                        else if (Y == rows - 1)
                        {
                            rooms[X, Y].isLastRoom = true;
                        }
                        else
                        {
                            Y++;
                            rooms[X, Y - 1].pick = 2;
                        }
                        break;

                }


                if (Y < rows && X < columns)
                {
                    rooms[X, Y].pick = lastSetRoom.pick == 2 ? 3 : 1;
                    rooms[X, Y].isSet = true;
                    rooms[X, Y].isMainPath = true;
                }

                //Globals.debug("direction: " + direction);
                //Globals.debug("X: " + X + " - Y: " + Y);
            }


        }

        public virtual void GenerateRooms()
        {
            int roomID = 0;
            foreach (var room in rooms)
            {
                if (!room.isSet)
                {
                    int condition = getMyRandombySeed(roomID) % 4;
                    room.pick = condition == 0 ? 4 : 0;

                    Globals.debug("Condition: " + condition);
                }


                roomID++;
                room.ID = roomID;
                room.fillTileMap();
            }

        }

        public virtual void RoomsToTileMap()
        {
            int mapWidth = columns * (int)TilebyRoom.X; //columns * number of tile by room
            int mapHeight = rows * (int)TilebyRoom.Y;

            for (int x = 0; x < mapWidth * mapHeight; x++)
            {
                //we add 2 line of sky
                if (x < mapWidth * 2)
                {
                    tileMap[x] = 0;
                }
            }

            tileMap = new int[mapWidth * mapHeight];
            // NOTE: 
            //TileMap[X,Y]
            //TileMap[X,Y] = 
            // roomX % columns = new line

        }

        public static int getMyRandombySeed(int value)
        {
            int result = (18 * worldSeed) % value;
            worldSeed = (worldSeed ^ value) + 18;
            return result;
        }


    }
}
