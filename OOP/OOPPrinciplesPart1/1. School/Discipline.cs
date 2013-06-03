using System;

namespace _1.School
{
    public struct Discipline: ICommentable
    {
        public string Name { get; set; }

        public int NumberOfLectures { get; set; }

        public int NumberOfExercises { get; set; }

        public Discipline(string name, int numLectures = 0, int numExercises = 0)
            : this()
        {
            Name = name;
            NumberOfLectures = numLectures;
            NumberOfExercises = numExercises;
        }

        public string Comment { get; set; }

        public void AddComment(string comment)
        {
            Comment = comment;
        }
    }
}
