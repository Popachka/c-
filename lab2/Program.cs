using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Blog blog = new Blog();
            Post post = new Post("Статья созданная заранее как экземпляр заранее");
            post.RateUpp();
            blog.CreatePost(post);
            blog.CreatePost("Статья о вечном", "Текст о вечном");
            blog.CreatePost();
            blog.SeePosts();

        }
    }
}