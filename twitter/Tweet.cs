public class Tweet
{
    public string Content { get; private set; }
    public User User { get; private set; }
    private int likes;

    public Tweet(string content, User user)
    {
        Content = content;
        User = user;
        likes = 0;
    }

    public void Like() => likes++;

    public void Unlike()
    {
        if (likes > 0)
            likes--;
    }

    public int GetLikes() => likes;
} 