﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class TitleCompare : IComparer<Book>
    {
        int IComparer<Book>.Compare(Book x, Book y)
        {
            return String.Compare(x.Title, y.Title);
        }
    }
}
