namespace KPK_Practical_Exam
{
    using System;

    public class Content : IComparable, IContent
    {
        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)ParameterType.Title];
            this.Author = commandParams[(int)ParameterType.Author];
            this.Size = long.Parse(commandParams[(int)ParameterType.Size]);
            this.URL = commandParams[(int)ParameterType.Url];
            this.TextRepresentation = this.ToString();
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        public string URL { get; set; }

        public ContentType Type { get; set; }

        public string TextRepresentation { get; set; }

        public int CompareTo(object obj)
        {
            if (null == obj)
            {
                return 1;
            }

            Content otherContent = obj as Content;
            if (otherContent != null)
            {
                int comparisonResult = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);
                return comparisonResult;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = string.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(),
                this.Title, this.Author, this.Size, this.URL);

            return output;
        }
    }
}
