using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) && x.Author.Contains(authorName)).ToList();
        }

        public List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="C", Author="James" },
                new BookModel(){Id=2, Title="Java", Author="John" },
                new BookModel(){Id=3, Title="Python", Author="Adam" },
                new BookModel(){Id=4, Title="Dart", Author="Kate" },
                new BookModel(){Id=5, Title="Swift", Author="Harry" },

            };
        }
    }
}
