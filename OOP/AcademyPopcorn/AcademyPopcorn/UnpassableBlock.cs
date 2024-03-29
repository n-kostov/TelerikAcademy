﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class UnpassableBlock: IndestructibleBlock
    {
        public new const char Symbol = ')';
        public new const string CollisionGroupString = "unpassableBlock";

        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = UnpassableBlock.Symbol;

        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }

    }
}
