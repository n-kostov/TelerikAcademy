using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Data
{
    public class BookstoreDAL
    {
        public static void AddBook(
            string author,
            string title,
            string isbn,
            decimal? price,
            string website)
        {
            BookstoreDBEntities context = new BookstoreDBEntities();
            Book newBook = new Book();
            Author bookAuthor = CreateOrLoadAuthor(context, author);
            newBook.Authors.Add(bookAuthor);
            newBook.Title = title;
            newBook.ISBN = isbn;
            newBook.Price = price;
            newBook.Website = website;

            context.Books.Add(newBook);
            context.SaveChanges();
        }

        public static void AddBookWithAuthorsAndReviews(
            string[] authors,
            string title,
            string isbn,
            decimal? price,
            string website,
            List<string> reviewsAuthors,
            List<DateTime> reviewDates,
            List<string> reviewTexts)
        {
            BookstoreDBEntities context = new BookstoreDBEntities();

            for (int i = 0; i < reviewTexts.Count; i++)
            {
                Review bookReview = new Review();
                Author bookReviewAuthor = CreateOrLoadAuthor(context, reviewsAuthors[i]);
                bookReview.Author = bookReviewAuthor;
                bookReview.DateOfCreation = reviewDates[i];
                bookReview.ReviewText = reviewTexts[i];

                Book newBook = CreateOrLoadBook(context, authors, title, isbn, price, website);
                bookReview.Book = newBook;

                context.Reviews.Add(bookReview);
            }

            context.SaveChanges();
        }

        public static IList<Book> FindBooksByTitleAuthorAndIsbn(string title, string author, string isbn)
        {
            BookstoreDBEntities context = new BookstoreDBEntities();
            var booksQuery =
                from b in context.Books.Include("Reviews")
                select b;
            if (title != null)
            {
                booksQuery =
                    from b in context.Books
                    where b.Title.ToLower() == title.ToLower()
                    select b;
            }

            if (author != null)
            {
                booksQuery = booksQuery.Where(
                    b => b.Authors.Any(t => t.Name.ToLower() == author.ToLower()));
            }

            if (isbn != null)
            {
                booksQuery = booksQuery.Where(
                    b => b.ISBN.ToLower() == isbn.ToLower());
            }

            booksQuery = booksQuery.OrderBy(b => b.Title);

            return booksQuery.ToList();
        }

        public static IList<Review> FindReviewsByPeriod(DateTime startDate, DateTime endDate)
        {
            BookstoreDBEntities context = new BookstoreDBEntities();

            var reviewsQuery = context.Reviews.Include("Book").Include("Author").Where(
                b => b.DateOfCreation >= startDate && b.DateOfCreation <= endDate);

            reviewsQuery = reviewsQuery.OrderBy(b => b.DateOfCreation).ThenBy(x => x.ReviewText);

            return reviewsQuery.ToList();
        }

        public static IList<Review> FindReviewsByAuthor(string author)
        {
            BookstoreDBEntities context = new BookstoreDBEntities();

            var reviewsQuery = context.Reviews.Include("Book").Include("Author").Where(
                b => b.Author.Name.ToLower() == author.ToLower());

            reviewsQuery = reviewsQuery.OrderBy(b => b.DateOfCreation).ThenBy(x => x.ReviewText);

            return reviewsQuery.ToList();
        }

        private static Book CreateOrLoadBook(BookstoreDBEntities context, string[] authors,
            string title, string isbn, decimal? price, string website)
        {
            Book existingBook =
                           (from b in context.Books
                            where b.Title.ToLower() == title.ToLower()
                            select b).FirstOrDefault();
            if (existingBook != null)
            {
                return existingBook;
            }

            Book newBook = new Book();
            foreach (var author in authors)
            {
                Author bookAuthor = CreateOrLoadAuthor(context, author);
                newBook.Authors.Add(bookAuthor);
            }

            newBook.Title = title;
            newBook.ISBN = isbn;
            newBook.Price = price;
            newBook.Website = website;

            context.Books.Add(newBook);
            context.SaveChanges();

            return newBook;
        }

        private static Author CreateOrLoadAuthor(
            BookstoreDBEntities context, string author)
        {
            if (author == null)
            {
                return null;
            }

            Author existingAuthor =
                (from a in context.Authors
                 where a.Name.ToLower() == author.ToLower()
                 select a).FirstOrDefault();
            if (existingAuthor != null)
            {
                return existingAuthor;
            }

            Author newAuthor = new Author();
            newAuthor.Name = author;
            context.Authors.Add(newAuthor);
            context.SaveChanges();

            return newAuthor;
        }
    }
}
