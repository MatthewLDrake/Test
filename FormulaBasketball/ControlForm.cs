﻿using System;
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
    public partial class ControlForm : Form
    {
        public static int result;
        public ControlForm()
        {
            InitializeComponent();
            result = -1;
        }
        private void ButtonClick(object sender, EventArgs e)
        {
            result = int.Parse((sender as Button).Tag as String);
            Close();
        }
    }
}

