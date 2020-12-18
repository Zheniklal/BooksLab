using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Books
{
    class FileManagement
    {
        public static List<Book> OpenFile(string fileName)
        {
            List<Book> books = new List<Book>();
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    books = (List<Book>)bf.Deserialize(fs);
                }

               // MessageBox.Show("File uploaded.");

                return books;
            }
            catch
            {
                MessageBox.Show("Error");
                return books;
            }

        }

        public static void SaveFile(List<Book> list, string fileName)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    bf.Serialize(fs, list);
                }
              //  MessageBox.Show("File saved.");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }

}
