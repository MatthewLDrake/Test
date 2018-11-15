using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class Form2 : Form
    {
        String result;
        public Form2()
        {
            InitializeComponent();
            result = "";
        }

        public string GetResult()
        {
            return result;
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            result = button.Name;
            Close();

        }


        internal int GetSeasons()
        {
            throw new NotImplementedException();
        }
    }
}
