namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        // field definitions
        private List<double> grades;
        Statistics result = new Statistics();
        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText($"C:/Users/iajor/source/isometrix training repos/gradebook/src/books/{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override void AddGrade(char grade)
        {
            throw new NotImplementedException();
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"C:/Users/iajor/source/isometrix training repos/gradebook/src/books/{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                }
            }
            return result;
        }

        // public override Statistics GetStatisticsWithDoWhile()
        // {
        //     throw new NotImplementedException();
        // }

        // public override Statistics GetStatisticsWithFor()
        // {
        //     throw new NotImplementedException();
        // }

        // public override Statistics GetStatisticsWithForeach()
        // {
        //     throw new NotImplementedException();
        // }

        // public override Statistics GetStatisticsWithWhile()
        // {
        //     throw new NotImplementedException();
        // }
    }
}