using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyMotor.DTO
{
    public class Menu
    {
        public Menu(string motorName, int price, string status)
        {
            this.Price = price;
            this.MotorName = motorName;
            this.Status = status;
        }

        public Menu(DataRow row)
        {
            this.Price = (int)Convert.ToDouble(row["price"].ToString());
            this.MotorName = row["name"].ToString();
            this.Status = row["status"].ToString();
        }

        private int price;
        private string motorName;
        private string status;

        public int Price
        {
            get { return price; }
            set { price = value;  }
        }

        public string MotorName
        {
            get { return motorName; }
            set { motorName = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
