using System;

public class Assignment
{
    private string _studentName;
    private string _topic;
    private string _course;

    public Assignment(string studentName, string topic, string course)
    {
        _studentName = studentName;
        _topic = topic;
        _course = course;
    }

    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetTopic()
    {
        return _topic;
    }

    public string GetCourse()
    {
        return _course;
    }

    public virtual string GetSummary()
    {
        return $"Student Name: {_studentName} - Topic: {_topic} - Course: {_course}";
    }
}
