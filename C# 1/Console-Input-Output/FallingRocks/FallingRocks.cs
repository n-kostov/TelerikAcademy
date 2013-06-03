using System;
using System.Threading;
using System.Collections;
class FallingRocks
{
    struct Position
    {
        public int x;
        public int y;
        //public Position()
        //{
        //    this.x = 0;
        //    this.y = 0;
        //}
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Block
    {
        public Position pos;
        public string chars;
        public Block()
        {
            chars = "";
        }
    }

    static void Main()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
        Position dwarf = new Position(Console.WindowHeight - 1, Console.WindowWidth/2);

        char[] symbols={'^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-'};
        ArrayList listOfSymbolBlocks =new ArrayList();
        Random randomGenerator =new Random();

        int points = 0;

        while (true)
        {
            Console.Clear();
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.y > 0)
                    {
                        dwarf.y -= 1;
                    }
                    Console.Clear();
                }
                if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.y < Console.WindowWidth-4)
                    {
                        dwarf.y += 1;

                    }
                    Console.Clear();
                }
                
            }

            for (int i = 0; i < listOfSymbolBlocks.Count;i++ )
            {
                //Block item = item;
                //listOfSymbolBlocks..pos.x += 1;
                Block item = listOfSymbolBlocks[i] as Block;
                if (item.pos.x >= dwarf.x)
                {
                    listOfSymbolBlocks.Remove(item);
                    points += 10;
                }
                else
                {
                    //listOfSymbolBlocks.Remove(item);
                    item.pos.x += 1;
                }
                if ((item.pos.x==dwarf.x) && (item.pos.y == dwarf.y))
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Game Over!!!Your points:{0}", points);
                    Console.ReadLine();
                    return;
                }
            }

                for (int i = 0; i < randomGenerator.Next(2, 4); i++)
                {
                    Block block=new Block();
                    block.pos.x = 0;
                    block.pos.y = randomGenerator.Next(0, Console.WindowWidth - 1);
                    block.chars = "";
                    int index = randomGenerator.Next(0, symbols.Length);
                    for (int j = 0; j < randomGenerator.Next(1, 3); j++)
                    {
                        block.chars += symbols[index];
                    }
                    listOfSymbolBlocks.Add(block);
                }

                foreach (Block item in listOfSymbolBlocks)
                {
                    Console.SetCursorPosition(item.pos.y, item.pos.x);
                    Console.Write(item.chars);
                }

                    Console.SetCursorPosition(dwarf.y, dwarf.x);
            Console.Write("(0)");


            Thread.Sleep(150);
        }
    }
}

