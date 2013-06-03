using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ShootingRacket : Racket
    {
        private bool hasFired = false;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }

        public void Shoot()
        {
            this.hasFired = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> producedObjects = new List<GameObject>();
            if (this.hasFired)
            {
                this.hasFired = false;
                producedObjects.Add(new Bullet(new MatrixCoords(topLeft.Row - 1, topLeft.Col)));
                producedObjects.Add(new Bullet(new MatrixCoords(topLeft.Row - 1, topLeft.Col + Width - 1)));
            }
            return producedObjects;
        }

    }
}
