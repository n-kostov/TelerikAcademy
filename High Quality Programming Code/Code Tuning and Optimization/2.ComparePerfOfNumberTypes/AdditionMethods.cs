namespace _2.ComparePerfOfNumberTypes
{
    public class AdditionMethods
    {
        public static void AddInt(int startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue += 2;
            }
        }

        public static void AddLong(long startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue += 2L;
            }
        }

        public static void AddFloat(float startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue += 2.1f;
            }
        }

        public static void AddDouble(double startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue += 2.1d;
            }
        }

        public static void AddDecimal(decimal startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue += 2.1m;
            }
        }
    }
}
