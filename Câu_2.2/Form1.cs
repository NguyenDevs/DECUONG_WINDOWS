using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Câu_2._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txt_x.TextChanged += ClearResultTextBox;
            txt_epsilon.TextChanged += ClearResultTextBox;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_thulai_Click(object sender, EventArgs e)
        {
            txt_epsilon.Clear();
            txt_ketqua.Clear();
            txt_x.Clear();
            txt_x.Focus();
        }

        private void btn_tinh_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txt_x.Text, out double x))
            {
                if (double.TryParse(txt_epsilon.Text, out double epsilon) && epsilon > 0 && epsilon < 1)
                {
                    double result = calculateCosine(x, epsilon);
                    txt_ketqua.Text = result.ToString("#0.000");
                }
                else
                {
                    MessageBox.Show("Epsilon phải (0 < epsilon < 1).");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập X");
            }
        }
        private double calculateCosine(double x, double epsilon)
        {
            double result = 1.0;
            double term = 1.0;
            int n = 1;
            while (Math.Abs(term) >= epsilon)
            {
                term = -term * x * x / (2 * n) / (2 * n - 1);
                result += term;
                n++;
            }
            return result;
        }
        private void ClearResultTextBox(object sender, EventArgs e)
        {
            txt_ketqua.Clear();
        }
    }
}
