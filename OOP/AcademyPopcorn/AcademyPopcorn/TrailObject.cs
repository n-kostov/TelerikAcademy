using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        private int lifetime;

        public int Lifetime
        {
            get
            {
                return this.lifetime;
            }
            private set
            {
                this.lifetime = value;
            }
        }

        public TrailObject(MatrixCoords topLeft, int lifetime)
            : base(topLeft, new char[,] { { 'x' } })
        {
            this.lifetime = lifetime;
        }

        public override void Update()
        {
            if (lifetime > 0)
            {
                lifetime--;
            }
            else
            {
                this.IsDestroyed = true;
            }
        }
    }
}
