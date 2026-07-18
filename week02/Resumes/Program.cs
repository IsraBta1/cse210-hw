using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "BYU-Idaho";
        job1._jobTitle = "Student - Software Development";
        job1._startYear = 2025;
        job1._endYear = 2028;

        Resume myResume = new Resume();
        myResume._name = "Israel Betancourt";
        myResume._jobs.Add(job1);

        myResume.Display();
    }
}