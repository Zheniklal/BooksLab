using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;

namespace Books
{
    public partial class Form1 : Form
    {
        BooksList list = new BooksList();
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Add()
        {
            string isbn = textBoxISBN.Text;
            string title = textBoxTitle.Text;
            string author = textBoxAuthor.Text;
            string publishingHouse = textBoxPH.Text;
            int year = 0;
            float price = 0;
            try
            {
                year = int.Parse(textBoxYear.Text);
                price = float.Parse(textBoxPrice.Text);
            }
            catch
            {
                MessageBox.Show("Incorrect input");
            }

            if (CorrectInput.AllFieldsAreCorrect(isbn,title,author,publishingHouse, year.ToString() , price.ToString()))
            { 
                Book book = new Book(isbn, title, author, publishingHouse, year, price);
                list.Add(book);
                //Book temp = new Book();
                //temp.author

                dataGridView1.Rows.Add(book.Isbn, book.Title, book.Author, book.PublishingHouse, book.Year, book.Price);

                textBoxISBN.Clear();
                textBoxTitle.Clear();
                textBoxAuthor.Clear();
                textBoxPH.Clear();
                textBoxYear.Clear();
                textBoxPrice.Clear();
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            bool noMatches = true;
            foreach (Book book in list.list)
            {
                if (book.Isbn == textBoxISBN.Text)
                {
                    noMatches = false;
                    MessageBox.Show("ISBN is reserved");
                    break;
                }
            }
            if (noMatches)
                Add();
        }

        private void TextBoxYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            CorrectInput.TypeOnlyDigits(e);

        }
        private void TextBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            CorrectInput.MoneyInput(e);
        }
        private void TextBoxISBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            CorrectInput.TypeOnlyDigits(e);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                FileManagement.SaveFile(list.list, fileName);
            }
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                List<Book> books = FileManagement.OpenFile(fileName);
                list.list.Clear();
                list.list.AddRange(books);
                dataGridView1.Rows.Clear();
                
                foreach (Book book in list.list)
                {
                    dataGridView1.Rows.Add(book.Isbn, book.Title, book.Author, book.PublishingHouse, book.Year, book.Price);
                }
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            list.list.Clear();
            dataGridView1.Rows.Clear();
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Comparer comparer = new Comparer();
            IComparer<Book> cmp = comparer.GetComparer(e.ColumnIndex);
            list.list.Sort(cmp);

            dataGridView1.Rows.Clear();

            foreach (Book book in list.list)
            {
                dataGridView1.Rows.Add(book.Isbn, book.Title, book.Author, book.PublishingHouse, book.Year, book.Price);
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            buttonDelete.Enabled = true;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            string isbnToDelete = list.list[dataGridView1.CurrentCell.RowIndex].Isbn;
            foreach (Book book in list.list)
            {
                if (book.Isbn == isbnToDelete)
                {
                    list.Delete(book);
                    break;
                }
                    
            }
            dataGridView1.Rows.Clear();
            foreach (Book book in list.list)
            {
                dataGridView1.Rows.Add(book.Isbn, book.Title, book.Author, book.PublishingHouse, book.Year, book.Price);
            }

            buttonDelete.Enabled = false;
        }

        private void ButtonDelete_Click_1(object sender, EventArgs e)
        {
            string isbnToDelete = list.list[dataGridView1.CurrentCell.RowIndex].Isbn;
            foreach (Book book in list.list)
            {
                if (book.Isbn == isbnToDelete)
                {
                    list.Delete(book);
                    break;
                }

            }
            dataGridView1.Rows.Clear();
            foreach (Book book in list.list)
            {
                dataGridView1.Rows.Add(book.Isbn, book.Title, book.Author, book.PublishingHouse, book.Year, book.Price);
            }

            buttonDelete.Enabled = false;
        }
    }
}
