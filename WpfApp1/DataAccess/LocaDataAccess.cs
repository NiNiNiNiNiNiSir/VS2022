using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DataAccess
{
    internal class LocaDataAccess
    {
        private static LocaDataAccess instance; //静态私有实例
        private LocaDataAccess() { }  //构造函数
        public static LocaDataAccess GetInstace()
        {
            //?? 如果为空
            return instance ?? (instance = new LocaDataAccess());

        }

        SqlConnection conn;
        SqlCommand comm;
        SqlDataAdapter adapter;//数据填充

        private void Dispose()
        {
            if(adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if(comm != null)
            {
                comm.Dispose();
                comm = null;
            }
            if(conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        private bool DBConnection()
        {
            if(conn == null)
            {
                conn = new SqlConnection("");
            }
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }           
        }

    }
}
