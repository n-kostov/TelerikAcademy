using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJewels.Models
{
    public class CodeJewel
    {
        private ICollection<Vote> votes;

        public CodeJewel()
        {
            this.votes = new HashSet<Vote>();
        }

        public int CodeJewelId { get; set; }

        public int CategoryId { get; set; }

        public string AuthorEmail { get; set; }

        public int Rating { get; set; }

        public string SourceCode { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get
            {
                return this.votes;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("votes", "The votes cannot be set to null");
                }

                this.votes = value;
            }
        }
    }
}
