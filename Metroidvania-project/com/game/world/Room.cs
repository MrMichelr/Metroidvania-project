using System;
using com.mrmichelr;

namespace com.game.world
{
    public class Room
    {
        public int X, Y;
        public int pick, numberOfRooms;

        public Room()
        {
            numberOfRooms = 6;
            

            switch (pick)
            {
                case 0:
                    Console.Write("0");
                    break;

                case 1:
                    Console.Write("1");
                    break;
                    
                case 2:
                    Console.Write("2");
                    break;
                    
                case 3:
                    Console.Write("3");
                    break;
                    
                case 4:
                    Console.Write("4");
                    break;
                    
                case 5:
                    Console.Write("5");
                    break;
                    
                case 6:
                    Console.Write("6");
                    break;

            }
        }
    }
}
