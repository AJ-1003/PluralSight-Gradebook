using GradeBook;

// Interfaces should not contain any implementation details
// Interfaces are more common than abstract classes
public interface IBook
    {
        void AddGrade(double grade);
        void AddGrade(char grade);
        Statistics GetStatistics();
        // Statistics GetStatisticsWithForeach();
        // Statistics GetStatisticsWithDoWhile();
        // Statistics GetStatisticsWithWhile();
        // Statistics GetStatisticsWithFor();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }