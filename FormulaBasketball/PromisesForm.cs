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
    public partial class PromisesForm : Form
    {
        public PromisesForm()
        {
            InitializeComponent();
        }
        public List<Promises> GetPromises()
        {
            List<Promises> promises = new List<Promises>();

            if (checkBox1.Checked)
                promises.Add(Promises.Year_One_Starter);
            if (checkBox2.Checked)
                promises.Add(Promises.Win_Division);
            if (checkBox3.Checked)
                promises.Add(Promises.Win_Conference);
            if (checkBox4.Checked)
                promises.Add(Promises.Win_Championship);
            if (checkBox5.Checked)
                promises.Add(Promises.Make_Playoffs);
            if (checkBox6.Checked)
                promises.Add(Promises.No_Trade);
            if (checkBox7.Checked)
                promises.Add(Promises.Over_Five_Hundred);
            if (checkBox8.Checked)
                promises.Add(Promises.Win_Over_Fifty);
            return promises;
        }
    }
}
