# Explanation of the YouTube Videos Project

## 1. Objective of the exercise

This project follows the idea of week 4 of the course: practicing object-oriented programming with the concepts of abstraction, encapsulation, and class relationships.

The assignment asks us to create a program to store information about videos and the comments that appear on them. There is no need to create a menu-based system; instead, we create objects, assign values, and display them in the console.

The key idea is that each class represents a real-world part of the problem, and each one has a clear responsibility.

---

## 2. Relationship between classes

In this exercise, two main classes are used: Video and Comment.

- A video has a title, author, duration, and a list of comments.
- Each comment contains the name of the person and the text of the comment.
- A video can contain several comments.

This relationship is called composition: a video is made up of many comments.

---

## 3. Comment class

```csharp
public class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    public string CommenterName
    {
        get { return _commenterName; }
    }

    public string Text
    {
        get { return _text; }
    }
}
```

This class stores the information for each comment:

- `_commenterName`: the name of the person who commented.
- `_text`: the content of the comment.

The attributes are private; this protects the data and only allows access through public properties.

---

## 4. Video class

```csharp
public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public string Title
    {
        get { return _title; }
    }

    public string Author
    {
        get { return _author; }
    }

    public int LengthInSeconds
    {
        get { return _lengthInSeconds; }
    }

    public List<Comment> Comments
    {
        get { return _comments; }
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public string GetFormattedDuration()
    {
        int minutes = _lengthInSeconds / 60;
        int seconds = _lengthInSeconds % 60;
        return $"{minutes} min {seconds} sec";
    }
}
```

This class represents a video with the following data:

- title
- author
- duration in seconds
- list of comments

In addition, the class has important methods:

- `AddComment`: adds a comment to the list.
- `GetCommentCount`: returns how many comments the video has.
- `GetFormattedDuration`: converts the duration into a readable format, such as 7 min 0 sec.

---

## 5. Main logic in Program.cs

```csharp
class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("The History of C#", "Carlos Ruiz", 420);
        video1.AddComment(new Comment("Ana", "Very useful explanation."));
        video1.AddComment(new Comment("Luis", "I liked the examples."));
        video1.AddComment(new Comment("María", "This helped me understand classes."));
        videos.Add(video1);

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
        }
    }
}
```

This is the most important part of the program:

1. A list called `videos` is created.
2. Several objects of type `Video` are instantiated.
3. Comments are added using `AddComment`.
4. The list is iterated with `foreach`.
5. The title, author, duration, and comments of each video are displayed.

---

## 6. What does Abstraction mean?

Abstraction means including only the data that is truly necessary to solve the problem.

In this case, we do not need to store any extra information. We only need:

- title
- author
- duration
- comments

---

## 7. What does Encapsulation mean?

Encapsulation refers to protecting the internal data of a class using private attributes and allowing access only through methods or properties.

This makes the program safer and more organized. If someone wants to change or read a value, they must do it in the controlled way that the class provides.

---

## 8. What does Composition mean?

Composition is when one class contains other classes inside it. In this exercise, `Video` contains a list of `Comment`.

This represents a real-world relationship: a video can have many comments associated with it.

---

## 9. Final summary

This exercise demonstrates how to organize real-world information into classes with defined responsibilities. Instead of storing each piece of data separately, each element has meaning inside an object.

In the end, the result is a clearer, easier-to-maintain program that is ready to grow in the future.
