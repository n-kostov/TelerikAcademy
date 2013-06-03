namespace _2.ComparePerfOfNumberTypes
{
    public class DivisionMethods
    {
        public static void DivideInt(int startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue /= 3;
            }
        }

        public static void DivideLong(long startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue /= 3L;
            }
        }

        public static void DivideFloat(float startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue /= 3f;
            }
        }

        public static void DivideDouble(double startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue /= 3d;
            }
        }

        public static void DivideDecimal(decimal startValue, int numberOfRepetitions)
        {
            for (int i = 0; i < numberOfRepetitions; i++)
            {
                startValue /= 3m;
            }
        }
    }
}
