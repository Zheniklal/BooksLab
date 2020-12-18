using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books
{
    [Serializable]
    class Book : IComparable<Book>
    {
        private string isbn;
        private string title;// { get; set; }
        private string author;// { get; set; }
        private string publishingHouse;// { get; set; }
        private int year;// { get; set; }
        private float price;// { get; set; }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
          //  set { author = value; }
        }
        public string PublishingHouse
        {
            get { return publishingHouse; }
            set { publishingHouse = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        
        public Book()
        { }
        public Book(string isbn, string title, string author, string publishingHouse, int year, float price)
        {
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.publishingHouse = publishingHouse;
            this.year = year;
            this.price = price;
        }

        public int CompareTo(Book other)
        {
            if (this.title.CompareTo(other.title)!= 0) { 
                return this.title.CompareTo(other.title);
            }
            else
                if (this.author.CompareTo(other.author) != 0)
                {
                return this.author.CompareTo(other.author);
                }
            return 0;
        }


    }
}
