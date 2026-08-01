using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("The History of C#", "Israel Betancourt", 420);
        video1.AddComment(new Comment("Ana", "Very useful explanation."));
        video1.AddComment(new Comment("Luis", "I liked the examples."));
        video1.AddComment(new Comment("María", "This helped me understand classes."));
        videos.Add(video1);

        Video video2 = new Video("OOP in C#", "Sofia Perez", 360);
        video2.AddComment(new Comment("Pedro", "Great summary."));
        video2.AddComment(new Comment("Laura", "The diagrams were clear."));
        video2.AddComment(new Comment("Diego", "Very easy to follow."));
        videos.Add(video2);

        Video video3 = new Video("C# for Beginners", "Daniel Lee", 540);
        video3.AddComment(new Comment("Nora", "Excellent lesson."));
        video3.AddComment(new Comment("Tom", "I learned so much."));
        video3.AddComment(new Comment("Eva", "Very clear and practical."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Duration: {video.GetFormattedDuration()}");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"  - {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}