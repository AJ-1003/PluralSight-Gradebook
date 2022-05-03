namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    // derived class : base class
    public class InMemoryBook : Book
    {
        // constructor
        // the 'new' keyword will ensure that this will execute before any methods are invoked that uses the defined fields 
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            // field name = parameter name
            // Name = name;
        }

        // field definitions
        private List<double> grades;
        Statistics result = new Statistics();
        readonly string category;
        public event GradeAddedDelegate GradeAdded;

        // properties
        public string TestProperty
        {
            // any code can read the Name
            get;
            // but outside code cannot set the Name
            private set;
        }
        public string Name
        {
            // any code can read the Name
            get;
            // any code can write to the name
            set;
        }

        // methods
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90.0);
                    break;
                case 'B':
                    AddGrade(80.0);
                    break;
                case 'C':
                    AddGrade(70.0);
                    break;
                case 'D':
                    AddGrade(60.0);
                    break;
                case 'F':
                    AddGrade(50.0);
                    break;
                default:
                    AddGrade(0.0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} entry");
            }
        }

        public void LetterGrade()
        {
            switch (result.Average)
            {
                case var grade when grade >= 90.0:
                    result.Letter = 'A';
                    break;
                case var grade when grade >= 80.0:
                    result.Letter = 'B';
                    break;
                case var grade when grade >= 70.0:
                    result.Letter = 'C';
                    break;
                case var grade when grade >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
        }

        public Statistics GetStatisticsWithForeach()
        {
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            result.Average = 0.0;
            if (grades.Count > 0)
            {
                foreach (var grade in grades)
                {
                    result.High = Math.Max(grade, result.High);
                    result.Low = Math.Min(grade, result.Low);
                    result.Average += grade;
                }
                result.Average /= grades.Count;
                LetterGrade();
            }
            else
            {
                result.Average = 0.0;
                result.High = 0.0;
                result.Low = 0.0;
                LetterGrade();
            }
            return result;
        }

        public Statistics GetStatisticsWithDoWhile()
        {
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            result.Average = 0.0;
            if (grades.Count > 0)
            {
                var index = 0;
                do
                {
                    result.High = Math.Max(grades[index], result.High);
                    result.Low = Math.Min(grades[index], result.Low);
                    result.Average += grades[index];
                    index++;
                }
                while (index < grades.Count);
                result.Average /= grades.Count;
                LetterGrade();
            }
            else
            {
                result.Average = 0.0;
                result.High = 0.0;
                result.Low = 0.0;
                LetterGrade();
            }
            return result;
        }

        public Statistics GetStatisticsWithWhile()
        {
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            result.Average = 0.0;

            if (grades.Count > 0)
            {
                var index = 0;
                while (index < grades.Count)
                {
                    result.High = Math.Max(grades[index], result.High);
                    result.Low = Math.Min(grades[index], result.Low);
                    result.Average += grades[index];
                    index++;
                }
                result.Average /= grades.Count;
                LetterGrade();
            }
            else
            {
                result.Average = 0.0;
                result.High = 0.0;
                result.Low = 0.0;
                LetterGrade();
            }
            return result;
        }

        public Statistics GetStatisticsWithFor()
        {
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            result.Average = 0.0;

            if (grades.Count > 0)
            {
                for (var index = 0; index < grades.Count; index++)
                {
                    result.High = Math.Max(grades[index], result.High);
                    result.Low = Math.Min(grades[index], result.Low);
                    result.Average += grades[index];
                }
                result.Average /= grades.Count;
                LetterGrade();
            }
            else
            {
                result.Average = 0.0;
                result.High = 0.0;
                result.Low = 0.0;
                LetterGrade();
            }
            return result;
        }

        public List<double> GetGrades()
        {
            return grades;
        }
    }
}