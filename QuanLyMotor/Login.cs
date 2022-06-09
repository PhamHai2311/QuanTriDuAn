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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            string constr = @"Data Source=DESKTOP-01GQNQ8\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);//kết nối từ client đến server
            string query = "SELECT * FROM dbo.Account WHERE UserName = @UserName AND PassWord = @PassWord AND Type = @Type";
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.AddWithValue("@UserName", txbUserName.Text);
            com.Parameters.AddWithValue("@PassWord", txbPassWord.Text);
            com.Parameters.AddWithValue("@Type", rdAdmin.Checked);
            con.Open();
            SqlDataReader dr = com.ExecuteReader();
            if(dr.HasRows)
            {
                DialogResult = DialogResult.OK;
                Manager openH = new Manager();
                this.Hide();
                openH.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
  
            con.Close();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        

        private void ckb_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_ShowPass.Checked)
            {
                txbPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                txbPassWord.UseSystemPasswordChar = true;
            }
        }
    }


}


