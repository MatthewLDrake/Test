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
    public partial class EventViewer : Form
    {
        public EventViewer(List<Event> events)
        {
            InitializeComponent();
            foreach(Event e in events)
            {
                dataGridView1.Rows.Add(new object[] { e.GetTitle(), e.GetText(),0 });
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                textBox1.Text = (string)dataGridView1.SelectedRows[0].Cells[1].Value;
                dataGridView1.SelectedRows[0].Cells[2].Value = ((int)dataGridView1.SelectedRows[0].Cells[2].Value) + 1;
            }
        }
        public void GotSelected()
        {
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.Rows[0].Selected = true;
            dataGridView1.Rows[0].Cells[2].Value = 1;
        }
        public int GetUnreadEvents()
        {
            int unread = 0;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (((int)dataGridView1.Rows[i].Cells[2].Value) == 0) 
                    unread++;
            }
            return unread;
        }
        public void AddEvent(Event newEvent)
        {
            dataGridView1.Rows.Insert(0, new object[] {newEvent.GetTitle(), newEvent.GetText(), 0});
        }

    }
}
