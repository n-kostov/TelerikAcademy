using System;

namespace GSMUtils
{
    public class Display
    {
        private int? size;
        private int? numberOfColors;
        public int? NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                this.numberOfColors = value;
            }
        }

        public int? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        public Display()
            : this(null)
        {
        }

        public Display(int? size)
            : this(size, null)
        {
            this.size = size;
        }

        public Display(int? size, int? numberOfColors)
        {
            this.size = size;
            this.numberOfColors = numberOfColors;
        }
    }
}
