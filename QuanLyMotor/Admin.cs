using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyMotor.DAO;
using System.Data.SqlClient;


namespace QuanLyMotor
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            LoadAccountList();
            ShowCT();
            ShowStaff();
            ShowMotor();
            AddMotorCateBinding();
            AddMotorBinding();
            AccBinding();
            AddStaffBinding();
        }

        private void tbMotor_Click(object sender, EventArgs e)
        {

        }

        void AddMotorBinding()
        {
            txbMotorID.DataBindings.Add(new Binding("Text", dtgvMotor.DataSource, "ID"));
            txbIDCategory.DataBindings.Add(new Binding("Text", dtgvMotor.DataSource, "IDCategory"));
            txbMotorName.DataBindings.Add(new Binding("Text", dtgvMotor.DataSource, "Name"));
            txbMotorPrice.DataBindings.Add(new Binding("Text", dtgvMotor.DataSource, "Price"));
            txbMotorInfo.DataBindings.Add(new Binding("Text", dtgvMotor.DataSource, "Info"));
            txbMotorStatus.DataBindings.Add(new Binding("Text", dtgvMotor.DataSource, "Status"));

        }

        void AddMotorCateBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID"));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name"));
        }

        void AddStaffBinding()
        {
            txbIDStaff.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "ID"));
            txbNameStaff.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "Name"));
            txbAgeStaff.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "Age"));
            txbOffice.DataBindings.Add(new Binding("Text", dtgvStaff.DataSource, "Office"));
        }

        void LoadAccountList()
        {
            string query = "SELECT * FROM Account";
            dtgvAccount.DataSource = DataProvider.Instance.ExcuteQuery(query);

        }

        void AccBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName"));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName"));
            txbPassWord.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "PassWord"));
        }
        void ShowMotor()
        {
            dtgvMotor.DataSource = DataProvider.Instance.ExcuteQuery("SELECT * FROM Motor");
        }
        void ShowCT()
        {
            dtgvCategory.DataSource = DataProvider.Instance.ExcuteQuery("SELECT * FROM MotorCategory");
        }

        void ShowStaff()
        {
            dtgvStaff.DataSource = DataProvider.Instance.ExcuteQuery("SELECT * FROM Staff");
        }
        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM MotorCategory WHERE ID LIKE N'" + txbCategoryID.Text + "%' AND Name LIKE N'" +
             txbCategoryName.Text + "%'";
            dtgvCategory.DataSource = DataProvider.Instance.ExcuteQuery(query);
            txbCategoryID.Clear();
            txbCategoryName.Clear();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "INSERT INTO dbo.MotorCategory (name) VALUES (@name)";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@name", txbCategoryName.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "MotorCategory");
            MessageBox.Show("Thêm danh mục thành công!");
            dtgvCategory.DataSource = ds.Tables["MotorCategory"];
            ShowCT();
            con.Close();

        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "UPDATE dbo.MotorCategory SET name = @name";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@name", txbCategoryName.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "MotorCategory");
            MessageBox.Show("Sửa danh mục thành công!");
            dtgvCategory.DataSource = ds.Tables["MotorCategory"];
            ShowCT();
            con.Close();
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "DELETE FROM dbo.MotorCategory WHERE name = @name";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@name", txbCategoryName.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "MotorCategory");
            MessageBox.Show("Xoá danh mục thành công!");
            txbCategoryID.Clear();
            txbCategoryName.Clear();
            dtgvCategory.DataSource = ds.Tables["MotorCategory"];
            ShowCT();
            con.Close();
        }

        private void btnAddMotor_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "INSERT INTO dbo.Motor (idCategory, name, info, status, price ) VALUES (@idCategory, @name, @info, @status, @price)";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@idCategory", txbIDCategory.Text);
            com.Parameters.AddWithValue("@name", txbMotorName.Text);
            com.Parameters.AddWithValue("@info", txbMotorInfo.Text);
            com.Parameters.AddWithValue("@status", txbMotorStatus.Text);
            com.Parameters.AddWithValue("@price", txbMotorPrice.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Motor");
            MessageBox.Show("Thêm xe thành công!");
            dtgvMotor.DataSource = ds.Tables["Motor"];
            ShowMotor();
            con.Close();
        }

        private void btnDeleteMotor_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "DELETE FROM dbo.Motor WHERE id = @id";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@id", txbMotorID.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Motor");
            MessageBox.Show("Xoá xe thành công!");
            txbMotorID.Clear();
            txbIDCategory.Clear();
            txbMotorName.Clear();
            txbMotorInfo.Clear();
            txbMotorStatus.Clear();
            txbMotorPrice.Clear();
            dtgvMotor.DataSource = ds.Tables["Motor"];
            ShowMotor();

            con.Close();
        }

        private void btnEditMotor_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "UPDATE dbo.Motor SET idCategory = @idCategory, name = @name, info = @info, status = @status, price = @price where id = @id";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@id", txbMotorID.Text);
            com.Parameters.AddWithValue("@idCategory", txbIDCategory.Text);
            com.Parameters.AddWithValue("@name", txbMotorName.Text);
            com.Parameters.AddWithValue("@info", txbMotorInfo.Text);
            com.Parameters.AddWithValue("@status", txbMotorStatus.Text);
            com.Parameters.AddWithValue("@price", txbMotorPrice.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Motor");
            MessageBox.Show("Sửa thông tin xe thành công!");
            dtgvMotor.DataSource = ds.Tables["Motor"];
            txbMotorID.Clear();
            txbIDCategory.Clear();
            txbMotorName.Clear();
            txbMotorInfo.Clear();
            txbMotorStatus.Clear();
            txbMotorPrice.Clear();
            ShowMotor();
            con.Close();
        }

        private void btnSearchMotor_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Motor WHERE ID LIKE N'" + txbMotorID.Text + "%' AND Name LIKE N'" +
             txbMotorName.Text + "%'";
            dtgvMotor.DataSource = DataProvider.Instance.ExcuteQuery(query);
            txbMotorID.Clear();
            txbIDCategory.Clear();
            txbMotorName.Clear();
            txbMotorInfo.Clear();
            txbMotorStatus.Clear();
            txbMotorPrice.Clear();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "INSERT INTO dbo.Account (UserName, PassWord, DisplayName, Type) VALUES (@UserName, @PassWord, @DisplayName, @Type)";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@UserName", txbUserName.Text);
            com.Parameters.AddWithValue("@PassWord", txbPassWord.Text);
            com.Parameters.AddWithValue("@DisplayName", txbDisplayName.Text);
            com.Parameters.AddWithValue("@Type", rdAdminAcc.Checked);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Account");
            MessageBox.Show("Thêm tài khoản thành công!");
            dtgvAccount.DataSource = ds.Tables["Account"];
            txbUserName.Clear();
            txbPassWord.Clear();
            txbDisplayName.Clear();
            LoadAccountList();
            con.Close();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "DELETE FROM dbo.Account WHERE UserName = @Username";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@UserName", txbUserName.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Account");
            MessageBox.Show("Xoá tài khoản thành công!");
            txbUserName.Clear();
            txbPassWord.Clear();
            txbDisplayName.Clear();
            dtgvAccount.DataSource = ds.Tables["Account"];
            LoadAccountList();
            con.Close();
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "UPDATE dbo.Account SET UserName = @UserName, PassWord = @PassWord, DisplayName = @DisplayName, Type = @Type WHERE UserName = @UserName";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@UserName", txbUserName.Text);
            com.Parameters.AddWithValue("@PassWord", txbPassWord.Text);
            com.Parameters.AddWithValue("@DisplayName", txbDisplayName.Text);
            com.Parameters.AddWithValue("@Type", rdAdminAcc.Checked);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Account");
            MessageBox.Show("Sửa tài khoản thành công!");
            dtgvAccount.DataSource = ds.Tables["Account"];
            txbUserName.Clear();
            txbPassWord.Clear();
            txbDisplayName.Clear();
            LoadAccountList();
            con.Close();
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM dbo.Account WHERE UserName LIKE N'" + txbUserName.Text + "%'";
            dtgvAccount.DataSource = DataProvider.Instance.ExcuteQuery(query);
            txbUserName.Clear();
            txbPassWord.Clear();
            txbDisplayName.Clear();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "UPDATE dbo.Account SET UserName = @UserName, PassWord = @PassWord, DisplayName = @DisplayName, Type = @Type WHERE UserName = @UserName";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@UserName", txbUserName.Text);
            com.Parameters.AddWithValue("@PassWord", txbNewPassWord.Text);
            com.Parameters.AddWithValue("@DisplayName", txbDisplayName.Text);
            com.Parameters.AddWithValue("@Type", rdAdminAcc.Checked);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Account");
            MessageBox.Show("Cập nhật tài khoản thành công!");
            dtgvAccount.DataSource = ds.Tables["Account"];
            txbUserName.Clear();
            txbPassWord.Clear();
            txbNewPassWord.Clear();
            txbDisplayName.Clear();
            LoadAccountList();
            con.Close();
        }
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            string query = "SELECT m.name AS N'Tên sản phẩm', idMotor, DateBuy, m.price FROM dbo.Bill as b, dbo.Motor as m WHERE DateBuy >= '20210101' and b.status = N'Đã thanh toán' and m.id = b.idMotor";
            dtgvBill.DataSource = DataProvider.Instance.ExcuteQuery(query);
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "INSERT INTO dbo.Staff (name, age, office) VALUES (@name, @age, @office)";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@name", txbNameStaff.Text);
            com.Parameters.AddWithValue("@age", txbAgeStaff.Text);
            com.Parameters.AddWithValue("@office", txbOffice.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Staff");
            MessageBox.Show("Thêm nhân viên thành công!");
            dtgvStaff.DataSource = ds.Tables["Staff"];
            ShowStaff();
            con.Close();
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "DELETE FROM dbo.Staff WHERE id = @id AND name = @name";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@id", txbIDStaff.Text);
            com.Parameters.AddWithValue("@name", txbNameStaff.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Staff");
            MessageBox.Show("Xoá nhân viên thành công!");
            txbIDStaff.Clear();
            txbNameStaff.Clear();
            txbAgeStaff.Clear();
            txbOffice.Clear();
            dtgvStaff.DataSource = ds.Tables["Staff"];
            ShowStaff();
            con.Close();
        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "UPDATE dbo.Staff SET name = @name, age = @age, office = @office WHERE id = @id";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@id", txbIDStaff.Text);
            com.Parameters.AddWithValue("@name", txbNameStaff.Text);
            com.Parameters.AddWithValue("@age", txbAgeStaff.Text);
            com.Parameters.AddWithValue("@office", txbOffice.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Staff");
            MessageBox.Show("Sửa nhân viên thành công!");
            dtgvStaff.DataSource = ds.Tables["Staff"];
            ShowStaff();
            con.Close();
        }

        private void btnShowStaff_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM dbo.Staff WHERE ID LIKE N'" + txbIDStaff.Text + "%' AND Name LIKE N'" +
             txbNameStaff.Text + "%'";
            dtgvStaff.DataSource = DataProvider.Instance.ExcuteQuery(query);
            txbIDStaff.Clear();
            txbNameStaff.Clear();
            txbAgeStaff.Clear();
            txbOffice.Clear();
        }

        private void export2Excel(DataGridView g, string duongDan, string tenTap)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count - 1; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }
        private void btn_XuatDS_Click(object sender, EventArgs e)
        {
            export2Excel(dtgvBill, @"D:\", "Webthucung");
        }
    }
}
