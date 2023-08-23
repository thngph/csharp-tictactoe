using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;


namespace pong
{
    public partial class Game : Form
    {
        public int score = 0;
        public int opsc = 0;
        public int stage = 1;
        bool izHost = true;
        int round = 3;
        int Port = 8080;
        string useropon = "";
        public Game(bool isHost, string ip = null, int scr = 0, int round = 3, int port=8080)
        {
            this.ControlBox = false;
            Port = port;
            izHost = isHost;

            InitializeComponent();
            Thread thdudpServer = new Thread(new ThreadStart(serverThread));
            thdudpServer.Start();
            score = scr;
            this.round = round;            
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;
            label3.Text = "Score: " + score.ToString();
            if (isHost)
            {
                
                PlayerChar = 'X';
                OpponentChar = 'O';
                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                server.Start();
                sock = server.AcceptSocket();
                label5.Text ="Username: "+ DangNhap.user;
                this.BackColor = Color.SkyBlue;
            }
            else
            {
                PlayerChar = 'O';
                OpponentChar = 'X';
                try
                {
                    client = new TcpClient(ip, 5732);
                    sock = client.Client;
                    label5.Text = "Username: " + DangNhap.user;
                    MessageReceiver.RunWorkerAsync();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            
            if (CheckState())
            {
                stage++;             
                return;
            }
            FreezeBoard();
            label1.Text = "Opponent's Turn!";
            this.BackColor = Color.IndianRed;
            ReceiveMove();
            label1.Text = "Your Turn!";
            this.BackColor = Color.SkyBlue;
            if (!CheckState())
                UnfreezeBoard();
        }
        private char PlayerChar;
        private char OpponentChar;
        private Socket sock;
        private BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;

        private bool CheckState()
        {
            //Horizontals
           
            
            if(button1.Text == button2.Text && button2.Text == button3.Text && button3.Text != "")
            {
                //FreezeBoard();
                if (button1.Text[0] == PlayerChar)
                {
                    int win = DatabaseControler.Instance.getdatabxh("win", DangNhap.user);
                    int sumscore = DatabaseControler.Instance.getdatabxh("score", DangNhap.user);
                    DatabaseControler.Instance.updatebxh("score", sumscore + 3, DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Win", 3);
                    DatabaseControler.Instance.updatebxh("win", win + 1, DangNhap.user);                    
                    score += 3;
                    label3.Text = "Score: " + score.ToString();
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                    RefreshBoard();
                    
                }
                else
                {
                    int lose = DatabaseControler.Instance.getdatabxh("lose", DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Lose", 0);
                    DatabaseControler.Instance.updatebxh("lose", lose + 1, DangNhap.user);
                    opsc += 3;   
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                    RefreshBoard();
                    //MessageReceiver.RunWorkerAsync();
                    FreezeBoard();
                    label1.Text = "Opponent's Turn!";
                    this.BackColor = Color.IndianRed;
                    ReceiveMove();
                    label1.Text = "Your Turn!";
                    this.BackColor = Color.SkyBlue;
                    if (!CheckState())
                        UnfreezeBoard();
                }
                
                return true;
            }

            else if (button4.Text == button5.Text && button5.Text == button6.Text && button6.Text != "")
            {
               // FreezeBoard();
                if (button4.Text[0] == PlayerChar)
                {
                    int win = DatabaseControler.Instance.getdatabxh("win", DangNhap.user);
                    int sumscore = DatabaseControler.Instance.getdatabxh("score", DangNhap.user);
                    DatabaseControler.Instance.updatebxh("score", sumscore + 3, DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Win", 3);
                    DatabaseControler.Instance.updatebxh("win", win + 1, DangNhap.user);
                    score += 3;
                    label3.Text = "Score: " + score.ToString();
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                    RefreshBoard();
                }
                else
                {
                    int lose = DatabaseControler.Instance.getdatabxh("lose", DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Lose", 0);
                    DatabaseControler.Instance.updatebxh("lose", lose + 1, DangNhap.user);
                    opsc += 3;
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                    RefreshBoard();
                    //MessageReceiver.RunWorkerAsync();
                    FreezeBoard();
                    label1.Text = "Opponent's Turn!";
                    this.BackColor = Color.IndianRed;
                    ReceiveMove();
                    label1.Text = "Your Turn!";
                    this.BackColor = Color.SkyBlue;
                    if (!CheckState())
                        UnfreezeBoard();

                }
                return true;
            }

            else if (button7.Text == button8.Text && button8.Text == button9.Text && button9.Text != "")
            {
               // FreezeBoard();
                if (button7.Text[0] == PlayerChar)
                {
                    int win = DatabaseControler.Instance.getdatabxh("win", DangNhap.user);
                    int sumscore = DatabaseControler.Instance.getdatabxh("score", DangNhap.user);
                    DatabaseControler.Instance.updatebxh("score", sumscore + 3, DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Win", 3);
                    DatabaseControler.Instance.updatebxh("win", win + 1, DangNhap.user);
                    score += 3;
                    label3.Text = "Score: " + score.ToString();
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                    RefreshBoard();
                }
                else
                {
                    int lose = DatabaseControler.Instance.getdatabxh("lose", DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Lose", 0);
                    DatabaseControler.Instance.updatebxh("lose", lose + 1, DangNhap.user);
                    opsc += 3;
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                    RefreshBoard();
                    //MessageReceiver.RunWorkerAsync();
                    FreezeBoard();
                    label1.Text = "Opponent's Turn!";
                    this.BackColor = Color.IndianRed;
                    ReceiveMove();
                    label1.Text = "Your Turn!";
                    this.BackColor = Color.SkyBlue;
                    if (!CheckState())
                        UnfreezeBoard();
                }
                return true;
            }

            //Verticals
            else if (button1.Text == button4.Text && button4.Text == button7.Text && button7.Text != "")
            {
               // FreezeBoard();
                if (button1.Text[0] == PlayerChar)
                {
                    int win = DatabaseControler.Instance.getdatabxh("win", DangNhap.user);
                    int sumscore = DatabaseControler.Instance.getdatabxh("score", DangNhap.user);
                    DatabaseControler.Instance.updatebxh("score", sumscore + 3, DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Win", 3);
                    DatabaseControler.Instance.updatebxh("win", win + 1, DangNhap.user);
                    score += 3;
                    label3.Text = "Score: " + score.ToString();
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                    RefreshBoard();
                }
                else
                {
                    int lose = DatabaseControler.Instance.getdatabxh("lose", DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Lose", 0);
                    DatabaseControler.Instance.updatebxh("lose", lose + 1, DangNhap.user);
                    opsc += 3;
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                    RefreshBoard();
                    //MessageReceiver.RunWorkerAsync();
                    FreezeBoard();
                    label1.Text = "Opponent's Turn!";
                    this.BackColor = Color.IndianRed;
                    ReceiveMove();
                    label1.Text = "Your Turn!";
                    this.BackColor = Color.SkyBlue;
                    if (!CheckState())
                        UnfreezeBoard();

                }
                return true;
            }

            else if (button2.Text == button5.Text && button5.Text == button8.Text && button8.Text != "")
            {
               // FreezeBoard();
                if (button2.Text[0] == PlayerChar)
                {
                    int win = DatabaseControler.Instance.getdatabxh("win", DangNhap.user);
                    int sumscore = DatabaseControler.Instance.getdatabxh("score", DangNhap.user);
                    DatabaseControler.Instance.updatebxh("score", sumscore + 3, DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Win", 3);
                    DatabaseControler.Instance.updatebxh("win", win + 1, DangNhap.user);
                    score += 3;
                    label3.Text = "Score: " + score.ToString();
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                    RefreshBoard();
                }
                else
                {
                    int lose = DatabaseControler.Instance.getdatabxh("lose", DangNhap.user);

                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Lose", 0);
                    DatabaseControler.Instance.updatebxh("lose", lose + 1, DangNhap.user);
                    opsc += 3;
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                    RefreshBoard();
                    //MessageReceiver.RunWorkerAsync();
                    FreezeBoard();
                    label1.Text = "Opponent's Turn!";
                    this.BackColor = Color.IndianRed;
                    ReceiveMove();
                    label1.Text = "Your Turn!";
                    this.BackColor = Color.SkyBlue;
                    if (!CheckState())
                        UnfreezeBoard();
                }
                return true;
            }

            else if (button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != "")
            {
              // FreezeBoard();
                if (button3.Text[0] == PlayerChar)
                {
                    int win = DatabaseControler.Instance.getdatabxh("win", DangNhap.user);
                    int sumscore = DatabaseControler.Instance.getdatabxh("score", DangNhap.user);
                    DatabaseControler.Instance.updatebxh("score", sumscore + 3, DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Win", 3);
                    DatabaseControler.Instance.updatebxh("win", win + 1, DangNhap.user);
                    score += 3;
                    label3.Text = "Score: " + score.ToString();
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                    RefreshBoard();
                }
                else
                {
                    int lose = DatabaseControler.Instance.getdatabxh("lose", DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Lose", 0);
                    DatabaseControler.Instance.updatebxh("lose", lose + 1, DangNhap.user);
                    opsc += 3;
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                    RefreshBoard();
                    //MessageReceiver.RunWorkerAsync();
                    FreezeBoard();
                    label1.Text = "Opponent's Turn!";
                    this.BackColor = Color.IndianRed;
                    ReceiveMove();
                    label1.Text = "Your Turn!";
                    this.BackColor = Color.SkyBlue;
                    if (!CheckState())
                        UnfreezeBoard();
                }
                return true;
            }

            else if (button1.Text == button5.Text && button5.Text == button9.Text && button9.Text != "")
            {
               // FreezeBoard();
                if (button1.Text[0] == PlayerChar)
                {
                    int win = DatabaseControler.Instance.getdatabxh("win", DangNhap.user);
                    int sumscore = DatabaseControler.Instance.getdatabxh("score", DangNhap.user);
                    DatabaseControler.Instance.updatebxh("score", sumscore + 3, DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Win", 3);
                    DatabaseControler.Instance.updatebxh("win", win + 1, DangNhap.user);
                    score += 3;
                    label3.Text = "Score: " + score.ToString();
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                    RefreshBoard();
                }
                else
                {
                    int lose = DatabaseControler.Instance.getdatabxh("lose", DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Lose", 0);
                    DatabaseControler.Instance.updatebxh("lose", lose + 1, DangNhap.user);
                    opsc += 3;
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                    RefreshBoard();
                    //MessageReceiver.RunWorkerAsync();
                    FreezeBoard();
                    label1.Text = "Opponent's Turn!";
                    this.BackColor = Color.IndianRed;
                    ReceiveMove(); 
                    label1.Text = "Your Turn!";
                    this.BackColor = Color.SkyBlue;
                    if (!CheckState())
                        UnfreezeBoard();
                }
                return true;
            }

            else if (button3.Text == button5.Text && button5.Text == button7.Text && button7.Text != "")
            {
               // FreezeBoard();
                if (button3.Text[0] == PlayerChar)
                {
                    int win = DatabaseControler.Instance.getdatabxh("win", DangNhap.user);
                    int sumscore = DatabaseControler.Instance.getdatabxh("score", DangNhap.user);
                    DatabaseControler.Instance.updatebxh("score", sumscore + 3, DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Win", 3);
                    DatabaseControler.Instance.updatebxh("win", win + 1, DangNhap.user);
                    score += 3;
                    label3.Text = "Score: " + score.ToString();
                    label1.Text = "You Won!";
                    MessageBox.Show("You Won!");
                    RefreshBoard();
                }
                else
                {
                    int lose = DatabaseControler.Instance.getdatabxh("lose", DangNhap.user);
                    DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Lose", 0);
                    DatabaseControler.Instance.updatebxh("lose", lose + 1, DangNhap.user);
                    opsc += 3;
                    label1.Text = "You Lost!";
                    MessageBox.Show("You Lost!");
                    RefreshBoard();
                    //MessageReceiver.RunWorkerAsync();
                    FreezeBoard();
                    label1.Text = "Opponent's Turn!";
                    this.BackColor = Color.IndianRed;
                    ReceiveMove();
                    label1.Text = "Your Turn!";
                    this.BackColor = Color.SkyBlue;
                    if (!CheckState())
                        UnfreezeBoard();
                }
                return true;
            }

            //Draw
            else if(button1.Text != "" && button2.Text != "" && button3.Text != "" && button4.Text != "" && button5.Text != "" && button6.Text != "" && button7.Text != "" && button8.Text != "" && button9.Text != "")
            {
                //  FreezeBoard();
                int draw = DatabaseControler.Instance.getdatabxh("draw", DangNhap.user);
                int sumscore = DatabaseControler.Instance.getdatabxh("score", DangNhap.user);
                DatabaseControler.Instance.updatebxh("score", sumscore + 1, DangNhap.user);
                DatabaseControler.Instance.insertlichsu(DangNhap.user, useropon, AppControler.LayThoiGian(), "Draw", 1);
                DatabaseControler.Instance.updatebxh("draw", draw + 1, DangNhap.user);
                score += 1;
                opsc += 1;
                label3.Text = "Score: " + score.ToString();
                label1.Text = "It's a draw!";
                
                MessageBox.Show("It's a draw!");
                if (!izHost) {

                    RefreshBoard();
                    //MessageReceiver.RunWorkerAsync();
                    FreezeBoard();
                    label1.Text = "Opponent's Turn!";
                    this.BackColor = Color.IndianRed;
                    ReceiveMove();
                    label1.Text = "Your Turn!";
                    this.BackColor = Color.SkyBlue;
                    if (!CheckState())
                        UnfreezeBoard();
                    return true;
                }
                else RefreshBoard();
                return true;
            }

            label3.Text = "Score: " + score.ToString();
            return false;
        }
        private void FreezeBoard()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }

        private void UnfreezeBoard()
        {
            if (button1.Text == "")
                button1.Enabled = true;
            if (button2.Text == "")
                button2.Enabled = true;
            if (button3.Text == "")
                button3.Enabled = true;
            if (button4.Text == "")
                button4.Enabled = true;
            if (button5.Text == "")
                button5.Enabled = true;
            if (button6.Text == "")
                button6.Enabled = true;
            if (button7.Text == "")
                button7.Enabled = true;
            if (button8.Text == "")
                button8.Enabled = true;
            if (button9.Text == "")
                button9.Enabled = true;
        }

        private void RefreshBoard()
        {
           
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            UnfreezeBoard();
        }

        private void ReceiveMove()
        {
            byte[] buffer = new byte[1];
            sock.Receive(buffer);
            if (buffer[0] == 1)
                button1.Text = OpponentChar.ToString();
            if (buffer[0] == 2)
                button2.Text = OpponentChar.ToString();
            if (buffer[0] == 3)
                button3.Text = OpponentChar.ToString();
            if (buffer[0] == 4)
                button4.Text = OpponentChar.ToString();
            if (buffer[0] == 5)
                button5.Text = OpponentChar.ToString();
            if (buffer[0] == 6)
                button6.Text = OpponentChar.ToString();
            if (buffer[0] == 7)
                button7.Text = OpponentChar.ToString();
            if (buffer[0] == 8)
                button8.Text = OpponentChar.ToString();
            if (buffer[0] == 9)
                button9.Text = OpponentChar.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] num = { 1 };
            sock.Send(num);
            button1.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
            //gui user
            UdpClient udp = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            byte[] msg = Encoding.UTF8.GetBytes("#"+DangNhap.user);
            udp.Send(msg, msg.Length, iPEndPoint);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] num = { 2 };
            sock.Send(num);
            button2.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
            //gui user
            UdpClient udp = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            byte[] msg = Encoding.UTF8.GetBytes("#" + DangNhap.user);
            udp.Send(msg, msg.Length, iPEndPoint);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] num = { 3 };
            sock.Send(num);
            button3.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
            //gui user
            UdpClient udp = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            byte[] msg = Encoding.UTF8.GetBytes("#" + DangNhap.user);
            udp.Send(msg, msg.Length, iPEndPoint);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] num = { 4 };
            sock.Send(num);
            button4.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
            //gui user
            UdpClient udp = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            byte[] msg = Encoding.UTF8.GetBytes("#" + DangNhap.user);
            udp.Send(msg, msg.Length, iPEndPoint);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] num = { 5 };
            sock.Send(num);
            button5.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
            //gui user
            UdpClient udp = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            byte[] msg = Encoding.UTF8.GetBytes("#" + DangNhap.user);
            udp.Send(msg, msg.Length, iPEndPoint);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] num = { 6 };
            sock.Send(num);
            button6.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
            //gui user
            UdpClient udp = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            byte[] msg = Encoding.UTF8.GetBytes("#" + DangNhap.user);
            udp.Send(msg, msg.Length, iPEndPoint);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] num = { 7 };
            sock.Send(num);
            button7.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
            //gui user
            UdpClient udp = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            byte[] msg = Encoding.UTF8.GetBytes("#" + DangNhap.user);
            udp.Send(msg, msg.Length, iPEndPoint);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte[] num = { 8 };
            sock.Send(num);
            button8.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
            //gui user
            UdpClient udp = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            byte[] msg = Encoding.UTF8.GetBytes("#" + DangNhap.user);
            udp.Send(msg, msg.Length, iPEndPoint);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            byte[] num = { 9 };
            sock.Send(num);
            button9.Text = PlayerChar.ToString();
            MessageReceiver.RunWorkerAsync();
            //gui user
            UdpClient udp = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            byte[] msg = Encoding.UTF8.GetBytes("#" + DangNhap.user);
            udp.Send(msg, msg.Length, iPEndPoint);
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageReceiver.WorkerSupportsCancellation = true;
            MessageReceiver.CancelAsync();
            if (server != null)
                server.Stop();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            UdpClient udp = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            byte[] msg = Encoding.UTF8.GetBytes(DangNhap.user +": " +textBox1.Text);
            udp.Send(msg, msg.Length, iPEndPoint);

            listView1.Items.Add(DangNhap.user + ": " + textBox1.Text);
            textBox1.Clear();
        }
        public void serverThread()
        {
            int port2 = 8000;
            if (Port == 8000)
                port2 = 8080;
            UdpClient udpClient = new UdpClient(port2);
            while (true)
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] mes = udpClient.Receive(ref ipEndPoint);
                string message = Encoding.UTF8.GetString(mes);
                if (message.StartsWith("#"))
                    useropon = message.Replace("#", "");
                else
                    listView1.Items.Add( message);
            }
        }
        
        private void button11_Click(object sender, EventArgs e)
        {
            UdpClient udp = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
            byte[] msg = Encoding.UTF8.GetBytes("YOUR ENEMY HAS BEEN SLAYED 🤣🤣🤣");
            udp.Send(msg, msg.Length, iPEndPoint);
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = "playinggamemusic.wav";
                player.PlayLooping();
                checkBox1.Text = "Music off";
            }
            else
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = "playinggamemusic.wav";
                player.Stop();
                checkBox1.Text = "Music on";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
