using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyMotor.DAO;
using QuanLyMotor.DTO;
using System.Data.SqlClient;


namespace QuanLyMotor
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
            LoadMotor();
        }

        

        #region Method
        
        void LoadMotor()//tạo vòng lặp các hình btn
        {
            List<Motor> tableList = MotorDAO.Instance.LoadMotorList();
            foreach(Motor item in tableList)
            {
                Button btn = new Button() { Width = MotorDAO.MotorWidth, Height = MotorDAO.MotorHeight };
                btn.Text = item.Name + Environment.NewLine + item.Info;
                btn.Click += Btn_Click;
                btn.Tag = item;

                switch(item.Status)
                {
                    case "Hết hàng":
                        btn.BackColor = Color.Red;
                        break;
                    default:
                        btn.BackColor = Color.LightGreen;
                        break;
                }
                flListMotor.Controls.Add(btn);
            }    
        }

        void ShowBill(int id)
        {
            listViewBill.Items.Clear();
            List<QuanLyMotor.DTO.Menu> listBill = MenuDAO.Instance.GetListMenuByTable(id);
            int totalPrice = 0;
            foreach (QuanLyMotor.DTO.Menu item in listBill)
            {

                ListViewItem lsvItem = new ListViewItem(item.MotorName.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.Status.ToString());
                totalPrice = item.Price;
                listViewBill.Items.Add(lsvItem);
            }

            txbTotalPrice.Text = totalPrice.ToString("0#,0.# VNÐ");
        }
        #endregion

        #region Events
        void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Motor).ID;
            listViewBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đăng xuất thành công!");
            this.Close();
        }

        

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckAdmin openF = new CheckAdmin();
            openF.ShowDialog();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
                Motor motor = listViewBill.Tag as Motor;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(motor.ID);

            if (idBill != -1)
            {
                if (MessageBox.Show("Xác nhận thanh toán hoá đơn cho sản phẩm" + " " + motor.Name + "?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill);
                    ShowBill(motor.ID);
                    listViewBill.Items.Clear();
                }
            }
        }

        #endregion



        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff openS = new Staff();
            openS.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
