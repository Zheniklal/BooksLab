using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class YearCompare : IComparer<Book>
    {
        int IComparer<Book>.Compare(Book x, Book y)
        {
            if (x.Year > y.Year)
                return 1;
            if (x.Year < y.Year)
                return -1;
            else
                return 0;
        }
    }
}
