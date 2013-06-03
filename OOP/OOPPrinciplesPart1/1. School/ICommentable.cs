using System;

namespace _1.School
{
    interface ICommentable
    {
        string Comment { get; set; }
        void AddComment(string comment);
    }
}
