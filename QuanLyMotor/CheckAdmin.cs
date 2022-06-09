using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyMotor
{
    public partial class CheckAdmin : Form
    {
        public CheckAdmin()
        {
            InitializeComponent();
        }

        private void btnCheckAdmin_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=DESKTOP-01GQNQ8\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);//kết nối từ client đến server
            string query = "SELECT * FROM dbo.Account WHERE PassWord = @PassWord AND Type = 1";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@PassWord", txbCheckAdmin.Text);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows)
            {
                DialogResult = DialogResult.OK;
                Admin openH = new Admin();
                this.Hide();
                openH.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không phải là Admin!");
                txbCheckAdmin.Clear();
            }

            con.Close();
        }

        private void CheckAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
