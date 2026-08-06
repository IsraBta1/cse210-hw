using System;

public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title, string course)
        : base(studentName, topic, course)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        string bySuffix = $", by {GetStudentName()}";
        if (_title != null && _title.EndsWith(bySuffix))
        {
            return $"Title: {_title}";
        }
        return $"Title: {_title}{bySuffix}";
    }
}
