namespace _2.ComparePerfOfNumberTypes
{
    public class MultiplicationMethods
    {
        public static void MultiplyInt(int startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue *= 3;
            }
        }

        public static void MultiplyLong(long startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue *= 3L;
            }
        }

        public static void MultiplyFloat(float startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue *= 3f;
            }
        }

        public static void MultiplyDouble(double startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue *= 3d;
            }
        }

        public static void MultiplyDecimal(decimal startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue *= 3m;
            }
        }
    }
}
