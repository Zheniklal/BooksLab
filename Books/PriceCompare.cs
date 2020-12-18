using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Books
{
    class PriceCompare : IComparer<Book>
    {
        int IComparer<Book>.Compare(Book x, Book y)
        {
            return (x.Price > y.Price) ? 1 : -1;
        }
    }
}
