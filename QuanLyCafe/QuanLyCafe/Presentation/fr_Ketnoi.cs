using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using QuanLyCafe.DataAccess;
using System.Data.Sql;
using Microsoft.Win32;

namespace QuanLyCafe.Presentation
{
    public partial class fr_Ketnoi : Form
    {
        public fr_Ketnoi()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();

        private void cmddn_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("Sinfo"))
                {
                    File.Delete("Sinfo");
                    StreamWriter write = new StreamWriter("Sinfo");
                    write.WriteLine("SV=:" + txtserver.Text);
                    write.WriteLine("DB=:" + txtdb.Text);
                    write.Close();
                    MessageBox.Show("Đã Thiết Lập xong", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    StreamWriter write = new StreamWriter("Sinfo");
                    write.WriteLine("SV=:" + txtserver.Text);
                    write.Close();
                    MessageBox.Show("Đã Thiết Lập xong", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Question);

                }

                MessageBox.Show("Kết Nối Thành Công Tới Sever " + txtserver.Text + ". Bạn sẽ phải khởi động lại chương trình đối với lần kết nối đầu tiên", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Không thiết lập được", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmdthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GetDataSources()
        {
            string ServerName = Environment.MachineName;
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        ddlPublisherServer.Items.Add(ServerName);
                    }
                }
            }
        }

        private void ddlPublisherServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = ddlPublisherServer.SelectedItem.ToString();
            txtserver.Text = curItem;
        }

        private void Sreach_SV_Name_BTN_Click(object sender, EventArgs e)
        {
            GetDataSources();
        }

        private void fr_Ketnoi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
