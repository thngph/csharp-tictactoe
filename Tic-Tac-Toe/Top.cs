using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pong
{
    public partial class Top : Form
    {
        public Top()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
        }
        private static string datasource = "Server=LAPTOP-MO4K16F4;Database=TicTacToe;Trusted_Connection=True;";
        private static SqlConnection connection;
        private static SqlCommand cmd;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(datasource);
            cmd = new SqlCommand();
            cmd.Connection = connection;
            showbxh();
        }
        public void showbxh()//hiển thị bxh của người chơi
        {
            connection.Open();
            //try
            //{
            string query = "select * from bangxephang order by score DESC";
            cmd.CommandText = query;
            int dem = 0;
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                if (dem == 0)
                    top1.Text = dataReader[0].ToString();
                else if (dem == 1)
                    top2.Text = dataReader[0].ToString();
                else if (dem == 2)
                    top3.Text = dataReader[0].ToString();
                else if (dem > 2)
                    break;
                dem = dem + 1;
            }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            connection.Close();
        }

        private void top1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rank f = new Rank();
            f.Show();
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void quaylai_Click(object sender, EventArgs e)
        {
            GiaoDienDaDangKi f = new GiaoDienDaDangKi();
            f.Show();
            this.Close();
        }
    }
}
