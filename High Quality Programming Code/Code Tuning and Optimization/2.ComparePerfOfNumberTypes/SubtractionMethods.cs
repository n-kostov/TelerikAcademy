namespace _2.ComparePerfOfNumberTypes
{
    public class SubtractionMethods
    {
        public static void SubtractInt(int startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue -= 2;
            }
        }

        public static void SubtractLong(long startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue -= 2L;
            }
        }

        public static void SubtractFloat(float startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue -= 2.1f;
            }
        }

        public static void SubtractDouble(double startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue -= 2.1d;
            }
        }

        public static void SubtractDecimal(decimal startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue -= 2.1m;
            }
        }
    }
}
