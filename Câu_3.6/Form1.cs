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

namespace Câu_3._6
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private DataSet myDataSet;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataTable myTable;
        private string conStr = @"Data Source=RAPHAEL-PC\RAPHAEL;
        Initial Catalog=QLSV;Persist Security Info=True;User ID=sa;Password=Blacksmith@0407";
        private void Display() {
            string sqlStr = "SELECT * FROM tbldiemmon";
            using (myDataAdapter = new SqlDataAdapter(sqlStr, conStr)) {
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "daotao");
                myTable = myDataSet.Tables["daotao"];
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoGenerateColumns = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            Display();
        }     
        private int currentIndex = 0;
        private void MoveToRow(int index) {
            try {
                if (index >= 0 && index < myTable.Rows.Count)  {
                    currentIndex = index;
                    txt_masv.Text = myTable.Rows[currentIndex]["MaSV"].ToString();
                    txt_hoten.Text = myTable.Rows[currentIndex]["HoTen"].ToString();
                    txt_diemthi.Text = myTable.Rows[currentIndex]["DiemThi"].ToString();
                    txt_diembp.Text = myTable.Rows[currentIndex]["DiemBP"].ToString();
                    txt_diemhp.Text = myTable.Rows[currentIndex]["DiemHP"].ToString();
                    dataGridView1.Rows[index].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
                }
            }
            catch (Exception ex) {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            int row = e.RowIndex;
            if (row >= myTable.Rows.Count)
                row = myTable.Rows.Count - 1;
            else {
                MoveToRow(row);
            }
        }
        private void btn_first_Click(object sender, EventArgs e) {
            MoveToRow(0);
        }
        private void btn_previous_Click(object sender, EventArgs e) {
            MoveToRow(currentIndex - 1);
        }
        private void btn_next_Click(object sender, EventArgs e){
            if (currentIndex < myTable.Rows.Count - 1)
                MoveToRow(currentIndex + 1);
        }
        private void btn_last_Click(object sender, EventArgs e){
            MoveToRow(myTable.Rows.Count - 1);
        }
        private void btn_them_Click(object sender, EventArgs e) {
            txt_diembp.Clear();
            txt_diemhp.Clear();
            txt_diemthi.Clear();
            txt_hoten.Clear();
            txt_masv.Clear();
            txt_masv.Focus();
        }
        private void btn_luu_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrWhiteSpace(txt_masv.Text)) {
                    MessageBox.Show("Vui lòng điền mã sinh viên.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                double diemBP, diemThi, diemHP;
                if (double.TryParse(txt_diemthi.Text, out diemThi) && double.TryParse(txt_diembp.Text, out diemBP)) {
                    diemHP = diemBP * 0.4 + diemThi * 0.6;
                    txt_diemhp.Text = diemHP.ToString("0.00");
                }
                else {
                    MessageBox.Show("Vui lòng điền Điểm Thi và Điểm BP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (myConnection = new SqlConnection(conStr)) {
                    myConnection.Open();
                    string sqlStr;
                    sqlStr = $"SELECT COUNT(*) FROM tbldiemmon WHERE MaSV = '{txt_masv.Text}'";
                    myCommand = new SqlCommand(sqlStr, myConnection);
                    int count = (int)myCommand.ExecuteScalar();
                    if (count > 0) {
                        MessageBox.Show("Mã Sinh viên đã tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else {
                        sqlStr = $"INSERT INTO tbldiemmon (MaSV, HoTen, DiemThi, DiemBP, DiemHP)" +
                            $" VALUES ('{txt_masv.Text}', '{txt_hoten.Text}', {diemThi}, {diemBP}, {diemHP})";
                    }
                    myCommand = new SqlCommand(sqlStr, myConnection);
                    int rowsAffected = myCommand.ExecuteNonQuery();
                    if (rowsAffected > 0) {
                        MessageBox.Show("Lưu thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Display();
                    }
                    else {
                        MessageBox.Show("Lưu thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
