using Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class AuthorRepository
    {
        private readonly List<Author> authors = new List<Author>();
        private readonly List<BlogPost> posts = new List<BlogPost>();

        public AuthorRepository()
        {
            Author author1 = new Author
            {
                Id = 1,
                FirstName = "Soniya",
                LastName = "Pimple"
            };
            Author author2 = new Author
            {
                Id = 2,
                FirstName = "other",
                LastName = "name"
            };
            BlogPost csharp = new BlogPost
            {
                Id = 1,
                Title = "first C#",
                Content = "This is a series of articles on C#.",
                Author = author1
            };
            BlogPost java = new BlogPost
            {
                Id = 2,
                Title = "second Java",
                Content = "This is a series of articles on Java",
                Author = author1
            };
            posts.Add(csharp);
            posts.Add(java);
            authors.Add(author1);
            authors.Add(author2);
        }

        public List<Author> GetAllAuthors()
        {
            return this.authors;
        }

        public Author GetAuthorById(int id)
        {
            return authors.FirstOrDefault(_ => _.Id == id);
        }

        public List<BlogPost> GetPostsbyAuthor(int id)
        {
            return posts.Where(_ => _.Author.Id == id).ToList();
        }
    }
}
