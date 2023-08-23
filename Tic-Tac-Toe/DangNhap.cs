using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pong
{
    public partial class DangNhap : Form
    {
        public static string user = "";
        public DangNhap()
        {
            InitializeComponent();
            label3.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
        }   
        private void textBox2_Click(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dangki f = new Dangki();
            f.Show();
            this.Close();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DatabaseControler.Instance.checktaikhoan(textBox1.Text) == false)
            {
               label3.Text= "Non-existing username!";
            }
            else
            {
                if (DatabaseControler.Instance.checkpass(textBox2.Text, textBox1.Text) == false)
                {
                    label3.Text = "Invalid password!";
                    textBox2.Text = "";
                }
                else
                {
                    
                    user = textBox1.Text;
                    GiaoDienDaDangKi f = new GiaoDienDaDangKi();
                    f.Show();
                    this.Close();
                }
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
