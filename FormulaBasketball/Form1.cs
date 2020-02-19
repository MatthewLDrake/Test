using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace FormulaBasketball
{
    public partial class Form1 : Form
    {
        Random r;
        private string[] files;
        private bool game;
        public Form1(bool game = true)
        {
            InitializeComponent();
            this.game = game;
            

            r = new Random();
            files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.fbdata");
            foreach(string str in files)
            {
                DateTime dateTime = File.GetLastWriteTime(str);
                string temp = str.Substring(str.LastIndexOf('\\') + 1);
                listView1.Rows.Add(temp, dateTime);
            }
            
            listView1.Rows[0].Selected = true;
        }
        
        private void loadButtonConfirm_Click(object sender, EventArgs e)
        {            
            Visible = false;
            if (game)
                new formulaBasketball(sender.Equals(yesButton), listView1.SelectedCells[0].OwningRow.Cells[0].EditedFormattedValue.ToString(), null, null);
            else
                new InSeasonViewer(formulaBasketball.DeSerializeObject(listView1.SelectedCells[0].OwningRow.Cells[0].EditedFormattedValue.ToString())).ShowDialog();
            Close();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                RestoreDirectory = true,
                Filter = "Formula Basketball Files (*.fbdata)|*.fbdata"
            };
            
            saveFile.ShowDialog();
            string fileName = saveFile.FileName;
            Visible = false;
            teamNumPrompt prompt = new teamNumPrompt(r);
            prompt.ShowDialog();
            newLeague league;
            if(prompt.hasLoaded())
            {
                league = new newLeague(prompt.getFileNames(), r);
            }
            else if (prompt.hasTeams())
            {
                league = new newLeague(prompt.getTeams(), r);
            }
            else
            {
                league = new newLeague(r);
            }
            league.setFileName(fileName);
            league.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void defaultButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                RestoreDirectory = true,
                Filter = "Formula Basketball Files (*.fbdata)|*.fbdata"
            };

            saveFile.ShowDialog();
            string fileName = saveFile.FileName;

            formulaBasketball formula = new formulaBasketball(sender.Equals(yesButton), fileName, null, null);
        }
    }
}
