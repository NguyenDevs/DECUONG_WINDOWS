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

namespace Câu_3._8
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
            string sqlStr = "SELECT * FROM tblkhach";
            using (myDataAdapter = new SqlDataAdapter(sqlStr, conStr))
            {
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "daotao");
                myTable = myDataSet.Tables["daotao"];
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoGenerateColumns = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
        }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= myTable.Rows.Count)
                row = myTable.Rows.Count - 1;
            else
            {
                MoveToRow(row);
            }
        }
        private int currentIndex = 0;
        private void MoveToRow(int index)
        {
            try
            {
                if (index >= 0 && index < myTable.Rows.Count)
                {
                    currentIndex = index;
                    txt_makh.Text = myTable.Rows[currentIndex]["MaKH"].ToString();
                    txt_hoten.Text = myTable.Rows[currentIndex]["HoTen"].ToString();
                    txt_diachi.Text = myTable.Rows[currentIndex]["Diachi"].ToString();
                    txt_dienthoai.Text = myTable.Rows[currentIndex]["Dienthoai"].ToString();
                    dataGridView1.Rows[index].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void btn_first_Click(object sender, EventArgs e)
        {
            MoveToRow(0);
        }
        private void btn_previous_Click(object sender, EventArgs e)
        {
            MoveToRow(currentIndex - 1);
        }
        private void btn_next_Click(object sender, EventArgs e)
        {
            if (currentIndex < myTable.Rows.Count - 1)
                MoveToRow(currentIndex + 1);

        }
        private void btn_last_Click(object sender, EventArgs e)
        {
            MoveToRow(myTable.Rows.Count - 1);
        }
        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string maKH = txt_makh.Text;
                    string hoTen = txt_hoten.Text;
                    string diaChi = txt_diachi.Text;
                    string dienThoai = txt_dienthoai.Text;
                    string sqlUpdate = "UPDATE tblkhach SET HoTen = @HoTen, Diachi = @DiaChi, Dienthoai = @DienThoai WHERE MaKH = @MaKH";
                    using (myConnection = new SqlConnection(conStr))  {
                        myConnection.Open();
                        using (myCommand = new SqlCommand(sqlUpdate, myConnection)) {
                            myCommand.Parameters.AddWithValue("@HoTen", hoTen);
                            myCommand.Parameters.AddWithValue("@DiaChi", diaChi);
                            myCommand.Parameters.AddWithValue("@DienThoai", dienThoai);
                            myCommand.Parameters.AddWithValue("@MaKH", maKH);
                            int rowsAffected = myCommand.ExecuteNonQuery();
                            if (rowsAffected > 0) {
                                MessageBox.Show("Dữ liệu đã được cập nhật thành công.");
                                Display();
                                MoveToRow(currentIndex);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hàng để sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
            }
        }
    }
}
