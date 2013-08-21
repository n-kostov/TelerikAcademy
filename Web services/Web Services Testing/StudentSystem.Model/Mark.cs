using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Model
{
    [DataContract(Name = "Mark", Namespace = "")]
    public class Mark
    {
        [DataMember]
        public int MarkId { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public double Value { get; set; }

        public int StudentId { get; set; }
    }
}
