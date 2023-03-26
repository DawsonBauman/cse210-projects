using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create three Video objects
        Video video1 = new Video("Title 1", "Author 1", 60);
        Video video2 = new Video("Title 2", "Author 2", 120);
        Video video3 = new Video("Title 3", "Author 3", 180);

        // Add comments to the videos
        video1.add_comment(new Comment("Commenter 1", "Comment 1 for video 1"));
        video1.add_comment(new Comment("Commenter 2", "Comment 2 for video 1"));
        video1.add_comment(new Comment("Commenter 3", "Comment 3 for video 1"));

        video2.add_comment(new Comment("Commenter 1", "Comment 1 for video 2"));
        video2.add_comment(new Comment("Commenter 2", "Comment 2 for video 2"));
        video2.add_comment(new Comment("Commenter 3", "Comment 3 for video 2"));

        video3.add_comment(new Comment("Commenter 1", "Comment 1 for video 3"));
        video3.add_comment(new Comment("Commenter 2", "Comment 2 for video 3"));
        video3.add_comment(new Comment("Commenter 3", "Comment 3 for video 3"));

        // Create a list of the videos
        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Iterate through the list of videos and display their information
        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.get_title());
            Console.WriteLine("Author: " + video.get_author());
            Console.WriteLine("Length: " + video.get_length() + " seconds");
            Console.WriteLine("Number of comments: " + video.get_num_comments());

            Console.WriteLine("Comments:");
            List<Comment> comments = video.get_comments();
            foreach (Comment comment in comments)
            {
                Console.WriteLine("- " + comment.get_name() + ": " + comment.get_text());
            }
            Console.WriteLine();
        }
    }
}

class Video
{
    private string title;
    private string author;
    private int length;
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        this.comments = new List<Comment>();
    }

    public void add_comment(Comment comment)
    {
        comments.Add(comment);
    }

    public int get_num_comments()
    {
        return comments.Count;
    }

    public string get_title()
    {
        return title;
    }

    public string get_author()
    {
        return author;
    }

    public int get_length()
    {
        return length;
    }

    public List<Comment> get_comments()
    {
        return comments;
    }
}

class Comment
{
    private string name;
    private string text;

    public Comment(string name, string text)
    {
        this.name = name;
        this.text = text;
    }

    public string get_name()
    {
        return name;
    }

    public string get_text()
    {
        return text;
    }
}
