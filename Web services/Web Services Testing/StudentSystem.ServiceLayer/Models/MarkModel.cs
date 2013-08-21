using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.ServiceLayer.Models
{
    public class MarkModel
    {
        public int MarkId { get; set; }

        public string Subject { get; set; }

        public double Value { get; set; }
    }
}