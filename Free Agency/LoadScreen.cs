using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Free_Agency
{
    public partial class LoadScreen : Form
    {
        private string[] files;
        private FormulaBasketball.Random r;
        public LoadScreen(string extension)
        {
            InitializeComponent();
            r = new FormulaBasketball.Random();
            files = Directory.GetFiles(Directory.GetCurrentDirectory(), extension);
            foreach (string str in files)
            {
                DateTime dateTime = File.GetLastWriteTime(str);
                string temp = str.Substring(str.LastIndexOf('\\') + 1);
                listView1.Rows.Add(temp, dateTime);
            }

            listView1.Rows[0].Selected = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            Menu menu = new Menu(listView1.SelectedCells[0].OwningRow.Cells[0].EditedFormattedValue.ToString(), 7, r);
            menu.ShowDialog();
            Close();
        }
    }
}
