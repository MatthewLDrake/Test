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
    public partial class MockDraftView : Form
    {
        public MockDraftView(List<player> mockDraft, DraftPick[] picks)
        {
            InitializeComponent();

            for (int i = 0; i < mockDraft.Count; i++)
                dataGridView1.Rows.Add(new object[] { i + 1, picks[i].GetOwner().ToString(), mockDraft[i].getPosition(), mockDraft[i].getName() });

        }
    }
}
