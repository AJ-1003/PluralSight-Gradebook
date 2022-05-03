namespace GradeBook
{
    // derived class : base class
    public class InMemoryBook : Book
    {
        // constructor
        // the 'new' keyword will ensure that this will execute before any methods are invoked that uses the defined fields 
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            // field name = parameter name
            Name = name;
        }

        // field definitions
        private List<double> grades;
        Statistics result = new Statistics();
        public override event GradeAddedDelegate GradeAdded;

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
        public override void AddGrade(char grade)
        {
            switch (grade)
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

        public override Statistics GetStatistics()
        {
            if (grades.Count > 0)
            {
                for (var index = 0; index < grades.Count; index++)
                {
                    result.Add(grades[index]);
                }
            }
            else
            {
                result.Add(0.0);
            }
            return result;
        }

        // public override Statistics GetStatisticsWithForeach()
        // {
        //     if (grades.Count > 0)
        //     {
        //         foreach (var grade in grades)
        //         {
        //             result.Add(grade);
        //         }
        //     }
        //     else
        //     {
        //         result.Add(0.0);
        //     }
        //     return result;
        // }

        // public override Statistics GetStatisticsWithDoWhile()
        // {
        //     if (grades.Count > 0)
        //     {
        //         var index = 0;
        //         do
        //         {
        //             result.Add(grades[index]);
        //             index++;
        //         }
        //         while (index < grades.Count);
        //     }
        //     else
        //     {
        //         result.Add(0.0);
        //     }
        //     return result;
        // }

        // public override Statistics GetStatisticsWithWhile()
        // {
        //     if (grades.Count > 0)
        //     {
        //         var index = 0;
        //         while (index < grades.Count)
        //         {
        //             result.Add(grades[index]);
        //             index++;
        //         }
        //     }
        //     else
        //     {
        //         result.Add(0.0);
        //     }
        //     return result;
        // }

        // public override Statistics GetStatisticsWithFor()
        // {
        //     if (grades.Count > 0)
        //     {
        //         for (var index = 0; index < grades.Count; index++)
        //         {
        //             result.Add(grades[index]);
        //         }
        //     }
        //     else
        //     {
        //         result.Add(0.0);
        //     }
        //     return result;
        // }

        public List<double> GetGrades()
        {
            return grades;
        }
    }
}