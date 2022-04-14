using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyCafe.Business.EntitiesClass;

namespace QuanLyCafe.DataAccess
{
    class SQL_tb_User
    {
        ConnectDB cn = new ConnectDB();

        public bool Kiemtrauser(EC_tb_User user)
        {
            string sql = "select count(*) from tb_User where Username ='" + user.USERNAME + "' and Password = '" + user.PASSWORD + "'";
            return cn.KiemtraUsername(sql);
        }
        public void Taouser(EC_tb_User user)
        {
            cn.ExcuteNonQuery(@"INSERT INTO tb_User
                      (Username, Password, Type) VALUES   (N'" + user.USERNAME + "',N'" + user.PASSWORD + "',N'" + user.PERMISSION+ "')");
        }

        public bool Kiemtralogin(EC_tb_User user)
        {
            string sql = "select count(*) from tb_User where Username ='" + user.USERNAME + "'";
            return cn.KiemtraUsername(sql);
        }

        public String GetType(EC_tb_User user)
        {
            string sql = "select Type from tb_User where Username ='" + user.USERNAME + "'";
            return cn.GetType(sql);
        }
    }
}
