using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyMotor.DTO
{
    public class Account
    {
        public Account(string userName, string displayName, int type, string passWord = null)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.Type = type;
            this.PassWord = passWord;
        }
        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.DisplayName = row["displayName"].ToString();
            this.Type = (int)row["type"];
            this.PassWord = row["passWord"].ToString();
        }

        private int Type;
        private string PassWord;
        private string DisplayName;
        private string UserName;
        public string userName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string displayName
        {
            get { return displayName; }
            set { displayName = value; }
        }
        public int type
        {
            get { return type; }
            set { type = value; }
        }
        public string passWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
    }
}
