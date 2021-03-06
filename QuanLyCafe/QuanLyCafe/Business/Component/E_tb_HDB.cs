using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyCafe.Business.EntitiesClass;
using QuanLyCafe.DataAccess;
using System.Windows.Forms;

namespace QuanLyCafe.Business.Component
{
    class E_tb_HDB
    {
        SQL_tb_HDB hdbsql = new SQL_tb_HDB();
        public void themoihdb(EC_tb_HDB hdb)
        {
            if (!hdbsql.kiemtraHDB(hdb.MAHDB))
            {
                hdbsql.themmoiHDB(hdb);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void suahdb(EC_tb_HDB hdb)
        {
            hdbsql.suaHDB(hdb);
        }
        public void xoahdb(EC_tb_HDB hdb)
        {
            hdbsql.xoaHDB(hdb);
        }
        //load nv
        public void loadmanv(ComboBox cbnv)
        {
            hdbsql.loadmanv(cbnv);
        }
        //load khách
        public void loadmakh(ComboBox cbkh)
        {
            hdbsql.loadmakhach(cbkh);
        }
    }
}
