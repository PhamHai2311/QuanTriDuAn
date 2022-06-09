using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyMotor.DAO;

namespace QuanLyMotor.DTO
{
    public class Motor
    {
        public Motor(int id, string name, string status, string info)
        {
            this.ID = id;
            this.Name = name;
            this.Status = status;
            this.Info = info;
        }
        public Motor(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();
            this.Info = row["info"].ToString();
        }

        private string status;
        private string name;
        private int iD;
        private string info;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Info
        {
            get { return info; }
            set { info = value; }
        }
    }
}
