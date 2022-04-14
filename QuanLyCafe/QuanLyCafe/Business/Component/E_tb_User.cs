using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyCafe.Business.EntitiesClass;
using QuanLyCafe.DataAccess;
using System.Windows.Forms;

namespace QuanLyCafe.Business.Component
{
    class E_tb_User
    {
        EC_tb_User ck = new EC_tb_User();
        SQL_tb_User sql = new SQL_tb_User();
        public bool kiemtrauser(string user, string pass)
        {
            ck.USERNAME = user;
            ck.PASSWORD = pass;
            return sql.Kiemtrauser(ck);
        }

        public void taouser(string user, string pass, string permission)
        {
            ck.USERNAME = user;
            ck.PASSWORD = pass;
            ck.PERMISSION = permission;
            sql.Taouser(ck);
        }

        public bool kiemtralogin(string user)
        {
            ck.USERNAME = user;
            return sql.Kiemtralogin(ck);
        }

        public string getType(string user)
        {
            ck.USERNAME = user;
            return sql.GetType(ck);
        }
    }
}
