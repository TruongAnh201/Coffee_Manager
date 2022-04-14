using QuanLyCafe.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCafe.Presentation
{
    public partial class fr_TKHDN : Form
    {
        public fr_TKHDN()
        {
            InitializeComponent();
        }

        ConnectDB cn = new ConnectDB();
        public void khoitaoluoi()
        {
            try
            {
                msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                msds.Columns[0].HeaderText = "Số HDB";
                msds.Columns[0].Frozen = true;
                msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                msds.Columns[0].Width = 100;
                msds.Columns[1].HeaderText = "Ngày Nhập";
                msds.Columns[1].Width = 100;
                msds.Columns[2].HeaderText = "Nhân Viên";
                msds.Columns[2].Width = 200;
                msds.Columns[3].HeaderText = "Nhà Cung Cấp";
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
                string sql = @"SELECT mahdn, ngaynhap, tennv, tenncc, tongtien FROM tb_HDN 
                            inner join tb_Nhanvien on tb_Nhanvien.manv = tb_HDN.manv
                            inner join tb_NCC on tb_NCC.mancc = tb_HDN.mancc";
                msds.DataSource = cn.taobang(sql);
                SqlConnection con = cn.getcon();
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void fr_TKHDN_Load(object sender, EventArgs e)
        {
            hienthi();
            khoitaoluoi();
        }

        private void reload()
        {
            if (txtthongtin.Text.Length == 0)
            {
                hienthi();
            }
            else
            {
                if (op1.Checked)
                {
                    string sql = @"SELECT DISTINCT tb_HDN.mahdn, tb_HDN.ngaynhap, tennv, tenncc, tb_HDN.tongtien 
                                FROM tb_HDN 
                                INNER JOIN tb_Nhanvien on tb_Nhanvien.manv = tb_HDN.manv
                                INNER JOIN tb_NCC on tb_NCC.mancc = tb_HDN.mancc
                                INNER JOIN tb_CTHDN ON tb_HDN.mahdn = tb_CTHDN.mahdn                                
                                INNER JOIN tb_sanpham ON tb_sanpham.masp = tb_CTHDN.masp
                                WHERE tensp like N'%" + txtthongtin.Text + "%'";
                    msds.DataSource = cn.taobang(sql);
                    SqlConnection con = cn.getcon();
                    con.Open();
                }
                if (op2.Checked)
                {
                    string sql = @"SELECT DISTINCT tb_HDN.mahdn, tb_HDN.ngaynhap, tennv, tenncc, tb_HDN.tongtien 
                                FROM tb_HDN 
                                INNER JOIN tb_Nhanvien on tb_Nhanvien.manv = tb_HDN.manv
                                INNER JOIN tb_NCC on tb_NCC.mancc = tb_HDN.mancc
                                INNER JOIN tb_CTHDN ON tb_HDN.mahdn = tb_CTHDN.mahdn 
                                WHERE tb_HDN.ngaynhap = '" + txtthongtin.Text + "'";
                    msds.DataSource = cn.taobang(sql);
                    SqlConnection con = cn.getcon();
                    con.Open();
                }
                if (op3.Checked)
                {
                    string sql = @"SELECT DISTINCT tb_HDN.mahdn, tb_HDN.ngaynhap, tennv, tenncc, tb_HDN.tongtien 
                                FROM tb_HDN 
                                INNER JOIN tb_Nhanvien on tb_Nhanvien.manv = tb_HDN.manv
                                INNER JOIN tb_NCC on tb_NCC.mancc = tb_HDN.mancc
                                INNER JOIN tb_CTHDN ON tb_HDN.mahdn = tb_CTHDN.mahdn 
                                WHERE tenncc like N'%" + txtthongtin.Text + "%'";
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

        private void msds_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                fr_CTHDN fr = new fr_CTHDN();
                fr.SOHDN = msds.Rows[e.RowIndex].Cells[0].Value.ToString();
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
