using System;

public class SimpleMathExam : Exam
{
    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
            throw new ArgumentOutOfRangeException("problemsSolved", "The problems solved cannot be negative!");
        }

        if (problemsSolved > 10)
        {
            throw new ArgumentOutOfRangeException("problemsSolved", "The problems solved cannot be more than the problems count(10)!");
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (this.ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        // this contradict with the idea that there are 10 problems and more results should be added
        throw new ArgumentOutOfRangeException("problemsSolved", "The number of problems solved is not valid!");
    }
}
