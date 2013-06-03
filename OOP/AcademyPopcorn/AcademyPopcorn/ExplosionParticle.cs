using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ExplosionParticle : MovingObject
    {
        public ExplosionParticle(MatrixCoords topLeft,MatrixCoords speed)
            : base(topLeft, new char[,]{{'+'}},speed)
        {
            //this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        //public override void RespondToCollision(CollisionData collisionData)
        //{
        //    this.IsDestroyed = true;
        //}


        public override void Update()
        {
            this.IsDestroyed = true;
        }
    }
}
