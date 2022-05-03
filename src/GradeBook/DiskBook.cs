namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"C:/Users/iajor/source/repos/gradebook/src/files/{Name}.txt"));
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatisticsWithDoWhile()
        {
            throw new NotImplementedException();
        }

        public override Statistics GetStatisticsWithFor()
        {
            throw new NotImplementedException();
        }

        public override Statistics GetStatisticsWithForeach()
        {
            throw new NotImplementedException();
        }

        public override Statistics GetStatisticsWithWhile()
        {
            throw new NotImplementedException();
        }
    }
}