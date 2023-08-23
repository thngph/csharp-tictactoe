using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace pong
{
    public class DatabaseControler
    {
        private static string datasource = "Server=LAPTOP-MO4K16F4;Database=TicTacToe;Trusted_Connection=True;";
        private static SqlConnection connection;
        private static SqlCommand cmd;
        private DatabaseControler ()
        {
            connection = new SqlConnection(datasource);   
            cmd= new SqlCommand();
            cmd.Connection = connection;
 
        }
        private static DatabaseControler instance;
        public static DatabaseControler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseControler();
                }
                return instance;
            }
        }
        public void insert(string value,string cot,string bang)// them ten nguoi choi vào cột người chơi
        {
            connection.Open();
            try
            {

                string query = "insert into +"+bang+"("+cot+") values ('"+value+"')";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }
        public void insertlichsu (string taikhoan,string doithu,string thoigian, string result,int score)//thêm lịch sử
        {
            connection.Open();
            try
            {

                string query = "insert into lichsu values('"+taikhoan+ "','"+doithu+"','" + thoigian +"','"+result+"',"+score+")";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }
        public void update(string value,string taikhoan)//update ten nguoi dung
        {
            connection.Open();
            try
            {

                string query = "update userpass set ten='" + value + "' where taikhoan='" + taikhoan + "'";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }
        public void updatebxh(string value,int data, string taikhoan)//cập nhật bảng xếp hạng
        {
            connection.Open();
            try
            {

                string query = "update bangxephang set "+value+"=" + data + " where taikhoan = '" + taikhoan + "'";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }
        public string select(string value,string table,string taikhoan) // lấy dữ liệu value
        {
            string res="";
            connection.Open();
            try
            {
                string query = "select " + value + " from "+table+ " where taikhoan = '" + taikhoan + "'";
                cmd.CommandText = query;
                SqlDataReader dataReader = cmd.ExecuteReader();//ExecuteReader dùng khi cần lấy giá trị trả về
                dataReader.Read();
                res = dataReader[value].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return res;
        }
        public int getdatabxh(string value, string taikhoan) // lấy dữ liệu từ bảng xếp hạng
        {
            int res = 0;
            connection.Open();
            try
            {
                string query = "select " + value + " from bangxephang where taikhoan='" + taikhoan + "'";
                cmd.CommandText = query;
                SqlDataReader dataReader = cmd.ExecuteReader();//ExecuteReader dùng khi cần lấy giá trị trả về
                dataReader.Read();
                res = Int32.Parse(dataReader[value].ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return res;
        }
        public string showlichsu(string taikhoan)//hiển thị lịch sử của người chơi
        {
            string res = "";
            connection.Open();
            try
            {
                string query = "select doithu,result,thoigian,score from lichsu where taikhoan='" + taikhoan + "'order by score DESC";
                cmd.CommandText = query;
                SqlDataReader dataReader = cmd.ExecuteReader();
                while(dataReader.Read())
                {
                    res=res+dataReader[0].ToString() +"             "+ dataReader[1].ToString()+"     "+dataReader[2].ToString()+"     "+dataReader[3].ToString()+"\n";
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return res;
        }
        public string showbxh()//hiển thị bch của người chơi
        {
            string res = "";
            connection.Open();
            try
            {
                string query = "select * from bangxephang order by score DESC";
                cmd.CommandText = query;
                int dem = 1;
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    res = res +"    "+ dem.ToString() +"          "+dataReader[0].ToString() +"            " + dataReader[1].ToString() + "          " + dataReader[2].ToString() + "         " + dataReader[3].ToString() + "           " +dataReader[4].ToString()+"\n";
                    dem = dem + 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return res;
        }
        public void xoalichsu (string taikhoan) // xóa lịch sử người chơi
        {
            connection.Open();
            try
            {
                string query = "delete  from lichsu where taikhoan='" + taikhoan + "'";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }
        public bool checktaikhoan (string taikhoan)//kiểm tra xem có tồn tại tài khoản đó chưa
        {
            bool kiemtra;
            connection.Open();
            string query = "select * from userpass where taikhoan='" + taikhoan + "'";
            cmd.CommandText = query;
            SqlDataReader reader= cmd.ExecuteReader();
            kiemtra = reader.Read();// kiemtra= true là có dữ liệu, = false là không có dữ liệu                   
            reader.Close();
            connection.Close();
            return kiemtra;
        }
        public bool checkpass(string pass, string taikhoan)//kiểm tra mật khẩu đăng nhập đúng không
        {
            bool kiemtra;
            connection.Open();
            string query = "select * from userpass where matkhau='" + pass + "' and taikhoan='"+ taikhoan + "'";
            cmd.CommandText = query;
            SqlDataReader reader = cmd.ExecuteReader();
            kiemtra = reader.Read();// kiemtra= true là có dữ liệu, = false là không có dữ liệu                   
            reader.Close();
            connection.Close();
            return kiemtra;
        }
        public void insertuser(string user,string pass,string name,string time)//thêm thông tin tài khoản
        {
            connection.Open();
            try
            {

                string query = "insert into userpass values('" + user + "','" + pass + "','" + time +"','"+name+"')";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }
        public void insertbxh(string user)//thêm thông tin tài khoản
        {
            connection.Open();
            try
            {

                string query = "insert into bangxephang values ('" + user + "',0,0,0,0)";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
        }
    }

}
