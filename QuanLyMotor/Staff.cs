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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
            ShowMotor();
            ShowCustomer();
            AddMotorBinding();
            AddCustomerBinding();
        }

        void ShowMotor()
        {
            dtgvMotor.DataSource = DataProvider.Instance.ExcuteQuery("SELECT * FROM Motor");
        }

        void ShowCustomer()
        {
            dtgCustomer.DataSource = DataProvider.Instance.ExcuteQuery("SELECT * FROM Customer");
        }

        void AddMotorBinding()
        {
            txbMotorID.DataBindings.Add(new Binding("Text", dtgvMotor.DataSource, "ID"));
            txbIDCategory.DataBindings.Add(new Binding("Text", dtgvMotor.DataSource, "IDCategory"));
            txbMotorName.DataBindings.Add(new Binding("Text", dtgvMotor.DataSource, "Name"));
            txbMotorInfo.DataBindings.Add(new Binding("Text", dtgvMotor.DataSource, "Info"));
            txbMotorPrice.DataBindings.Add(new Binding("Text", dtgvMotor.DataSource, "Price"));
            txbStatus.DataBindings.Add(new Binding("Text", dtgvMotor.DataSource, "Status"));
        }

        void AddCustomerBinding()
        {
            txbIDCustomer.DataBindings.Add(new Binding("Text", dtgCustomer.DataSource, "ID"));
            txbNameCustomer.DataBindings.Add(new Binding("Text", dtgCustomer.DataSource, "Name"));
            txbPhone.DataBindings.Add(new Binding("Text", dtgCustomer.DataSource, "Phone"));
            txbAddress.DataBindings.Add(new Binding("Text", dtgCustomer.DataSource, "Address"));
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
            com.Parameters.AddWithValue("@status", txbStatus.Text);
            com.Parameters.AddWithValue("@price", txbMotorPrice.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Motor");
            MessageBox.Show("Thêm xe thành công!");
            dtgvMotor.DataSource = ds.Tables["Motor"];
            ShowMotor();
            con.Close();
        }

        private void btnDeleteMotor_Click_1(object sender, EventArgs e)
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
            txbStatus.Clear();
            txbMotorPrice.Clear();
            dtgvMotor.DataSource = ds.Tables["Motor"];
            ShowMotor();
            con.Close();
        }

        private void btnEditMotor_Click_1(object sender, EventArgs e)
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
            com.Parameters.AddWithValue("@status", txbStatus.Text);
            com.Parameters.AddWithValue("@price", txbMotorPrice.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Motor");
            MessageBox.Show("Sửa xe thành công!");
            dtgvMotor.DataSource = ds.Tables["Motor"];
            txbMotorID.Clear();
            txbIDCategory.Clear();
            txbMotorName.Clear();
            txbMotorInfo.Clear();
            txbStatus.Clear();
            txbMotorPrice.Clear();
            ShowMotor();
            con.Close();
        }

        private void btnSearchMotor_Click_1(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Motor WHERE ID LIKE N'" + txbMotorID.Text + "%' AND Name LIKE N'" +
             txbMotorName.Text + "%'";
            dtgvMotor.DataSource = DataProvider.Instance.ExcuteQuery(query);
            txbMotorID.Clear();
            txbIDCategory.Clear();
            txbMotorName.Clear();
            txbMotorInfo.Clear();
            txbStatus.Clear();
            txbMotorPrice.Clear();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "INSERT INTO dbo.Customer (name, phone, address) VALUES (@name, @phone, @address)";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@name", txbNameCustomer.Text);
            com.Parameters.AddWithValue("@phone", txbPhone.Text);
            com.Parameters.AddWithValue("@address", txbAddress.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Customer");
            MessageBox.Show("Thêm khách hàng thành công!");
            dtgCustomer.DataSource = ds.Tables["Customer"];
            ShowCustomer();
            con.Close();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "DELETE FROM dbo.Customer WHERE id = @id AND name = @name";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@id", txbIDCustomer.Text);
            com.Parameters.AddWithValue("@name", txbNameCustomer.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Customer");
            MessageBox.Show("Xoá khách hàng thành công!");
            txbIDCustomer.Clear();
            txbNameCustomer.Clear();
            txbPhone.Clear();
            txbAddress.Clear();
            dtgCustomer.DataSource = ds.Tables["Customer"];
            ShowCustomer();
            con.Close();
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            string constr = @"Data Source=PC\SQLEXPRESS;Initial Catalog=QuanLyMoto;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            string query = "UPDATE dbo.Customer SET name = @name, phone = @phone, address = @address WHERE id = @id";
            SqlCommand com = new SqlCommand(query, con);
            con.Open();
            com.Parameters.AddWithValue("@id", txbIDCustomer.Text);
            com.Parameters.AddWithValue("@name", txbNameCustomer.Text);
            com.Parameters.AddWithValue("@phone", txbPhone.Text);
            com.Parameters.AddWithValue("@address", txbAddress.Text);
            SqlDataAdapter apt = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            apt.Fill(ds, "Customer");
            MessageBox.Show("Sửa khách hàng thành công!");
            dtgCustomer.DataSource = ds.Tables["Customer"];
            ShowCustomer();
            con.Close();
        }

        private void btnShowCustomer_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM dbo.Customer WHERE ID LIKE N'" + txbIDCustomer.Text + "%' AND Name LIKE N'" +
             txbNameCustomer.Text + "%'";
            dtgCustomer.DataSource = DataProvider.Instance.ExcuteQuery(query);
            txbIDCustomer.Clear();
            txbNameCustomer.Clear();
            txbPhone.Clear();
            txbAddress.Clear();
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            string query = "SELECT m.name, idMotor, DateBuy, m.price FROM dbo.Bill as b, dbo.Motor as m WHERE DateBuy >= '20210101' and b.status = N'Đã thanh toán' and m.id = b.idMotor";
            dtgvBill.DataSource = DataProvider.Instance.ExcuteQuery(query);
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

        private void btn_XuatDS_Click_1(object sender, EventArgs e)
        {
            export2Excel(dtgvBill, @"D:\", "Webthucung");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

