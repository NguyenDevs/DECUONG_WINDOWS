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

namespace Câu_3._2 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataTable myTable;
        private string conStr = @"Data Source=RAPHAEL-PC\RAPHAEL;
        Initial Catalog=QLSV;Persist Security Info=True;User ID=sa;Password=Blacksmith@0407";
        private void Display() {
            string sqlStr = "SELECT * FROM tblsinhvien";
            using (myDataAdapter = new SqlDataAdapter(sqlStr, conStr)) {
                myTable = new DataTable();
                myDataAdapter.Fill(myTable);
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoGenerateColumns = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            using (myConnection = new SqlConnection(conStr)) {
                myConnection.Open();
                Display();
            }
        }
        private void btn_them_Click(object sender, EventArgs e) {
            txt_masv.Clear();
            txt_hoten.Clear();
            txt_makhoa.Clear();
            txt_gioitinh.Clear();
            txt_ngaysinh.ResetText();
            txt_masv.Focus();
        }
        private void btn_sua_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txt_masv.Text)) {
                MessageBox.Show("Please enter Masv to update.");
                return;
            }
            DataRow[] rows = myTable.Select($"Masv = '{txt_masv.Text}'");
            if (rows.Length > 0) {
                rows[0]["HovaTen"] = txt_hoten.Text;
                rows[0]["MaKhoa"] = txt_makhoa.Text;
                rows[0]["GioiTinh"] = txt_gioitinh.Text;
                rows[0]["NgaySinh"] = txt_ngaysinh.Text;
                UpdateDatabase(rows[0]);
                Display();
            }
            else{
                MessageBox.Show($"Masv '{txt_masv.Text}' not found.");
            }
        }
        private void UpdateDatabase(DataRow row) {
            try {
                using (myConnection = new SqlConnection(conStr)) {
                    myConnection.Open();
                    string updateSql = $"UPDATE tblsinhvien SET HovaTen = '{row["HovaTen"]}', MaKhoa = '{row["MaKhoa"]}', " +
                                       $"GioiTinh = '{row["GioiTinh"]}', NgaySinh = '{row["NgaySinh"]}' WHERE Masv = '{row["Masv"]}'";
                    using (myCommand = new SqlCommand(updateSql, myConnection)) {
                        myCommand.ExecuteNonQuery();
                        MessageBox.Show("Data updated successfully.");
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    private void btn_luu_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txt_masv.Text)) {
                MessageBox.Show("Please enter Masv to update.");
                return;
            }
            try {
                using (myConnection = new SqlConnection(conStr)) {
                    myConnection.Open();
                    string sqlStr3 = "INSERT INTO tblsinhvien(Masv, HovaTen, NgaySinh, GioiTinh, Makhoa) " +
                                     "VALUES(@Masv, @HovaTen, @NgaySinh, @GioiTinh, @Makhoa)";
                    using (myCommand = new SqlCommand(sqlStr3, myConnection)) {
                        myCommand.Parameters.AddWithValue("@Masv", txt_masv.Text);
                        myCommand.Parameters.AddWithValue("@HovaTen", txt_hoten.Text);
                        myCommand.Parameters.AddWithValue("@NgaySinh", txt_ngaysinh.Text);
                        myCommand.Parameters.AddWithValue("@GioiTinh", txt_gioitinh.Text);
                        myCommand.Parameters.AddWithValue("@Makhoa", txt_makhoa.Text);
                        myCommand.ExecuteNonQuery();
                    }
                    Display();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_thoat_Click(object sender, EventArgs e){
            Application.Exit();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            int row = e.RowIndex;
            if (row >= myTable.Rows.Count)
                row = myTable.Rows.Count - 1;
            else {
                txt_masv.Text = myTable.Rows[row]["Masv"].ToString();
                txt_hoten.Text = myTable.Rows[row]["HovaTen"].ToString();
                txt_makhoa.Text = myTable.Rows[row]["MaKhoa"].ToString();
                txt_gioitinh.Text = myTable.Rows[row]["GioiTinh"].ToString();
                txt_ngaysinh.Text = myTable.Rows[row]["NgaySinh"].ToString();
            }
        }
    }
}
