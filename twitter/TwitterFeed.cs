using System.Collections.Generic;
using System.Linq;

public class TwitterFeed
{
    private List<User> users;

    public TwitterFeed()
    {
        users = new List<User>();
    }

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public IEnumerable<Tweet> GetFeed(string username, int minLikes)
    {
        var user = users.FirstOrDefault(u => u.Username == username);
        if (user == null)
            return Enumerable.Empty<Tweet>();

        return user.GetTweets().Where(t => t.GetLikes() >= minLikes);
    }

    public void UnlikeTweet(string username, string tweetContent)
    {
        var user = users.FirstOrDefault(u => u.Username == username);
        if (user != null)
        {
            var tweet = user.GetTweets()
                           .FirstOrDefault(t => t.Content == tweetContent);
            tweet?.Unlike();
        }
    }

    public IEnumerable<Tweet> GetAllTweets()
    {
        return users.SelectMany(u => u.GetTweets());
    }
} 