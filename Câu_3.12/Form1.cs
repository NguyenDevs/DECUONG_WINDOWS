using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Câu_3._12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private DataSet myDataSet;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataTable myTable;
        private string conStr = @"Data Source=RAPHAEL-PC\RAPHAEL;
        Initial Catalog=QLBH;Persist Security Info=True;User ID=sa;Password=Blacksmith@0407";
        private void Display()
        {
            string sqlStr = "SELECT * FROM tblhangnhap";
            using (myDataAdapter = new SqlDataAdapter(sqlStr, conStr))
            {
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "daotao");
                myTable = myDataSet.Tables["daotao"];
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoGenerateColumns = false;
            }
        }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_dongia.Clear();
            txt_donvitinh.Clear();
            txt_mahang.Clear();
            txt_soluong.Clear();
            txt_tenhang.Clear();
            txt_thanhtien.Clear();
            txt_tong.Clear();
            txt_mahang.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
            UpdateTotal();
        }
        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                string maHang = txt_mahang.Text;
                string tenHang = txt_tenhang.Text;
                string donViTinh = txt_donvitinh.Text;
                int soLuong = int.Parse(txt_soluong.Text);
                decimal donGia = decimal.Parse(txt_dongia.Text);
                decimal thanhTien = soLuong * donGia;
                string sqlInsert = "INSERT INTO tblhangnhap (Mahang, Tenhang, Donvitinh, Soluong, Dongia, Thanhtien) " +
                                   "VALUES (@MaHang, @TenHang, @DonViTinh, @SoLuong, @DonGia, @ThanhTien)";

                using (myConnection = new SqlConnection(conStr))
                {
                    myConnection.Open();

                    using (myCommand = new SqlCommand(sqlInsert, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@MaHang", maHang);
                        myCommand.Parameters.AddWithValue("@TenHang", tenHang);
                        myCommand.Parameters.AddWithValue("@DonViTinh", donViTinh);
                        myCommand.Parameters.AddWithValue("@SoLuong", soLuong);
                        myCommand.Parameters.AddWithValue("@DonGia", donGia);
                        myCommand.Parameters.AddWithValue("@ThanhTien", thanhTien);
                        int rowsAffected = myCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Dữ liệu đã được lưu thành công.");
                            Display();
                            UpdateTotal();
                            txt_thanhtien.Text = thanhTien.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }
        private void UpdateTotal()
        {
            string sqlSum = "SELECT ISNULL(SUM(Thanhtien), 0) FROM tblhangnhap";
            using (myDataAdapter = new SqlDataAdapter(sqlSum, conStr))
            {
                DataTable dt = new DataTable();
                myDataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txt_tong.Text = dt.Rows[0][0].ToString();
                }
            }
        }
    }
}
