
namespace QuanLyDuAn_K70
{
    partial class ChiTiet_GiaTriNT
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
            this.btLuu = new System.Windows.Forms.Button();
            this.btDong = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMaDA = new System.Windows.Forms.ComboBox();
            this.cbMaGD = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtStartDayGD = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFinalDayGD = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tbGTNT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbTenDA = new System.Windows.Forms.TextBox();
            this.tbTenGD = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btLuu
            // 
            this.btLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btLuu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btLuu.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLuu.Location = new System.Drawing.Point(85, 304);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(75, 23);
            this.btLuu.TabIndex = 2;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = false;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // btDong
            // 
            this.btDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btDong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDong.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDong.Location = new System.Drawing.Point(345, 304);
            this.btDong.Name = "btDong";
            this.btDong.Size = new System.Drawing.Size(75, 23);
            this.btDong.TabIndex = 3;
            this.btDong.Text = "Đóng";
            this.btDong.UseVisualStyleBackColor = false;
            this.btDong.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã dự án";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã giai đoạn";
            // 
            // cbMaDA
            // 
            this.cbMaDA.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaDA.FormattingEnabled = true;
            this.cbMaDA.Location = new System.Drawing.Point(157, 37);
            this.cbMaDA.Name = "cbMaDA";
            this.cbMaDA.Size = new System.Drawing.Size(278, 23);
            this.cbMaDA.TabIndex = 6;
            this.cbMaDA.Click += new System.EventHandler(this.cbMaDA_Click);
            // 
            // cbMaGD
            // 
            this.cbMaGD.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMaGD.FormattingEnabled = true;
            this.cbMaGD.Location = new System.Drawing.Point(157, 81);
            this.cbMaGD.Name = "cbMaGD";
            this.cbMaGD.Size = new System.Drawing.Size(278, 23);
            this.cbMaGD.TabIndex = 7;
            this.cbMaGD.Click += new System.EventHandler(this.cbMaGD_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ngày bắt đầu giai đoạn";
            // 
            // dtStartDayGD
            // 
            this.dtStartDayGD.CustomFormat = "dd/MM/yyyy";
            this.dtStartDayGD.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStartDayGD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStartDayGD.Location = new System.Drawing.Point(157, 130);
            this.dtStartDayGD.Name = "dtStartDayGD";
            this.dtStartDayGD.Size = new System.Drawing.Size(278, 21);
            this.dtStartDayGD.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ngày kết thúc giai đoạn";
            // 
            // dtFinalDayGD
            // 
            this.dtFinalDayGD.CustomFormat = "dd/MM/yyyy";
            this.dtFinalDayGD.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFinalDayGD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFinalDayGD.Location = new System.Drawing.Point(157, 170);
            this.dtFinalDayGD.Name = "dtFinalDayGD";
            this.dtFinalDayGD.Size = new System.Drawing.Size(278, 21);
            this.dtFinalDayGD.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Giá trị nghiệm thu";
            // 
            // tbGTNT
            // 
            this.tbGTNT.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGTNT.Location = new System.Drawing.Point(157, 221);
            this.tbGTNT.Name = "tbGTNT";
            this.tbGTNT.Size = new System.Drawing.Size(278, 21);
            this.tbGTNT.TabIndex = 13;
            this.tbGTNT.Leave += new System.EventHandler(this.tbGTNT_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(473, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tên dự án";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(454, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Tên giai đoạn";
            // 
            // tbTenDA
            // 
            this.tbTenDA.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTenDA.Location = new System.Drawing.Point(549, 38);
            this.tbTenDA.Name = "tbTenDA";
            this.tbTenDA.Size = new System.Drawing.Size(187, 21);
            this.tbTenDA.TabIndex = 16;
            // 
            // tbTenGD
            // 
            this.tbTenGD.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTenGD.Location = new System.Drawing.Point(549, 82);
            this.tbTenGD.Name = "tbTenGD";
            this.tbTenGD.Size = new System.Drawing.Size(187, 21);
            this.tbTenGD.TabIndex = 17;
            // 
            // ChiTiet_GiaTriNT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbTenGD);
            this.Controls.Add(this.tbTenDA);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbGTNT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtFinalDayGD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtStartDayGD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbMaGD);
            this.Controls.Add(this.cbMaDA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btDong);
            this.Controls.Add(this.btLuu);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ChiTiet_GiaTriNT";
            this.Text = "Form chung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btDong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMaDA;
        private System.Windows.Forms.ComboBox cbMaGD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtStartDayGD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFinalDayGD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbGTNT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbTenDA;
        private System.Windows.Forms.TextBox tbTenGD;
    }
}