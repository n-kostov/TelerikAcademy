using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.School
{
    class School
    {
        private List<Class> classes = new List<Class>();

        public List<Class> Classes
        {
            get
            {
                return this.classes.AsReadOnly().ToList();
            }
        }

        public void AddClass(Class classToAdd)
        {
            classes.Add(classToAdd);
        }

        public void RemoveClass(Class classToDelete)
        {
            classes.Remove(classToDelete);
        }

        public string Comment { get; set; }

        public void AddComment(string comment)
        {
            Comment = comment;
        }
    }
}
