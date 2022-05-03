using GradeBook;

public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatisticsWithForeach();
        Statistics GetStatisticsWithDoWhile();
        Statistics GetStatisticsWithWhile();
        Statistics GetStatisticsWithFor();
        string Name { get; }
    }