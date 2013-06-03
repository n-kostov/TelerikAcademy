using System;

internal class RefactorIfStatements
{
    public static bool IsInRange(int value, int minBound, int maxBound)
    {
        bool isInrange = value >= minBound && value <= maxBound;

        return isInrange;
    }

    public static void Main(string[] args)
    {
        Potato potato = new Potato();

        // ...
        if (potato != null)
        {
            if (!potato.IsRotten && potato.HasBeenPeeled)
            {
                Cook(potato);
            }
        }

        // if this cells are matrix we can have another matrix visited which could be used instead of shouldVisitCell
        if (IsInRange(x, MIN_X, MAX_X) && IsInRange(y, MIN_Y, MAX_Y) && shouldVisitCell)
        {
            VisitCell(x, y);
        }
    }
}
