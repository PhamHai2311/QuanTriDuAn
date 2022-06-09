using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyMotor.DTO;

namespace QuanLyMotor.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set {BillDAO.instance = value; }
        }

        //Thành công: bill ID
        //Thất bại: -1
        private BillDAO() { }
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Bill WHERE idMotor = " + id + "  AND status = N'Chưa thanh toán'");
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }

        public void CheckOut(int id)
        {
            DataProvider.Instance.ExcuteQuery("update dbo.Bill set DateBuy = GETDATE(), status = N'Đã thanh toán'  where idMotor = " + id);
        }

    }
}
