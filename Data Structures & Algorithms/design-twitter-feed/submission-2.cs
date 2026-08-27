public class Twitter {
    private Dictionary<int, HashSet<int>> followMap;
    private Dictionary<int, List<(int tweetId, int time)>> tweets;
    private int time;
    public Twitter() {
        followMap = new Dictionary<int, HashSet<int>>();
        tweets = new Dictionary<int, List<(int, int)>>();
        time = 0;
    }
    
    public void PostTweet(int userId, int tweetId) {
        if(!tweets.ContainsKey(userId)) {
            tweets[userId] = new List<(int, int)>();
        }

        tweets[userId].Add((tweetId, time++));
        Follow(userId, userId);

        // Console.WriteLine($"user: {userId} posted: {tweetId}");
    }
    
    public List<int> GetNewsFeed(int userId) {
        int feedCount = 10;
        PriorityQueue<(int tweetId, int time), int> feedQ = new PriorityQueue<(int, int), int>();
        List<int> newsFeed = new List<int>();

        foreach(var followee in followMap[userId]) {
            foreach(var tweet in tweets[followee]) {
                feedQ.Enqueue(tweet, tweet.time);

                if(feedCount > 0) {
                    feedCount -= 1;
                } else {
                    feedQ.Dequeue();
                }
            }
        }

        while(feedQ.Count > 0) {
            var dq = feedQ.Dequeue();
            newsFeed.Add(dq.tweetId);
        }
        newsFeed.Reverse();

        return newsFeed;
    }
    
    public void Follow(int followerId, int followeeId) {
        if(!followMap.ContainsKey(followerId)) {
            followMap[followerId] = new HashSet<int>();
        }

        followMap[followerId].Add(followeeId);
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if(followMap.ContainsKey(followerId)/* && followMap[followerId].Contins(followeeId)*/) {
            followMap[followerId].Remove(followeeId);
        }
    }
}
