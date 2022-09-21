class Blog
{
    private Dictionary<int, Post> AllPosts = new Dictionary<int, Post>();


    public void CreatePost()
    {
        Post post = new Post();
        AllPosts.Add(post.GetId(), post);
    }
    public void CreatePost(string title, string content)
    {
        Post post = new Post(title, content);
        AllPosts.Add(post.GetId(), post);
    }
    public void CreatePost(Post post)
    {
        Post _post = new Post(post);
        AllPosts.Add(post.GetId(), _post);
    }

    public void SeePosts()
    {
        for (int i = 0; i < AllPosts.Count(); i++)
        {
            string title = AllPosts[i].GetTitle();
            string content = AllPosts[i].GetContent();
            DateTime date = AllPosts[i].GetDate();
            int rate = AllPosts[i].GetRate();
            Console.WriteLine("id: " + i + "\n" + "title: " + title + "\n" + "content: " + content + "\n" + "date: " + date + "\n" + "rate: " + rate + "\n");
        }
    }
}