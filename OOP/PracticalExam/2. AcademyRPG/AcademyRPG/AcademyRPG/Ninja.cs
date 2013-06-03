using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        private int attackPoints;

        public int AttackPoints
        {
            get { return attackPoints; }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
            attackPoints = 0;
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int maxIndex = 0;
            bool found = false;
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (availableTargets[i].HitPoints >= availableTargets[maxIndex].HitPoints)
                    {
                        maxIndex = i;
                        found = true;
                    }
                }
            }
            if (found)
            {
                return maxIndex;
            }
            else
            {
                return -1;
            }
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                attackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                attackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }

    }
}
