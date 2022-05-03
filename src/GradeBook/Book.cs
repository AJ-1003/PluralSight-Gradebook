using System.Collections.Generic;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatisticsWithDoWhile();
        public abstract Statistics GetStatisticsWithFor();
        public abstract Statistics GetStatisticsWithForeach();
        public abstract Statistics GetStatisticsWithWhile();
    }
}