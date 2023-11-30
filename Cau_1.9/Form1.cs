using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau_1._9{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }
        private void btnTinh_Click(object sender, EventArgs e){
            if (!KiemTraDuLieu()){
                MessageBox.Show("Vui lòng nhập đúng định dạng số nguyên cho a, b, c.", "Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            // Lấy giá trị của a, b, c từ TextBox
            int a = int.Parse(txtHesoA.Text);
            int b = int.Parse(txtHesoB.Text);
            int c = int.Parse(txtHesoC.Text);
            // Tính delta và kiểm tra
            int delta = b * b - 4 * a * c;
            if (delta < 0){
                txtKetqua.Text = "Phương trình vô nghiệm";
            }
            else if (delta == 0){
                double x = -b / (2.0 * a);
                txtKetqua.Text = $"Phương trình có nghiệm kép: x = {Math.Round(x, 2)}";
            }
            else{
                double x1 = (-b + Math.Sqrt(delta)) / (2.0 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2.0 * a);
            txtKetqua.Text = $"Phương trình có 2 nghiệm phân biệt: x1 = {Math.Round(x1, 2)}, x2 = {Math.Round(x2, 2)}";
        }
    }
    private void btnThulai_Click(object sender, EventArgs e){
        txtHesoA.Clear();
        txtHesoB.Clear();
        txtHesoC.Clear();
        // Đưa trỏ chuột về TextBox Hệ số a
        txtHesoA.Focus();
    }
        private void btnThoat_Click(object sender, EventArgs e){
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát khỏi chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes){
                Application.Exit();
            }
        }
        private bool KiemTraDuLieu(){
            int a, b, c;
            return int.TryParse(txtHesoA.Text, out a) 
                && int.TryParse(txtHesoB.Text, out b) 
                && int.TryParse(txtHesoC.Text, out c);
        }
    }
}
