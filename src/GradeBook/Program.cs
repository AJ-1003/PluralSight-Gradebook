using System.Collections.Generic;
using GradeBook;

// See https://aka.ms/new-console-template for more information

// Main method code block
var book = new InMemoryBook("AJ's Grade Book");
// book.AddGrade(80.6);
// book.AddGrade(85.4);
// book.AddGrade(90.3);

book.GradeAdded += OnGradeAdded;

Console.WriteLine();
Console.WriteLine("=====================================");
Console.WriteLine("Enter student grades or q to quit:");
Console.WriteLine("-------------------------------------");

// var stats = book.GetStatisticsWithForeach();
// var stats = book.GetStatisticsWithDoWhile();
// var stats = book.GetStatisticsWithWhile();
EnterGrades(book);

var stats = book.GetStatisticsWithFor();

Console.WriteLine("-------------------------------------");
Console.WriteLine("                Grades               ");
Console.WriteLine("=====================================");
Console.WriteLine($"The highest grade is\t:\t{stats.High:N1}");
Console.WriteLine($"The lowest  grade is\t:\t{stats.Low:N1}");
Console.WriteLine($"The average grade is\t:\t{stats.Average:N1}");
Console.WriteLine($"The letter  grade is\t:\t{stats.Letter}");
Console.WriteLine("=====================================");
Console.WriteLine();

static string EnterGrades(IBook book)
{
    string? gradeInput;
    while (true)
    {
        double grade;
        char gradeLetter;
        // Console.WriteLine("Enter a grade ot q to quit");
        gradeInput = Console.ReadLine();
        try
        {
            if (double.TryParse(gradeInput, out grade))
            {
                book.AddGrade(grade);
            }
            else if (char.TryParse(gradeInput.ToUpper(), out gradeLetter))
            {
                if (gradeLetter == 'Q' || gradeLetter == 'q')
                {
                    break;
                }
                else
                {
                    book.AddGrade(gradeLetter);
                }
            }
            else
            {
                throw new ArgumentException($"{nameof(gradeInput)}: Input was in the incorrect format.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    return gradeInput;
}

static void OnGradeAdded(object sender, EventArgs e)
{
    Console.WriteLine("A grade was added");
}

// // Main method code block
// // ---------< read items from args >---------
// if (args.Length > 0)
// {
//     Console.WriteLine("Hello, " + args[0] + "!");
//     // Console.WriteLine($"Hello, {args[0]} {args[1]}!");                  // string interpolation
//     // Console.WriteLine($"Hello, {args[0]} {args[1]} {args[2]}!");
//     // Console.WriteLine($"Age, {args[3]}!");
// }
// else
// {
//     Console.WriteLine("Hello!");
// }

// // ---------< addition >---------
// double x = 15.9;
// double y = 56.66;

// double result;
// result = x + y;

// Console.WriteLine(result);

// // ---------< array >---------
// double[] numbers = new double[] {56.2, 69.4, 10.5};

// double resultArray = 0.0;

// foreach (double number in numbers) {
//     resultArray += number;
// }

// Console.WriteLine(resultArray);

// // ---------< list >---------
// List<double> grades = new List<double>() {56.2, 69.4, 10.5, 45.6, 23.7};
// grades.Add(47.5);

// double resultGrades = 0.0;

// foreach (var grade in grades) {
//     resultGrades += grade;
// }

// int numberOfGrades = grades.Count;
// double gradesAverage = resultGrades / numberOfGrades;

// Console.WriteLine($"Grades total: {resultGrades:N1}");
// Console.WriteLine($"Grades average: {gradesAverage:N1}");