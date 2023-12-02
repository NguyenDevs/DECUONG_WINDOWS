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

namespace Câu_3._7
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
        Initial Catalog=QLSV;Persist Security Info=True;User ID=sa;Password=Blacksmith@0407";
        private void Display()
        {
            string sqlStr = "SELECT * FROM tbldiemmon";
            using (myDataAdapter = new SqlDataAdapter(sqlStr, conStr))
            {
                myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet, "daotao");
                myTable = myDataSet.Tables["daotao"];
                dataGridView1.DataSource = myTable;
                dataGridView1.AutoGenerateColumns = false;
            }
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
                    txt_masv.Text = myTable.Rows[currentIndex]["MaSV"].ToString();
                    txt_hoten.Text = myTable.Rows[currentIndex]["HoTen"].ToString();
                    txt_diemthi.Text = myTable.Rows[currentIndex]["DiemThi"].ToString();
                    txt_diembp.Text = myTable.Rows[currentIndex]["DiemBP"].ToString();
                    txt_diemhp.Text = myTable.Rows[currentIndex]["DiemHP"].ToString();
                    dataGridView1.Rows[index].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Display();
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

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int pos = dataGridView1.CurrentRow.Index;
                string masvToDelete = myTable.Rows[pos]["MaSV"].ToString();
                DeleteRecordFromDatabase(masvToDelete);
                myTable.Rows[pos].Delete();
                Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteRecordFromDatabase(string masv)
        {
            try
            {
                using (myConnection = new SqlConnection(conStr))
                {
                    myConnection.Open();
                    string sqlStr = "DELETE FROM tbldiemmon WHERE Masv = @Masv";
                    using (myCommand = new SqlCommand(sqlStr, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@Masv", masv);
                        myCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting from the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlStr = "SELECT * FROM tbldiemmon WHERE DiemHP >= 8";
                using (myDataAdapter = new SqlDataAdapter(sqlStr, conStr))
                {
                    myDataSet = new DataSet();
                    myDataAdapter.Fill(myDataSet, "daotao");
                    myTable = myDataSet.Tables["daotao"];
                    dataGridView1.DataSource = myTable;
                    dataGridView1.AutoGenerateColumns = false;
                    if (myTable.Rows.Count > 0)
                    {
                        MoveToRow(0);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
