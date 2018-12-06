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
    public partial class OfferPromises : Form
    {
        private List<Promises> promises;
        public OfferPromises(List<Promises> promises, bool readOnly = false)
        {
            InitializeComponent();
            this.promises = promises;
            promiseGrid.Columns[1].ReadOnly = readOnly;
            foreach(Promises promise in formulaBasketball.promisesList)
            {
                promiseGrid.Rows.Add();
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)promiseGrid[0,promiseGrid.Rows.Count - 1];
                cell.Value = promises.Contains(promise);
                promiseGrid[1,promiseGrid.Rows.Count - 1].Value = promise.ToString();
                promiseGrid[2, promiseGrid.Rows.Count - 1].Value = promise;
            }
        }
        public List<Promises> GetPromises()
        {
            return promises;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            promises = new List<Promises>();
            for (int i = 0; i < promiseGrid.Rows.Count; i++ )
            {
                bool cell = (bool)promiseGrid[0, i].Value;
                if (cell) promises.Add(promiseGrid[2, i].Value as Promises);
            }
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void promiseGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            promiseGrid.SelectedCells[0].Value = !((bool)promiseGrid.SelectedCells[0].Value);
        }
    }
}
