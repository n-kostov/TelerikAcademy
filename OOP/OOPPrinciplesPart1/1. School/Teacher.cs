using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.School
{
    public class Teacher : Human, ICommentable
    {
        private List<Discipline> disciplines = new List<Discipline>();

        public Teacher(string name)
            : base(name)
        {

        }
        public List<Discipline> Disciplines
        {
            get
            {
                return this.disciplines.AsReadOnly().ToList();
            }
        }

        public void AddDiscipline(Discipline disciplineToAdd)
        {
            disciplines.Add(disciplineToAdd);
        }

        public void RemoveDiscipline(Discipline disciplineToDelete)
        {
            disciplines.Remove(disciplineToDelete);
        }

        public string Comment { get; set; }

        public void AddComment(string comment)
        {
            Comment = comment;
        }

    }
}
