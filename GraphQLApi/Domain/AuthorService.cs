using Models;
using Repository;
using System.Collections.Generic;

namespace Domain
{
    public class AuthorService
    {
        private readonly AuthorRepository authorRepository;

        public AuthorService(AuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public List<Author> GetAllAuthors()
        {
            return authorRepository.GetAllAuthors();
        }

        public Author GetAuthorById(int id)
        {
            return authorRepository.GetAuthorById(id);
        }

        public List<BlogPost> GetPostsByauthor(int id)
        {
            return authorRepository.GetPostsbyAuthor(id);
        }
    }
}
