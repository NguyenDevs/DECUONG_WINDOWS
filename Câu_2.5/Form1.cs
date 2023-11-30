using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Câu_2._5
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

        private void btn_thulai_Click(object sender, EventArgs e)
        {
            txt_ketqua.Clear();
            txt_mauso1.Clear();
            txt_mauso2.Clear();
            txt_tuso1.Clear();
            txt_tuso2.Clear();
            txt_tuso1.Focus();
        }

        private void btn_tru_Click(object sender, EventArgs e){
            TinhPhepTinh("Tru");
        }
        private void btn_chia_Click(object sender, EventArgs e){
            TinhPhepTinh("Chia");
        }
        private void TinhPhepTinh(string phepTinh){
            try{
                if (!int.TryParse(txt_tuso1.Text, out int tuso1) ||
                   !int.TryParse(txt_mauso1.Text, out int mauso1) ||
                   !int.TryParse(txt_tuso2.Text, out int tuso2) ||
                   !int.TryParse(txt_mauso2.Text, out int mauso2))
                {
                    MessageBox.Show("Dữ liệu nhập vào không hợp lệ. Vui lòng nhập số nguyên.");
                    return;
                }
                // Kiểm tra dữ liệu nhập vào
                if (mauso1 <= 0 || mauso2 <= 0){
                    MessageBox.Show("Mẫu số không thể bé hơn hoặc bằng 0.");
                    return;
                }
                PhanSo ketqua = new PhanSo();
                if (phepTinh == "Tru"){
                    ketqua = PhanSo.Tru(new PhanSo(tuso1, mauso1), new PhanSo(tuso2, mauso2));
                }
                else if (phepTinh == "Chia"){
                    ketqua = PhanSo.Chia(new PhanSo(tuso1, mauso1), new PhanSo(tuso2, mauso2));
                }
                // Tối giản phân số
                ketqua.ToiGian();
                // Hiển thị kết quả
                txt_ketqua.Text = ketqua.ToString();
            }
            catch (Exception ex){
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }
    }
    public class PhanSo{
        public int TuSo { get; set; }
        public int MauSo { get; set; }

        public PhanSo(){
            TuSo = 0;
            MauSo = 1;
        }
        public PhanSo(int tuSo, int mauSo){
            TuSo = tuSo;
            MauSo = mauSo;
        }
        public static PhanSo Tru(PhanSo ps1, PhanSo ps2){
            return new PhanSo(ps1.TuSo * ps2.MauSo - ps2.TuSo * ps1.MauSo, ps1.MauSo * ps2.MauSo);
        }
        public static PhanSo Chia(PhanSo ps1, PhanSo ps2){
            return new PhanSo(ps1.TuSo * ps2.MauSo, ps1.MauSo * ps2.TuSo);
        }
        public int UCLN(int a, int b){
            while (b != 0){
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public void ToiGian(){
            int ucln = UCLN(Math.Abs(TuSo), Math.Abs(MauSo));
            TuSo /= ucln;
            MauSo /= ucln;
        }
        public override string ToString(){
            return $"{TuSo}/{MauSo}";
        }
    }
}
