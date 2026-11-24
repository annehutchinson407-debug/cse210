using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        Video video1 = new Video("A Day in the Mountains", "Jordan Lee", 642);
        video1.AddComment(new Comment("Sam", "The view from the summit is incredible."));
        video1.AddComment(new Comment("Taylor", "Adding this hike to my list."));
        video1.AddComment(new Comment("Morgan", "Thanks for sharing the trail details."));

        Video video2 = new Video("How to Make Fresh Pasta", "Kitchen with Mia", 815);
        video2.AddComment(new Comment("Jamie", "I tried this recipe and it worked perfectly."));
        video2.AddComment(new Comment("Casey", "Fresh pasta is worth the effort!"));
        video2.AddComment(new Comment("Riley", "Could you make a video about ravioli next?"));

        Video video3 = new Video("Beginner's Guide to Photography", "Alex Rivera", 1030);
        video3.AddComment(new Comment("Chris", "The lighting tips were very helpful."));
        video3.AddComment(new Comment("Avery", "Great explanation for beginners."));
        video3.AddComment(new Comment("Drew", "I learned a lot. Thank you!"));

        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"  {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
