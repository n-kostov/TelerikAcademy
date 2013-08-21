using System;

namespace _3.FileSystemTree
{
    public class File
    {
        private string name;
        private long size;

        public File(string name, long size)
        {
            this.name = name;
            this.size = size;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name of the file cannot be set to null or whitespace!", "name");
                }

                this.name = value;
            }
        }

        public long Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("size", "The filesize cannot be negative!");
                }

                this.size = value;
            }
        }
    }
}
