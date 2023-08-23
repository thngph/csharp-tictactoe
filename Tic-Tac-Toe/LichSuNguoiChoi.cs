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
    public partial class LichSuNguoiChoi : Form
    {
        private static string datasource = "Server=LAPTOP-MO4K16F4;Database=TicTacToe;Trusted_Connection=True;";
        private static SqlConnection connection;
        private static SqlCommand cmd;
        public LichSuNguoiChoi()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None; // gỡ thanh tiêu đề
            connection = new SqlConnection(datasource);
            cmd = new SqlCommand();
            cmd.Connection = connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GiaoDienDaDangKi f = new GiaoDienDaDangKi();
            f.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lichsu_TextChanged(object sender, EventArgs e)
        {

        }

        private void lichsu_Click(object sender, EventArgs e)
        {

        }

        private void xoalichsu_Click(object sender, EventArgs e)
        {
            
        }

        private void lichsu_Click_1(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LichSuNguoiChoi_Load(object sender, EventArgs e)
        {
            showlichsu(DangNhap.user);
        }
        public void showlichsu(string taikhoan)//hiển thị lịch sử của người chơi
        {
            connection.Open();
            try
            {
                string query = "select doithu,thoigian,result,bonusscore from lichsu where taikhoan='" + taikhoan + "' order by thoigian asc" ;
                cmd.CommandText = query;
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string[] cont = new string[6];
                    ListViewItem lvi;
                    cont[0] = dataReader[0].ToString();
                    cont[1] = dataReader[1].ToString();
                    cont[2] = dataReader[2].ToString();
                    cont[3] = "+ "+dataReader[3].ToString();
                    lvi = new ListViewItem(cont);
                    listView1.Items.Add(lvi);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }
    }
}
