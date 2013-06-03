using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("grade", "The grade cannot be negative!");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("minGrade", "The minimum grade cannot be negative!");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("The maximum grade cannot be less than or equal to the minimum grade!", "maxGrade");
        }

        if (comments == null || comments == string.Empty)
        {
            throw new ArgumentNullException("comments", "The comments cannot be left blank or null!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
