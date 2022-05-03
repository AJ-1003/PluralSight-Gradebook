namespace GradeBook
{
    public class Statistics
    {
        public double High;
        public double Low;
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var grade when grade >= 90.0:
                        return 'A';
                    case var grade when grade >= 80.0:
                        return 'B';
                    case var grade when grade >= 70.0:
                        return 'C';
                    case var grade when grade >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }
        public double Sum;
        public int Count;

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Sum = 0.0;
            Count = 0;
        }

        public void Add(double number)
        {
            Sum += number;
            Count++;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High);
        }
    }
}