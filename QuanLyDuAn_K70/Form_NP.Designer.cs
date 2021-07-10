﻿
namespace QuanLyDuAn_K70
{
    partial class Form_NP
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
            this.dataGridView_NhapPhi = new System.Windows.Forms.DataGridView();
            this.MaDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiPhi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btthem = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.tbTimKiem = new System.Windows.Forms.TextBox();
            this.btTimKiem = new System.Windows.Forms.Button();
            this.btXem = new System.Windows.Forms.Button();
            this.btDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NhapPhi)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_NhapPhi
            // 
            this.dataGridView_NhapPhi.AllowUserToAddRows = false;
            this.dataGridView_NhapPhi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_NhapPhi.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_NhapPhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_NhapPhi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDA,
            this.TenDA,
            this.MaPhi,
            this.TenPhi,
            this.ChiPhi});
            this.dataGridView_NhapPhi.Location = new System.Drawing.Point(60, 98);
            this.dataGridView_NhapPhi.Name = "dataGridView_NhapPhi";
            this.dataGridView_NhapPhi.ReadOnly = true;
            this.dataGridView_NhapPhi.Size = new System.Drawing.Size(652, 213);
            this.dataGridView_NhapPhi.TabIndex = 0;
            this.dataGridView_NhapPhi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_NhapPhi_CellClick);
            // 
            // MaDA
            // 
            this.MaDA.DataPropertyName = "MaDA";
            this.MaDA.HeaderText = "Mã dự án";
            this.MaDA.Name = "MaDA";
            this.MaDA.ReadOnly = true;
            // 
            // TenDA
            // 
            this.TenDA.DataPropertyName = "TenDA";
            this.TenDA.HeaderText = "Tên dự án";
            this.TenDA.Name = "TenDA";
            this.TenDA.ReadOnly = true;
            this.TenDA.Visible = false;
            // 
            // MaPhi
            // 
            this.MaPhi.DataPropertyName = "MaPhi";
            this.MaPhi.HeaderText = "Mã phí";
            this.MaPhi.Name = "MaPhi";
            this.MaPhi.ReadOnly = true;
            // 
            // TenPhi
            // 
            this.TenPhi.DataPropertyName = "TenPhi";
            this.TenPhi.HeaderText = "Tên Phí";
            this.TenPhi.Name = "TenPhi";
            this.TenPhi.ReadOnly = true;
            this.TenPhi.Visible = false;
            // 
            // ChiPhi
            // 
            this.ChiPhi.DataPropertyName = "ChiPhi";
            this.ChiPhi.HeaderText = "Chi Phí";
            this.ChiPhi.Name = "ChiPhi";
            this.ChiPhi.ReadOnly = true;
            // 
            // btthem
            // 
            this.btthem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btthem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btthem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btthem.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btthem.Location = new System.Drawing.Point(80, 352);
            this.btthem.Name = "btthem";
            this.btthem.Size = new System.Drawing.Size(75, 23);
            this.btthem.TabIndex = 1;
            this.btthem.Text = "Thêm";
            this.btthem.UseVisualStyleBackColor = false;
            this.btthem.Click += new System.EventHandler(this.btthem_Click);
            // 
            // btSua
            // 
            this.btSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btSua.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btSua.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSua.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.Location = new System.Drawing.Point(209, 352);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(75, 23);
            this.btSua.TabIndex = 2;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = false;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btXoa
            // 
            this.btXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btXoa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btXoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btXoa.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.Location = new System.Drawing.Point(484, 352);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(75, 23);
            this.btXoa.TabIndex = 3;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = false;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // tbTimKiem
            // 
            this.tbTimKiem.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimKiem.Location = new System.Drawing.Point(118, 51);
            this.tbTimKiem.Name = "tbTimKiem";
            this.tbTimKiem.Size = new System.Drawing.Size(428, 21);
            this.tbTimKiem.TabIndex = 4;
            this.tbTimKiem.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btTimKiem
            // 
            this.btTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btTimKiem.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTimKiem.Location = new System.Drawing.Point(583, 51);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btTimKiem.TabIndex = 5;
            this.btTimKiem.Text = "Tìm kiếm";
            this.btTimKiem.UseVisualStyleBackColor = false;
            this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
            // 
            // btXem
            // 
            this.btXem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btXem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btXem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btXem.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXem.Location = new System.Drawing.Point(348, 352);
            this.btXem.Name = "btXem";
            this.btXem.Size = new System.Drawing.Size(75, 23);
            this.btXem.TabIndex = 6;
            this.btXem.Text = "Xem";
            this.btXem.UseVisualStyleBackColor = false;
            this.btXem.Click += new System.EventHandler(this.btXem_Click);
            // 
            // btDong
            // 
            this.btDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btDong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDong.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDong.Location = new System.Drawing.Point(618, 352);
            this.btDong.Name = "btDong";
            this.btDong.Size = new System.Drawing.Size(75, 23);
            this.btDong.TabIndex = 7;
            this.btDong.Text = "Đóng";
            this.btDong.UseVisualStyleBackColor = false;
            this.btDong.Click += new System.EventHandler(this.btDong_Click);
            // 
            // Form_NP
            // 
            this.AcceptButton = this.btTimKiem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btDong);
            this.Controls.Add(this.btXem);
            this.Controls.Add(this.btTimKiem);
            this.Controls.Add(this.tbTimKiem);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btthem);
            this.Controls.Add(this.dataGridView_NhapPhi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_NP";
            this.Text = "Quản lý nhập phí";
            this.Load += new System.EventHandler(this.QLNP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NhapPhi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_NhapPhi;
        private System.Windows.Forms.Button btthem;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.TextBox tbTimKiem;
        private System.Windows.Forms.Button btTimKiem;
        private System.Windows.Forms.Button btXem;
        private System.Windows.Forms.Button btDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiPhi;
    }
}

