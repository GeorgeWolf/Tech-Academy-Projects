using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HtmlHelperMethods.Models
{
    public class Books
    {
        public List<Book> GetBooks()
        {
            var books = new List<Book>();

            books.Add(new Book { BookId = 1, Title = "What About Bob", CopiesSold = 4, Price = 24.95M, Genre = Genre.Biography, InStock = true });
            books.Add(new Book { BookId = 2, Title = "Learning Bob 2.0", CopiesSold = 5, Price = 44.95M, Genre = Genre.Techincal, InStock = false });
            books.Add(new Book { BookId = 3, Title = "The Good, the Bad and the Bob", CopiesSold = 9, Price = 13.95M, Genre = Genre.Western, InStock = true });

            return books;
        }
    }

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; }
        public int CopiesSold { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public Availability Availability { get; set; }

        public string Category { get; set; }

        [Required]
        public Genre? Genre { get; set; }
        public string Description { get; set; }
    }

    // I have to set SciFi = 1 so that it shows up correctly on the form.
    // See Html.DropDownListForEnum
    // If you need it to be 0 then you need to
    // change the property to nullable:
    // public Genre? Genre { get; set; }
    // Then you could apply the [Required] attribute
    public enum Genre
    {
        SciFi,
        Western,
        Techincal,
        Biography
    }

    public enum Availability
    {
        Pickup,
        Delivery,
        Reseller
    }
}