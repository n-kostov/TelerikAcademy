using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        public const int WorldRows = 23;
        public const int WorldCols = 40;
        public const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));


    //        Ball theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
    //new MatrixCoords(-1, 1));

            Ball theBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
new MatrixCoords(-1, 1));

            engine.AddObject(theBall);


            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            for (int row = 0; row < WorldRows; row++)
            {
                IndestructibleBlock leftSide = new IndestructibleBlock(new MatrixCoords(row, 0));

                engine.AddObject(leftSide);

                IndestructibleBlock rightSide = new IndestructibleBlock(new MatrixCoords(row, WorldCols - 1));

                engine.AddObject(rightSide);

            }

            for (int col = 1; col < WorldCols - 1; col++)
            {

                IndestructibleBlock ceiling = new IndestructibleBlock(new MatrixCoords(0, col));

                engine.AddObject(ceiling);
            }

            //TrailObject trailingObject = new TrailObject(new MatrixCoords(WorldRows / 2, WorldCols / 2), 10);

            UnpassableBlock unpassable = new UnpassableBlock(new MatrixCoords(WorldRows / 2, WorldCols / 2 ));

            engine.AddObject(unpassable);

            //ExplodingBlock exploadable = new ExplodingBlock(new MatrixCoords(4, 6));

            //engine.AddObject(exploadable);

            GiftBlock gift = new GiftBlock(new MatrixCoords(4, 6));

            engine.AddObject(gift);


        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            ShootingEngine gameEngine = new ShootingEngine(renderer, keyboard, 200);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
