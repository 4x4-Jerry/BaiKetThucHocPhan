
namespace QuanLyDuAn_K70
{
    partial class Form_CN
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
            this.dataGridView_ChiNhanh = new System.Windows.Forms.DataGridView();
            this.MaCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbTimKiem_CN = new System.Windows.Forms.TextBox();
            this.btTimKiem_CN = new System.Windows.Forms.Button();
            this.btThem_CN = new System.Windows.Forms.Button();
            this.btSua_CN = new System.Windows.Forms.Button();
            this.btXem_CN = new System.Windows.Forms.Button();
            this.btXoa_CN = new System.Windows.Forms.Button();
            this.btDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ChiNhanh)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_ChiNhanh
            // 
            this.dataGridView_ChiNhanh.AllowUserToAddRows = false;
            this.dataGridView_ChiNhanh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_ChiNhanh.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView_ChiNhanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ChiNhanh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCN,
            this.TenCN});
            this.dataGridView_ChiNhanh.Location = new System.Drawing.Point(63, 105);
            this.dataGridView_ChiNhanh.Name = "dataGridView_ChiNhanh";
            this.dataGridView_ChiNhanh.ReadOnly = true;
            this.dataGridView_ChiNhanh.Size = new System.Drawing.Size(650, 217);
            this.dataGridView_ChiNhanh.TabIndex = 0;
            this.dataGridView_ChiNhanh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_ChiNhanh_CellClick_1);
            // 
            // MaCN
            // 
            this.MaCN.DataPropertyName = "MaCN";
            this.MaCN.HeaderText = "Mã chi nhánh";
            this.MaCN.Name = "MaCN";
            this.MaCN.ReadOnly = true;
            // 
            // TenCN
            // 
            this.TenCN.DataPropertyName = "TenCN";
            this.TenCN.HeaderText = "Tên chi nhánh";
            this.TenCN.Name = "TenCN";
            this.TenCN.ReadOnly = true;
            // 
            // tbTimKiem_CN
            // 
            this.tbTimKiem_CN.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimKiem_CN.Location = new System.Drawing.Point(97, 44);
            this.tbTimKiem_CN.Name = "tbTimKiem_CN";
            this.tbTimKiem_CN.Size = new System.Drawing.Size(477, 21);
            this.tbTimKiem_CN.TabIndex = 1;
            this.tbTimKiem_CN.TextChanged += new System.EventHandler(this.tbTimKiem_CN_TextChanged_1);
            // 
            // btTimKiem_CN
            // 
            this.btTimKiem_CN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btTimKiem_CN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btTimKiem_CN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btTimKiem_CN.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTimKiem_CN.Location = new System.Drawing.Point(599, 44);
            this.btTimKiem_CN.Name = "btTimKiem_CN";
            this.btTimKiem_CN.Size = new System.Drawing.Size(75, 23);
            this.btTimKiem_CN.TabIndex = 2;
            this.btTimKiem_CN.Text = "Tìm kiếm";
            this.btTimKiem_CN.UseVisualStyleBackColor = false;
            this.btTimKiem_CN.Click += new System.EventHandler(this.btTimKiem_CN_Click);
            // 
            // btThem_CN
            // 
            this.btThem_CN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btThem_CN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btThem_CN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btThem_CN.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem_CN.Location = new System.Drawing.Point(72, 373);
            this.btThem_CN.Name = "btThem_CN";
            this.btThem_CN.Size = new System.Drawing.Size(75, 23);
            this.btThem_CN.TabIndex = 3;
            this.btThem_CN.Text = "Thêm";
            this.btThem_CN.UseVisualStyleBackColor = false;
            this.btThem_CN.Click += new System.EventHandler(this.btThem_CN_Click);
            // 
            // btSua_CN
            // 
            this.btSua_CN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btSua_CN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btSua_CN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btSua_CN.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua_CN.Location = new System.Drawing.Point(204, 373);
            this.btSua_CN.Name = "btSua_CN";
            this.btSua_CN.Size = new System.Drawing.Size(75, 23);
            this.btSua_CN.TabIndex = 4;
            this.btSua_CN.Text = "Sửa";
            this.btSua_CN.UseVisualStyleBackColor = false;
            this.btSua_CN.Click += new System.EventHandler(this.btSua_CN_Click_1);
            // 
            // btXem_CN
            // 
            this.btXem_CN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btXem_CN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btXem_CN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btXem_CN.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXem_CN.Location = new System.Drawing.Point(343, 373);
            this.btXem_CN.Name = "btXem_CN";
            this.btXem_CN.Size = new System.Drawing.Size(75, 23);
            this.btXem_CN.TabIndex = 5;
            this.btXem_CN.Text = "Xem";
            this.btXem_CN.UseVisualStyleBackColor = false;
            this.btXem_CN.Click += new System.EventHandler(this.btXem_CN_Click_1);
            // 
            // btXoa_CN
            // 
            this.btXoa_CN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btXoa_CN.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btXoa_CN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btXoa_CN.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa_CN.Location = new System.Drawing.Point(480, 373);
            this.btXoa_CN.Name = "btXoa_CN";
            this.btXoa_CN.Size = new System.Drawing.Size(75, 23);
            this.btXoa_CN.TabIndex = 6;
            this.btXoa_CN.Text = "Xóa";
            this.btXoa_CN.UseVisualStyleBackColor = false;
            this.btXoa_CN.Click += new System.EventHandler(this.btXoa_CN_Click);
            // 
            // btDong
            // 
            this.btDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btDong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDong.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDong.Location = new System.Drawing.Point(616, 373);
            this.btDong.Name = "btDong";
            this.btDong.Size = new System.Drawing.Size(75, 23);
            this.btDong.TabIndex = 7;
            this.btDong.Text = "Đóng";
            this.btDong.UseVisualStyleBackColor = false;
            this.btDong.Click += new System.EventHandler(this.btDong_Click);
            // 
            // Form_CN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btDong);
            this.Controls.Add(this.btXoa_CN);
            this.Controls.Add(this.btXem_CN);
            this.Controls.Add(this.btSua_CN);
            this.Controls.Add(this.btThem_CN);
            this.Controls.Add(this.btTimKiem_CN);
            this.Controls.Add(this.tbTimKiem_CN);
            this.Controls.Add(this.dataGridView_ChiNhanh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_CN";
            this.Text = "Quản lý chi nhánh";
            this.Load += new System.EventHandler(this.Form_CN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ChiNhanh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_ChiNhanh;
        private System.Windows.Forms.TextBox tbTimKiem_CN;
        private System.Windows.Forms.Button btTimKiem_CN;
        private System.Windows.Forms.Button btThem_CN;
        private System.Windows.Forms.Button btSua_CN;
        private System.Windows.Forms.Button btXem_CN;
        private System.Windows.Forms.Button btXoa_CN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCN;
        private System.Windows.Forms.Button btDong;
    }
}