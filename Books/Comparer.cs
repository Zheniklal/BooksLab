using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class Comparer
    {
        private List<IComparer<Book>> comparers;

        public Comparer()
        {
            this.comparers = new List<IComparer<Book>>()
            {
                new ISBNCompare(),
                new TitleCompare(),
                new AuthorCompare(),
                new PHCompare(),
                new YearCompare(),
                new PriceCompare()
            };
        }

        public IComparer<Book> GetComparer(int index)
        {
            return (IComparer<Book>)comparers[index];
        }
    }
}
