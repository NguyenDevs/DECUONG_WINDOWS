using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau_1._10{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }
        // Hàm kiểm tra số nguyên tố
        private bool IsPrime(int number){
            if (number < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(number); i++){
                if (number % i == 0)
                    return false;
            } return true;
        }
        //Hàm liệt kê các số nguyên tố đến n
        private string ListPrimes(int n){
            string result = " Các số nguyên tố từ 0 đến " + n + ": \n";
            for (int i = 2; i <= n; i++){
                if (IsPrime(i)){
                    result += i + " ";
                }
            } return result;
        }
        private void button1_Click(object sender, EventArgs e){
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát khỏi chương trình?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes){
                Application.Exit();
            }
        }
        private void txtNhapN_KeyPress(object sender, KeyPressEventArgs e){
            if (e.KeyChar == (char)Keys.Enter){
                int n;
                if (int.TryParse(txtNhapN.Text, out n)){
                    bool isPrime = IsPrime(n);
                    txtKiemTra.Text = isPrime ? $" {n} là số nguyên tố" : $" {n} không là số nguyên tố";
                    txtLietKe.Text = ListPrimes(n);
                }
                else{
                    MessageBox.Show("Nhập N không hợp lệ. Hãy nhập một số nguyên dương.");
                }
                e.Handled = true;
            }
        }
    }
}
