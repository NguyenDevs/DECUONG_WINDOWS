namespace Câu_2._3
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btn_chon = new System.Windows.Forms.Button();
            this.btn_chonall = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_tinhtien = new System.Windows.Forms.Button();
            this.btn_huyall = new System.Windows.Forms.Button();
            this.btn_dattiep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sosuatchon = new System.Windows.Forms.TextBox();
            this.txt_thanhtien = new System.Windows.Forms.TextBox();
            this.btn_thoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "Bún Bò Hầm - 25000",
            "Bún Bò Tái - 25000",
            "Súp Lươn - 20000",
            "Cơm Rang - 20000",
            "Phở Bò Hầm - 30000",
            "Phở Bò Tái - 30000",
            "Bún Chả Nướng - 25000"});
            this.listBox1.Location = new System.Drawing.Point(110, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(234, 324);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(542, 40);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(234, 324);
            this.listBox2.TabIndex = 1;
            // 
            // btn_chon
            // 
            this.btn_chon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chon.Location = new System.Drawing.Point(385, 40);
            this.btn_chon.Name = "btn_chon";
            this.btn_chon.Size = new System.Drawing.Size(117, 40);
            this.btn_chon.TabIndex = 2;
            this.btn_chon.Text = "Chọn món";
            this.btn_chon.UseVisualStyleBackColor = true;
            this.btn_chon.Click += new System.EventHandler(this.btn_chon_Click);
            // 
            // btn_chonall
            // 
            this.btn_chonall.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chonall.Location = new System.Drawing.Point(385, 86);
            this.btn_chonall.Name = "btn_chonall";
            this.btn_chonall.Size = new System.Drawing.Size(117, 40);
            this.btn_chonall.TabIndex = 3;
            this.btn_chonall.Text = "Chọn tất cả";
            this.btn_chonall.UseVisualStyleBackColor = true;
            this.btn_chonall.Click += new System.EventHandler(this.btn_chonall_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_huy.Location = new System.Drawing.Point(385, 132);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(117, 40);
            this.btn_huy.TabIndex = 4;
            this.btn_huy.Text = "Huỷ món";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_tinhtien
            // 
            this.btn_tinhtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tinhtien.Location = new System.Drawing.Point(385, 224);
            this.btn_tinhtien.Name = "btn_tinhtien";
            this.btn_tinhtien.Size = new System.Drawing.Size(117, 40);
            this.btn_tinhtien.TabIndex = 5;
            this.btn_tinhtien.Text = "Tính tiền";
            this.btn_tinhtien.UseVisualStyleBackColor = true;
            this.btn_tinhtien.Click += new System.EventHandler(this.btn_tinhtien_Click);
            // 
            // btn_huyall
            // 
            this.btn_huyall.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_huyall.Location = new System.Drawing.Point(385, 178);
            this.btn_huyall.Name = "btn_huyall";
            this.btn_huyall.Size = new System.Drawing.Size(117, 40);
            this.btn_huyall.TabIndex = 6;
            this.btn_huyall.Text = "Huỷ tất cả";
            this.btn_huyall.UseVisualStyleBackColor = true;
            this.btn_huyall.Click += new System.EventHandler(this.btn_huyall_Click);
            // 
            // btn_dattiep
            // 
            this.btn_dattiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dattiep.Location = new System.Drawing.Point(385, 270);
            this.btn_dattiep.Name = "btn_dattiep";
            this.btn_dattiep.Size = new System.Drawing.Size(117, 40);
            this.btn_dattiep.TabIndex = 7;
            this.btn_dattiep.Text = "Đặt tiếp";
            this.btn_dattiep.UseVisualStyleBackColor = true;
            this.btn_dattiep.Click += new System.EventHandler(this.btn_dattiep_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(110, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Số suất chọn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 452);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Thành tiền";
            // 
            // txt_sosuatchon
            // 
            this.txt_sosuatchon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sosuatchon.Location = new System.Drawing.Point(277, 398);
            this.txt_sosuatchon.Name = "txt_sosuatchon";
            this.txt_sosuatchon.Size = new System.Drawing.Size(329, 27);
            this.txt_sosuatchon.TabIndex = 10;
            // 
            // txt_thanhtien
            // 
            this.txt_thanhtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_thanhtien.Location = new System.Drawing.Point(277, 452);
            this.txt_thanhtien.Name = "txt_thanhtien";
            this.txt_thanhtien.Size = new System.Drawing.Size(329, 27);
            this.txt_thanhtien.TabIndex = 11;
            // 
            // btn_thoat
            // 
            this.btn_thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thoat.Location = new System.Drawing.Point(659, 418);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(117, 40);
            this.btn_thoat.TabIndex = 12;
            this.btn_thoat.Text = "Thoát";
            this.btn_thoat.UseVisualStyleBackColor = true;
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 505);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.txt_thanhtien);
            this.Controls.Add(this.txt_sosuatchon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_dattiep);
            this.Controls.Add(this.btn_huyall);
            this.Controls.Add(this.btn_tinhtien);
            this.Controls.Add(this.btn_huy);
            this.Controls.Add(this.btn_chonall);
            this.Controls.Add(this.btn_chon);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Nhà hàng Hoa Mai";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btn_chon;
        private System.Windows.Forms.Button btn_chonall;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.Button btn_tinhtien;
        private System.Windows.Forms.Button btn_huyall;
        private System.Windows.Forms.Button btn_dattiep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_sosuatchon;
        private System.Windows.Forms.TextBox txt_thanhtien;
        private System.Windows.Forms.Button btn_thoat;
    }
}

