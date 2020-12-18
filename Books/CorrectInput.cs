using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Books
{
    static class CorrectInput
    {
        public static void TypeOnlyDigits(KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
                if (e.KeyChar != (char)Keys.Back)
                    if (e.KeyChar != (char)Keys.Space)
                        e.Handled = true;
        }
        public static void TypeOnlyLetters(KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar)))
                if (e.KeyChar != (char)Keys.Back)
                    if (e.KeyChar != (char)Keys.Space)
                        e.Handled = true;
        }
        public static void MoneyInput(KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if (!(Char.IsDigit(e.KeyChar)))
                if (e.KeyChar != (char)Keys.Back)
                    if (e.KeyChar != (char)Keys.Space)
                        if (e.KeyChar != ',')
                            e.Handled = true;
        }
        public static bool AllFieldsAreCorrect(string isbn, string title, string author, string ph, string year, string price)
        {
            if (isbn.Length == 13) 
                if (title != "") 
                    if (author != "") 
                        if (ph != "")  
                            if (year != "" && year != "0") 
                                if (price != "" && price != "0")
                                    return true;
                                else MessageBox.Show("Price is incorrect");
                            else MessageBox.Show("Year is incorrect");
                        else MessageBox.Show("Please enter Publishing House");
                    else MessageBox.Show("Please enter author");
                else MessageBox.Show("Please enter title");
            else MessageBox.Show("ISBN is incorrect");

            return false;
        }
    }
}
