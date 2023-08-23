using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.IO;
namespace pong
{
    public partial class NhapTen : Form
    {
        public NhapTen()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None; // gỡ thanh tiêu đề
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ten = textBox1.Text;
            DatabaseControler.Instance.update(ten,DangNhap.user);
            MessageBox.Show("Đăng kí tên thành công");
            GiaoDienDaDangKi f = new GiaoDienDaDangKi();
            f.Show();
            this.Close();
        }

        private void NhapTen_Load(object sender, EventArgs e)
        {

        }
    }
}
