using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLyMotor.DTO;
using QuanLyMotor.DAO;

namespace QuanLyMotor.DAO
{
    public class MotorDAO
    {
        private static MotorDAO instance;

        public static MotorDAO Instance
        {
            get { if (instance == null) instance = new MotorDAO(); return MotorDAO.instance; }
            private set { MotorDAO.instance = value; }
        }

        public static int MotorWidth = 500;
        public static int MotorHeight = 80;

        private MotorDAO() { }

        public List<Motor> LoadMotorList()
        {
            List<Motor> tableList = new List<Motor>();
            DataTable data = DataProvider.Instance.ExcuteQuery("USP_GetMotorList");
            
            foreach(DataRow item in data.Rows)
            {
                Motor table = new Motor(item);
                tableList.Add(table);
            }
            return tableList;
        }
    }
}

