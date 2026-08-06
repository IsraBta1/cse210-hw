using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Homework Project: Assignment inheritance demo\n");

        // Optional: demo Person -> Student (from earlier work)
        Console.Write("Enter student name (for Person/Student demo): ");
        string name = Console.ReadLine();
        Console.Write("Enter student ID number: ");
        string number = Console.ReadLine();
        Student student = new Student(name, number);
        Console.WriteLine("\nStudent created:");
        Console.WriteLine(student.GetSummary());

        // Now follow the course steps: create Assignment objects interactively and show their data
        Console.WriteLine("\nAssignment examples (interactive):\n");

        Console.WriteLine("-- Create Math Assignment --");
        Console.Write("Course name: ");
        string mathCourse = Console.ReadLine();
        Console.Write("Student name: ");
        string mStudent = Console.ReadLine();
        Console.Write("Topic: ");
        string mTopic = Console.ReadLine();
        Console.Write("Textbook section: ");
        string mSection = Console.ReadLine();
        Console.Write("Problems (e.g., 1-22): ");
        string mProblems = Console.ReadLine();

        MathAssignment m = new MathAssignment(mStudent, mTopic, mSection, mProblems, mathCourse);
        Console.WriteLine();
        Console.WriteLine(m.GetSummary());
        Console.WriteLine(m.GetHomeworkList());

        Console.WriteLine("\n-- Create Writing Assignment --");
        Console.Write("Course name: ");
        string writeCourse = Console.ReadLine();
        Console.Write("Student name: ");
        string wStudent = Console.ReadLine();
        Console.Write("Topic: ");
        string wTopic = Console.ReadLine();
        Console.Write("Title: ");
        string wTitle = Console.ReadLine();

        WritingAssignment w = new WritingAssignment(wStudent, wTopic, wTitle, writeCourse);
        Console.WriteLine();
        Console.WriteLine(w.GetSummary());
        Console.WriteLine(w.GetWritingInformation());
    }
}