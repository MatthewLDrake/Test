using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaBasketball
{
    public partial class FirstScreen : Form
    {
        public FirstScreen()
        {
            InitializeComponent();

            //string ipAddress = GetLocalIPAddress();

            //label1.Text = ipAddress;

        }
        private string GetLocalIPAddress()
        {
            String url = "http://bot.whatismyipaddress.com/";
            String result = null;

            try
            {
                WebClient client = new WebClient();
                result = client.DownloadString(url);
                return result;
            }
            catch (Exception) { return "127.0.0.1"; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Form1().ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*TcpListener serverSocket = new TcpListener(8888);
            
            int requestCount = 0;
            TcpClient clientSocket = default(TcpClient);
            serverSocket.Start();
            label2.Visible = true;
            label2.Text = "Server Open. " + requestCount + " clients connected.";
            clientSocket = serverSocket.AcceptTcpClient();

            try
            {
                requestCount++;
                NetworkStream networkStream = clientSocket.GetStream();
                byte[] bytesFrom = new byte[10025];
                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                string dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                Console.WriteLine(" >> Data from client - " + dataFromClient);
                string serverResponse = "Last Message from client" + dataFromClient;
                Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                networkStream.Write(sendBytes, 0, sendBytes.Length);
                networkStream.Flush();
                Console.WriteLine(" >> " + serverResponse);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TcpClient clientSocket = new TcpClient();
            clientSocket.Connect("127.0.0.1", 8888);

            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox2.Text + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            msg(returndata);
            textBox2.Text = "";
            textBox2.Focus();

        }

        public void msg(string mesg)
        {
            textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + mesg;
        }

        private void Offseason_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Form1(false).ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new FixScreen(formulaBasketball.DeSerializeObject("saveFile.fbusave"), new Random()).ShowDialog();
            this.Close();
        }
    }
    
}
