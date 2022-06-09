using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyMotor.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;//singleton - giúp k cần tạo lại provider cho các chức năng khác
        private string constr = @"Data Source=DESKTOP-01GQNQ8\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";

        public static DataProvider Instance 
        {
            get { if (instance == null) instance = new DataProvider() ; return DataProvider.instance; }
            private set { DataProvider.instance = value; } //chỉ trong class này
        }
        private DataProvider() { }

        public DataTable ExcuteQuery(string query)
        {
            DataTable data = new DataTable();

            using (SqlConnection con = new SqlConnection(constr))
            { //kết nối từ client đến server

                con.Open();
                SqlCommand com = new SqlCommand(query, con);//câu truy vấn thực thi

                SqlDataAdapter adapter = new SqlDataAdapter(com); //trung gian lấy dữ liệu
                adapter.Fill(data);
                con.Close();
            }
                return data;
            }

        internal void ExcuteQuery(string v, object[] vs)
        {
            throw new NotImplementedException();
        }
    }
    }
