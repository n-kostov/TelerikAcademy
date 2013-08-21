using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJewels.Models
{
    public class Vote
    {
        public int VoteId { get; set; }

        public bool Value { get; set; }

        public int CodeJewelId { get; set; }

        public virtual CodeJewel CodeJewel { get; set; }
    }
}
