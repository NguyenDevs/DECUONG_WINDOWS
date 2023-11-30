using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Câu_2._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_tinhtien_Click(object sender, EventArgs e)
        {
            if (txt_nhapten.Text == "")
            {
                MessageBox.Show("ban chua nhap ten khach hang");
                cb_caovoi.Checked = false;
                cb_taytrang.Checked = false;
                cb_chuphinh.Checked = false;
                txt_total.Text = "";
                num_tramrang.Value = 0;
                txt_nhapten.Focus();
            }
            else
            {
                float x = 0;
                long total = 0;
                if (cb_caovoi.Checked == true) total += 100000;
                if (cb_taytrang.Checked == true) total += 1200000;
                if (cb_chuphinh.Checked == true) total += 200000;
                total += (long)num_tramrang.Value * 80000;
                txt_total.Text = System.Math.Round(x, 2).ToString();
                label1.BackColor = Color.Transparent;
                txt_total.Text = total.ToString();
                txt_total.ForeColor = Color.Blue;
                txt_total.ForeColor = Color.Blue;
                txt_total.ForeColor = System.Drawing.Color.Blue;
                txt_nhapten.Enabled = false;
                num_tramrang.Enabled = false;

                cb_caovoi.Checked = false;
                cb_taytrang.Checked = false;
                cb_chuphinh.Checked = false;

            }
        }
    }
}
