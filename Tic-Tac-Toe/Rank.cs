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
    public partial class Rank : Form
    {
        public Rank()
        {
            InitializeComponent();
        }
        private static string datasource = "Server=LAPTOP-MO4K16F4;Database=TicTacToe;Trusted_Connection=True;";
        private static SqlConnection connection;
        private static SqlCommand cmd;

        private void quaylai_Click(object sender, EventArgs e)
        {
            GiaoDienDaDangKi f = new GiaoDienDaDangKi();
            f.Show();
            this.Close();
        }

        private void Rank_Load(object sender, EventArgs e)
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
                int dem = 1;
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string[] cont = new string[6];
                    ListViewItem lvi;
                    cont[0] = dem.ToString();
                    cont[1] = dataReader[0].ToString();
                    cont[2] = dataReader[1].ToString();
                    cont[3] = dataReader[2].ToString();
                    cont[4] = dataReader[3].ToString();
                    cont[5] = dataReader[4].ToString();
                    lvi = new ListViewItem(cont);
                    listView1.Items.Add(lvi);
                    dem = dem + 1;
                }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            connection.Close();
        }

        private void lichsu_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
