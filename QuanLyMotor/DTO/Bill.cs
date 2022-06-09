using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyMotor.DTO
{
    public class Bill
    {
        public Bill (int id, DateTime? dateBuy, string status)
        {
            this.ID = id;
            this.DateBuy = dateBuy;
            this.Status = status;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateBuy = (DateTime?)row["dateBuy"];
            this.Status = row["status"].ToString();
        }
        private string status;
        private DateTime? dateBuy;
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime? DateBuy
        {
            get { return dateBuy; }
            set { dateBuy = value; }
        }
    }
}
