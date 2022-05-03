using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);
        public abstract void AddGrade(char grade);
        public abstract Statistics GetStatistics();
        // public abstract Statistics GetStatisticsWithDoWhile();
        // public abstract Statistics GetStatisticsWithFor();
        // public abstract Statistics GetStatisticsWithForeach();
        // public abstract Statistics GetStatisticsWithWhile();
        public abstract event GradeAddedDelegate GradeAdded;
    }
}