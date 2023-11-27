using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau_2._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Hàm tính giá trị của biểu thức
        private double CalculateExpression(int n)
        {
            double result = 0;

            // Tính từng thành phần của biểu thức và cộng dồn vào kết quả
            for (int i = 0; i <= n; i++)
            {
                double term = Math.Pow(-1, i) / Factorial(2 * i + 1);
                result += term;
            }

            return result;
        }

        // Hàm tính giai thừa của một số (sử dụng kiểu double để tránh tràn số)
        private double Factorial(int number)
        {
            if (number == 0 || number == 1)
                return 1;

            double result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNhapN.Text, out int n))
            {
                double result = Math.Round(CalculateExpression(n), 4);
                txtKetQua.Text = $"Kết quả: {result}";
            }
            else
            {
                MessageBox.Show("Nhập giá trị n không hợp lệ. Hãy nhập một số nguyên dương.");
            }
        }

        private void btnThulai_Click(object sender, EventArgs e)
        {
            txtNhapN.Clear();
            txtKetQua.Clear();
            txtNhapN.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát khỏi chương trình?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
    }

