using System.Collections.Generic;

public class User
{
    public string Username { get; private set; }
    private List<Tweet> tweets;
    private List<User> followers;

    public User(string username)
    {
        Username = username;
        tweets = new List<Tweet>();
        followers = new List<User>();
    }

    public void PostTweet(string content)
    {
        var tweet = new Tweet(content, this);
        tweets.Add(tweet);
    }

    public IReadOnlyList<Tweet> GetTweets() => tweets.AsReadOnly();

    public void Follow(User user)
    {
        if (!followers.Contains(user))
        {
            followers.Add(user);
        }
    }

    public IReadOnlyList<User> GetFollowers() => followers.AsReadOnly();
} 