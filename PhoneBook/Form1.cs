using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> phoneBook;

        public Form1()
        {
            InitializeComponent();

            //電話帳に登録
            this.phoneBook = new Dictionary<String, string>();

            //this.phoneBook.Add("山田一郎", "052-3456-4321");
            //this.phoneBook.Add("山田治郎", "052-3456-4322");
            //this.phoneBook.Add("山田三郎", "052-3456-4323");
            //this.phoneBook.Add("山田四郎", "052-3456-4324");
            //this.phoneBook.Add("山田五郎", "052-3456-4325");

            //ファイルから読み込み
            ReadFromFile();

            //リストに名前を表示
            foreach(KeyValuePair<string,String> data in phoneBook)
            {
                this.nameList.Items.Add(data.Key);

            }

        }

        private void ReadFromFile()
        {

            using (System.IO.StreamReader file =
                new System.IO.StreamReader(@"..\..\data.txt"))
            {

                while(!file.EndOfStream)
                {
                    string line = file.ReadLine();
                    String[] data = line.Split(',');
                    this.phoneBook.Add(data[0], data[1]);
                }

            }

        }


        private void nameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = this.nameList.Text;
            this.phoneNunmber.Text = this.phoneBook[name];

        }



    }
}
