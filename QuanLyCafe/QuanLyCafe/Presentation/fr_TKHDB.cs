using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLyCafe.DataAccess;
using System.Data.SqlClient;

namespace QuanLyCafe.Presentation
{
    public partial class fr_TKHDB : Form
    {
        public fr_TKHDB()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        public void khoitaoluoi()
        {
            try { 
                msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                msds.Columns[0].HeaderText = "Số HDB";
                msds.Columns[0].Frozen = true;
                msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                msds.Columns[0].Width = 100;
                msds.Columns[1].HeaderText = "Ngày Bán";
                msds.Columns[1].Width = 100;
                msds.Columns[2].HeaderText = "Nhân Viên";
                msds.Columns[2].Width = 200;
                msds.Columns[3].HeaderText = "Khách Hàng";
                msds.Columns[3].Width = 100;
                msds.Columns[4].HeaderText = "Tổng Tiền";
                msds.Columns[4].Width = 100;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void hienthi()
        {          
            try
            {
                string sql = @"SELECT DISTINCT mahdb, ngayban, tennv, tenkh,tongtien FROM tb_HDB 
                                inner join tb_Nhanvien on tb_Nhanvien.manv = tb_HDB.manv
                                inner join tb_Khachhang on tb_Khachhang.makh = tb_HDB.makh";
                msds.DataSource = cn.taobang(sql);
                SqlConnection con = cn.getcon();
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void reload() {
            if (txtthongtin.Text.Length == 0)
            {
                hienthi();
            }
            else
            {
                if (op1.Checked)
                {
                    string sql = @"SELECT DISTINCT tb_HDB.mahdb, ngayban, tennv, tenkh,tongtien 
                                FROM tb_HDB
                                INNER JOIN tb_Nhanvien on tb_Nhanvien.manv = tb_HDB.manv
                                INNER JOIN tb_Khachhang on tb_Khachhang.makh = tb_HDB.makh          
                                INNER JOIN tb_CTHDB ON tb_HDB.mahdb = tb_CTHDB.mahdb 
                                INNER JOIN tb_sanpham ON tb_sanpham.masp = tb_CTHDB.masp 
                                WHERE tensp like N'%" + txtthongtin.Text + "%'";
                    msds.DataSource = cn.taobang(sql);
                    SqlConnection con = cn.getcon();
                    con.Open();
                }
                if (op2.Checked)
                {
                    string sql = @"SELECT DISTINCT mahdb, ngayban, tennv, tenkh,tongtien
                                FROM tb_HDB
                                INNER JOIN tb_Nhanvien on tb_Nhanvien.manv = tb_HDB.manv
                                INNER JOIN tb_Khachhang on tb_Khachhang.makh = tb_HDB.makh         
                                WHERE tb_HDB.ngayban = '" + txtthongtin.Text + "'";
                    msds.DataSource = cn.taobang(sql);
                    SqlConnection con = cn.getcon();
                    con.Open();
                }
                if (op3.Checked)
                {
                    string sql = @"SELECT DISTINCT tb_HDB.mahdb, tb_HDB.ngayban, tennv, tenkh, tb_HDB.tongtien 
                                FROM tb_HDB 
                                INNER JOIN tb_Nhanvien on tb_Nhanvien.manv = tb_HDB.manv
                                INNER JOIN tb_Khachhang on tb_Khachhang.makh = tb_HDB.makh   
                                INNER JOIN tb_CTHDB ON tb_HDB.mahdb = tb_CTHDB.mahdb 
                                WHERE tenkh like N'%" + txtthongtin.Text + "%'";
                    msds.DataSource = cn.taobang(sql);
                    SqlConnection con = cn.getcon();
                    con.Open();
                }
            }
            khoitaoluoi();
        }

        private void txtthongtin_TextChanged(object sender, EventArgs e)
        {
            reload();
        }

        private void fr_TKHDB_Load(object sender, EventArgs e)
        {
            hienthi();
            khoitaoluoi();
        }

        private void msds_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                fr_CTHDB fr = new fr_CTHDB();
                fr.SOHDB = msds.Rows[e.RowIndex].Cells[0].Value.ToString();
                fr.MdiParent = this.MdiParent;
                this.Close();
                fr.Show();
            }
        }

        private void op1_CheckedChanged(object sender, EventArgs e)
        {
            reload();
        }

        private void op2_CheckedChanged(object sender, EventArgs e)
        {
            reload();
        }

        private void op3_CheckedChanged(object sender, EventArgs e)
        {
            reload();
        }
    }
}
