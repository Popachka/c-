class Post
{
    private string title;
    private string content;
    private int id;
    private static int numbers = 0;
    private int rate;
    private DateTime date;

    public Post()
    {
        this.id = numbers;
        numbers++;
        this.rate = 0;
        this.title = "Заголовок " + id;
        this.content = "";
        this.date = DateTime.Now;
    }
    public Post(string title) : this()
    {
        this.title = title;
    }
    // public Post(string content) : this()
    // {
    //     this.content = content;
    // }
    public Post(string title, string content) : this()
    {
        this.title = title;
        this.content = content;
    }

    public Post(Post post)
    {
        this.id = post.id;
        this.rate = post.rate;
        this.title = post.title;
        this.content = post.content;
        this.date = post.date;
    }
    public void RateUpp()
    {
        this.rate++;
        return;
    }
    public void RateDown()
    {
        if (this.rate <= 0)
        {
            this.rate = 0;
            return;
        }
        this.rate--;
    }
    public string GetTitle()
    {
        return this.title;
    }
    public string GetContent()
    {
        return this.content;
    }
    public int GetRate()
    {
        return this.rate;
    }
    public DateTime GetDate()
    {
        return this.date;
    }
    public int GetId()
    {
        return this.id;
    }


}