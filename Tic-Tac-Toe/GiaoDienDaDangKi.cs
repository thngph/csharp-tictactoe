using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace pong
{
    public partial class GiaoDienDaDangKi : Form
    {
        public string name;
        public static string taikhoan = DangNhap.user;
        public GiaoDienDaDangKi()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None; // gỡ thanh tiêu đề
            tennguoichoi.Text = DatabaseControler.Instance.select("ten","userpass",taikhoan);
            highscore.Text = DatabaseControler.Instance.select("score","bangxephang",taikhoan);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Beep();
            MakeRoom f = new MakeRoom();
            f.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.Beep();
            Huongdan f = new Huongdan();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.Beep();
            Application.Exit();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void GiaoDien_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Console.Beep();
            NhapTen f = new NhapTen();
            f.Show();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void tennguoichoi_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click_2(object sender, EventArgs e)
        {
            Console.Beep();
            NhapTen f = new NhapTen();
            f.Show();
            this.Close();
        }

        private void highscore_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LichSuNguoiChoi f = new LichSuNguoiChoi();
            f.Show();
            this.Close();
        }

     /*   private void button6_Click(object sender, EventArgs e)
        {
            if(button6.Text == "Music off")
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = "FILE_20210513_221817_MusicGamePingpong.wav";
                player.Stop();
                button6.Text = "Music on";
            }
            else
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = "FILE_20210513_221817_MusicGamePingpong.wav";
                player.PlayLooping();
                button6.Text = "Music off";
            }
          
        }*/

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Top f = new Top();
            f.Show();
            this.Close();
        }

        private void GiaoDienDaDangKi_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
