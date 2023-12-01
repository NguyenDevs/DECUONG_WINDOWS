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

namespace Câu_3._1{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }
        private SqlDataAdapter myDataAdapter;
        private DataSet myDataSet;
        private SqlCommand myCommand;
        private SqlConnection myConnection;
        private DataTable myTable;
        private string conStr = @"Data Source=RAPHAEL-PC\RAPHAEL;
        Initial Catalog=QLSV;Persist Security Info=True;User ID=sa;Password=Blacksmith@0407";
        private void Display(){
            string sqlStr = "SELECT * FROM tblsinhvien";
            using (myDataAdapter = new SqlDataAdapter(sqlStr, conStr)){
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "daotao");
                myTable = myDataSet.Tables["daotao"];
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoGenerateColumns = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e){
            using (myConnection = new SqlConnection(conStr)){
                myConnection.Open();
                Display();
            }
        }
        private void btn_thoat_Click(object sender, EventArgs e){
            Application.Exit();
        }
        private void btn_them_Click(object sender, EventArgs e){
            txt_masv.Clear();
            txt_hoten.Clear();
            txt_makhoa.Clear();
            txt_gioitinh.Clear();
            txt_ngaysinh.ResetText();
            txt_masv.Focus();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            int row = e.RowIndex;
            if (row >= myTable.Rows.Count)
                row = myTable.Rows.Count - 1;
            else{
                txt_masv.Text = myTable.Rows[row]["Masv"].ToString();
                txt_hoten.Text = myTable.Rows[row]["HovaTen"].ToString();
                txt_makhoa.Text = myTable.Rows[row]["MaKhoa"].ToString();
                txt_gioitinh.Text = myTable.Rows[row]["GioiTinh"].ToString();
                txt_ngaysinh.Text = myTable.Rows[row]["NgaySinh"].ToString();
            }
        }
        private void btn_luu_Click(object sender, EventArgs e){
            if (string.IsNullOrEmpty(txt_masv.Text))
            {
                MessageBox.Show("Please enter Masv to update.");
                return;
            }
            try
            {
                using (myConnection = new SqlConnection(conStr)){
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
            catch (Exception ex){
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_xoa_Click(object sender, EventArgs e) {
            try {
                int pos = dataGridView1.CurrentRow.Index;
                string masvToDelete = myTable.Rows[pos]["Masv"].ToString();
                DeleteRecordFromDatabase(masvToDelete);
                myTable.Rows[pos].Delete();
                myTable.AcceptChanges();
            }
            catch (Exception ex){
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteRecordFromDatabase(string masv) {
            try {
                using (myConnection = new SqlConnection(conStr)) {
                    myConnection.Open();
                    string sqlStr = "DELETE FROM tblsinhvien WHERE Masv = @Masv";
                    using (myCommand = new SqlCommand(sqlStr, myConnection)) {
                        myCommand.Parameters.AddWithValue("@Masv", masv);
                        myCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("An error occurred while deleting from the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
