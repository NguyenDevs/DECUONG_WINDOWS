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
using System.Globalization;

namespace Câu_3._11
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
        private void Display(DateTime fromDate, DateTime toDate)
        {
            string sqlStr = "SELECT tblhangnhap.Mahang, Tenhang, Donvitinh, SUM(Soluongban) AS soluongban " +
                            "FROM tblhangnhap " +
                            "INNER JOIN tblChitiethd ON tblhangnhap.Mahang = tblChitiethd.Mahang " +
                            "INNER JOIN tbldonhangban ON tblChitiethd.Sohd = tbldonhangban.Sohd " +
                            "WHERE Ngayban BETWEEN @FromDate AND @ToDate " +
                            "GROUP BY tblhangnhap.Mahang, Tenhang, Donvitinh";
            using (myDataAdapter = new SqlDataAdapter(sqlStr, conStr))
            {
                myDataAdapter.SelectCommand.Parameters.AddWithValue("@FromDate", fromDate);
                myDataAdapter.SelectCommand.Parameters.AddWithValue("@ToDate", toDate);
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
                    myTable.Rows[currentIndex]["Mahang"].ToString();
                    myTable.Rows[currentIndex]["Tenhang"].ToString();
                    myTable.Rows[currentIndex]["Donvitinh"].ToString();
                    myTable.Rows[currentIndex]["soluongban"].ToString();
                    dataGridView1.Rows[index].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void btn_thuchien_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = date_tungay.Value;
                DateTime toDate = date_denngay.Value;
                Display(fromDate, toDate);
                MoveToRow(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
