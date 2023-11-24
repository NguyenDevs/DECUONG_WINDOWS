namespace Cau_1._9
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
            this.btnTinh = new System.Windows.Forms.Button();
            this.btnThulai = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txt_a = new System.Windows.Forms.Label();
            this.txt_b = new System.Windows.Forms.Label();
            this.txt_c = new System.Windows.Forms.Label();
            this.txtHesoA = new System.Windows.Forms.TextBox();
            this.txtHesoB = new System.Windows.Forms.TextBox();
            this.txtHesoC = new System.Windows.Forms.TextBox();
            this.txtKetqua = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTinh
            // 
            this.btnTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinh.Location = new System.Drawing.Point(132, 502);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(142, 39);
            this.btnTinh.TabIndex = 0;
            this.btnTinh.Text = "Tính";
            this.btnTinh.UseVisualStyleBackColor = true;
            this.btnTinh.Click += new System.EventHandler(this.btnTinh_Click);
            // 
            // btnThulai
            // 
            this.btnThulai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThulai.Location = new System.Drawing.Point(307, 502);
            this.btnThulai.Name = "btnThulai";
            this.btnThulai.Size = new System.Drawing.Size(142, 39);
            this.btnThulai.TabIndex = 1;
            this.btnThulai.Text = "Thử lại";
            this.btnThulai.UseVisualStyleBackColor = true;
            this.btnThulai.Click += new System.EventHandler(this.btnThulai_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(483, 502);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(142, 39);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseMnemonic = false;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txt_a
            // 
            this.txt_a.AutoSize = true;
            this.txt_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_a.Location = new System.Drawing.Point(128, 62);
            this.txt_a.Name = "txt_a";
            this.txt_a.Size = new System.Drawing.Size(68, 20);
            this.txt_a.TabIndex = 3;
            this.txt_a.Text = "Hệ số a";
            // 
            // txt_b
            // 
            this.txt_b.AutoSize = true;
            this.txt_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_b.Location = new System.Drawing.Point(128, 143);
            this.txt_b.Name = "txt_b";
            this.txt_b.Size = new System.Drawing.Size(68, 20);
            this.txt_b.TabIndex = 4;
            this.txt_b.Text = "Hệ số b";
            // 
            // txt_c
            // 
            this.txt_c.AutoSize = true;
            this.txt_c.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_c.Location = new System.Drawing.Point(128, 222);
            this.txt_c.Name = "txt_c";
            this.txt_c.Size = new System.Drawing.Size(68, 20);
            this.txt_c.TabIndex = 5;
            this.txt_c.Text = "Hệ số c";
            // 
            // txtHesoA
            // 
            this.txtHesoA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHesoA.Location = new System.Drawing.Point(258, 54);
            this.txtHesoA.Multiline = true;
            this.txtHesoA.Name = "txtHesoA";
            this.txtHesoA.Size = new System.Drawing.Size(260, 38);
            this.txtHesoA.TabIndex = 6;
            // 
            // txtHesoB
            // 
            this.txtHesoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHesoB.Location = new System.Drawing.Point(258, 134);
            this.txtHesoB.Multiline = true;
            this.txtHesoB.Name = "txtHesoB";
            this.txtHesoB.Size = new System.Drawing.Size(260, 38);
            this.txtHesoB.TabIndex = 7;
            // 
            // txtHesoC
            // 
            this.txtHesoC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHesoC.Location = new System.Drawing.Point(258, 214);
            this.txtHesoC.Multiline = true;
            this.txtHesoC.Name = "txtHesoC";
            this.txtHesoC.Size = new System.Drawing.Size(260, 38);
            this.txtHesoC.TabIndex = 8;
            // 
            // txtKetqua
            // 
            this.txtKetqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKetqua.Location = new System.Drawing.Point(132, 326);
            this.txtKetqua.Multiline = true;
            this.txtKetqua.Name = "txtKetqua";
            this.txtKetqua.ReadOnly = true;
            this.txtKetqua.Size = new System.Drawing.Size(493, 136);
            this.txtKetqua.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Kết quả:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 599);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKetqua);
            this.Controls.Add(this.txtHesoC);
            this.Controls.Add(this.txtHesoB);
            this.Controls.Add(this.txtHesoA);
            this.Controls.Add(this.txt_c);
            this.Controls.Add(this.txt_b);
            this.Controls.Add(this.txt_a);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThulai);
            this.Controls.Add(this.btnTinh);
            this.Name = "Form1";
            this.Text = "GIẢI PHƯƠNG TRÌNH BẬC HAI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.Button btnThulai;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label txt_a;
        private System.Windows.Forms.Label txt_b;
        private System.Windows.Forms.Label txt_c;
        private System.Windows.Forms.TextBox txtHesoA;
        private System.Windows.Forms.TextBox txtHesoB;
        private System.Windows.Forms.TextBox txtHesoC;
        private System.Windows.Forms.TextBox txtKetqua;
        private System.Windows.Forms.Label label1;
    }
}

