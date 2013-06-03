using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> produceObjects = new List<GameObject>();
            if (this.IsDestroyed)
            {
                produceObjects.Add(new ExplosionParticle(new MatrixCoords(topLeft.Row-1 ,topLeft.Col - 1),new MatrixCoords(0,0)));
                produceObjects.Add(new ExplosionParticle(new MatrixCoords(topLeft.Row - 1, topLeft.Col), new MatrixCoords(0, 0)));
                produceObjects.Add(new ExplosionParticle(new MatrixCoords(topLeft.Row - 1, topLeft.Col + 1), new MatrixCoords(0, 0)));
                produceObjects.Add(new ExplosionParticle(new MatrixCoords(topLeft.Row, topLeft.Col - 1), new MatrixCoords(0, 0)));
                produceObjects.Add(new ExplosionParticle(new MatrixCoords(topLeft.Row , topLeft.Col + 1), new MatrixCoords(0, 0)));

            }
            return produceObjects;
        }
    }
}
