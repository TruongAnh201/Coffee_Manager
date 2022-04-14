namespace QuanLyCafe.Presentation
{
    partial class fr_Ketnoi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fr_Ketnoi));
            this.txtdb = new System.Windows.Forms.TextBox();
            this.cmdthoat = new System.Windows.Forms.Button();
            this.cmddn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtserver = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Sreach_SV_Name_BTN = new System.Windows.Forms.Button();
            this.ddlPublisherServer = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtdb
            // 
            this.txtdb.Enabled = false;
            this.txtdb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.txtdb.Location = new System.Drawing.Point(130, 102);
            this.txtdb.Name = "txtdb";
            this.txtdb.Size = new System.Drawing.Size(214, 26);
            this.txtdb.TabIndex = 76;
            this.txtdb.Text = "QL_Quancaphe";
            // 
            // cmdthoat
            // 
            this.cmdthoat.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmdthoat.FlatAppearance.BorderSize = 0;
            this.cmdthoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdthoat.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdthoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.cmdthoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdthoat.Location = new System.Drawing.Point(219, 156);
            this.cmdthoat.Name = "cmdthoat";
            this.cmdthoat.Size = new System.Drawing.Size(125, 35);
            this.cmdthoat.TabIndex = 80;
            this.cmdthoat.Text = "Thoát";
            this.cmdthoat.UseVisualStyleBackColor = false;
            this.cmdthoat.Click += new System.EventHandler(this.cmdthoat_Click);
            // 
            // cmddn
            // 
            this.cmddn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cmddn.FlatAppearance.BorderSize = 0;
            this.cmddn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmddn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmddn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.cmddn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmddn.Location = new System.Drawing.Point(38, 156);
            this.cmddn.Name = "cmddn";
            this.cmddn.Size = new System.Drawing.Size(125, 35);
            this.cmddn.TabIndex = 79;
            this.cmddn.Text = "Thiết Lập";
            this.cmddn.UseVisualStyleBackColor = false;
            this.cmddn.Click += new System.EventHandler(this.cmddn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(7, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 78;
            this.label2.Text = "Tên Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.label3.Location = new System.Drawing.Point(7, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 77;
            this.label3.Text = "Tên CSDL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 31);
            this.label1.TabIndex = 50;
            this.label1.Text = "THIÊT LẬP KẾT NỐI SERVER";
            // 
            // txtserver
            // 
            this.txtserver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.txtserver.Location = new System.Drawing.Point(130, 65);
            this.txtserver.Name = "txtserver";
            this.txtserver.Size = new System.Drawing.Size(214, 26);
            this.txtserver.TabIndex = 75;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(239)))), ((int)(((byte)(191)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 48);
            this.panel1.TabIndex = 74;
            // 
            // Sreach_SV_Name_BTN
            // 
            this.Sreach_SV_Name_BTN.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Sreach_SV_Name_BTN.FlatAppearance.BorderSize = 0;
            this.Sreach_SV_Name_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sreach_SV_Name_BTN.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sreach_SV_Name_BTN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.Sreach_SV_Name_BTN.Location = new System.Drawing.Point(530, 63);
            this.Sreach_SV_Name_BTN.Name = "Sreach_SV_Name_BTN";
            this.Sreach_SV_Name_BTN.Size = new System.Drawing.Size(83, 31);
            this.Sreach_SV_Name_BTN.TabIndex = 82;
            this.Sreach_SV_Name_BTN.Text = "Tìm kiếm";
            this.Sreach_SV_Name_BTN.UseVisualStyleBackColor = false;
            this.Sreach_SV_Name_BTN.Click += new System.EventHandler(this.Sreach_SV_Name_BTN_Click);
            // 
            // ddlPublisherServer
            // 
            this.ddlPublisherServer.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlPublisherServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.ddlPublisherServer.FormattingEnabled = true;
            this.ddlPublisherServer.ItemHeight = 18;
            this.ddlPublisherServer.Location = new System.Drawing.Point(372, 100);
            this.ddlPublisherServer.Name = "ddlPublisherServer";
            this.ddlPublisherServer.Size = new System.Drawing.Size(241, 76);
            this.ddlPublisherServer.TabIndex = 83;
            this.ddlPublisherServer.SelectedIndexChanged += new System.EventHandler(this.ddlPublisherServer_SelectedIndexChanged);
            // 
            // fr_Ketnoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(239)))), ((int)(((byte)(191)))));
            this.ClientSize = new System.Drawing.Size(618, 201);
            this.Controls.Add(this.ddlPublisherServer);
            this.Controls.Add(this.Sreach_SV_Name_BTN);
            this.Controls.Add(this.txtdb);
            this.Controls.Add(this.cmdthoat);
            this.Controls.Add(this.cmddn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtserver);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fr_Ketnoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết Nối";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fr_Ketnoi_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtdb;
        private System.Windows.Forms.Button cmdthoat;
        private System.Windows.Forms.Button cmddn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtserver;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Sreach_SV_Name_BTN;
        private System.Windows.Forms.ListBox ddlPublisherServer;
    }
}