﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyCafe.Business.Component;
using QuanLyCafe.Business.EntitiesClass;
using QuanLyCafe.DataAccess;

namespace QuanLyCafe.Presentation
{
    public partial class fr_HDB : Form
    {
        public fr_HDB()
        {
            InitializeComponent();
        }
        E_tb_HDB thucthi = new E_tb_HDB();
        ConnectDB cn = new ConnectDB();
        EC_tb_HDB ck = new EC_tb_HDB();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txtma.Text = "";
            txtngay.Text = DateTime.Now.ToShortTimeString();
            cbncc.Text = "";
            cbnv.Text = "";
            txttt.Text = "0";
        }
        public void locktext()
        {
            txtma.Enabled = false;
            txtngay.Enabled = false;
            cbncc.Enabled = false;
            cbnv.Enabled = false;

            btmoi.Enabled = true;
            btluu.Enabled = false;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtma.Enabled = true;
            txtngay.Enabled = true;
            cbncc.Enabled = true;
            cbnv.Enabled = true;

            btmoi.Enabled = false;
            btluu.Enabled = true;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
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
        public void hienthi()
        {
            string sql = @"SELECT mahdb,  ngayban, tennv, tenkh, tongtien 
                        FROM tb_HDB
                        inner join tb_Nhanvien on tb_Nhanvien.manv = tb_HDB.manv
                        inner join tb_KhachHang on tb_KhachHang.makh = tb_HDB.makh";
            msds.DataSource = cn.taobang(sql);
            SqlConnection con = cn.getcon();
            con.Open();
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }
        private void btmoi_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txtma.Enabled = true;
            txtma.Focus();
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtma.Text != "")
            {
                if (cbnv.SelectedValue.ToString() != "")
                {
                    if (cbncc.SelectedValue.ToString() != "")
                    {
                        if (themmoi == true)
                        {
                            try
                            {
                                ck.MAHDB = txtma.Text;
                                ck.MANV = cbnv.SelectedValue.ToString();
                                ck.NGAYBAN = txtngay.Text;
                                ck.MAKH = cbncc.SelectedValue.ToString();
                                ck.TONGTIEN = txttt.Text;

                                thucthi.themoihdb(ck);
                                locktext();
                                hienthi();
                                MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                fr_CTHDB fr = new fr_CTHDB();
                                fr.SOHDB = txtma.Text;
                                fr.MdiParent = this.MdiParent;
                                this.Close();
                                fr.Show();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            try
                            {
                                ck.MAHDB = txtma.Text;
                                ck.MANV = cbnv.SelectedValue.ToString();
                                ck.NGAYBAN = txtngay.Text;
                                ck.MAKH = cbncc.SelectedValue.ToString();
                                ck.TONGTIEN = txttt.Text;

                                thucthi.suahdb(ck);
                                MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                fr_CTHDB fr = new fr_CTHDB();
                                fr.SOHDB = txtma.Text;
                                fr.MdiParent = this.MdiParent;
                                this.Close();
                                fr.Show();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        txtma.Enabled = true;
                        locktext();
                        hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbncc.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    cbnv.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtma.Focus();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtma.Enabled = false;
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MAHDB = txtma.Text;

                    thucthi.xoahdb(ck);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }
        private void msds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            if (dong != -1)
            {
                txtma.Text = msds.Rows[dong].Cells[0].Value.ToString();
                txtngay.Text = msds.Rows[dong].Cells[1].Value.ToString();
                cbnv.Text = msds.Rows[dong].Cells[2].Value.ToString();
                cbncc.Text = msds.Rows[dong].Cells[3].Value.ToString();
                txttt.Text = msds.Rows[dong].Cells[4].Value.ToString();
                locktext();
            }
        }

        private void fr_HDB_Load(object sender, EventArgs e)
        {
            thucthi.loadmakh(cbncc);
            thucthi.loadmanv(cbnv);
            hienthi();
            khoitaoluoi();
            locktext();
        }


        private void msds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            if (dong != -1) {
                fr_CTHDB fr = new fr_CTHDB();
                fr.SOHDB = msds.Rows[dong].Cells[0].Value.ToString();
                fr.MdiParent = this.MdiParent;
                this.Close();
                fr.Show();
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thucthi.loadmakh(cbncc);
            thucthi.loadmanv(cbnv);
        }
    }
}
