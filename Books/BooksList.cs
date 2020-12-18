using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    [Serializable]
    class BooksList
    {
        public List<Book> list;
        public BooksList()
        {
            list = new List<Book>();            
        }

        public void Add(Book book)
        {
            list.Add(book);
        }
        public void Sort(IComparer<Book> comparer)
        {
            list.Sort(comparer);
        }
        public void Delete(Book book)
        {
            list.Remove(book);
        }
    }
}
