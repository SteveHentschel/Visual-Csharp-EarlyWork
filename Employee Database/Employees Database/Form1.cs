using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Employees_Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Data.SqlServerCe.SqlCeConnection con;
        System.Data.SqlServerCe.SqlCeDataAdapter da;
        DataSet ds1;
        int MaxRows = 0;
        int inc = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new System.Data.SqlServerCe.SqlCeConnection();
            con.ConnectionString = "Data Source=C:\\Documents and Settings\\All\\My Documents\\VS Databases\\Employees.sdf";
            con.Open();

            ds1 = new DataSet();
            string sql = "SELECT * From tbl_employees";
            da = new System.Data.SqlServerCe.SqlCeDataAdapter(sql, con);

            da.Fill(ds1, "Workers");
            MaxRows = ds1.Tables["Workers"].Rows.Count;

            NavigateRecords();

            con.Close();
        }

        private void NavigateRecords()
        {
            DataRow dRow = ds1.Tables["Workers"].Rows[inc];
            textBox1.Text = dRow.ItemArray.GetValue(1).ToString();
            textBox2.Text = dRow.ItemArray.GetValue(2).ToString();
            textBox3.Text = dRow.ItemArray.GetValue(3).ToString();
            textBox4.Text = dRow.ItemArray.GetValue(4).ToString();
            textBox5.Clear();
            RecCount();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (inc < MaxRows - 1)
            {
                inc++;
                NavigateRecords();
            }
            else
            {
                textBox5.Text = "This is the last record ...";
            }


        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (inc > 0)
            {
                inc--;
                NavigateRecords();
            }
            else
            {
                textBox5.Text = "This is the first record ...";
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (inc != 0)
            {
                inc = 0;
                NavigateRecords();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (inc != MaxRows-1)
            {
                inc = MaxRows-1;
                NavigateRecords();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            textBox1.Focus();
            btnSave.Enabled = true;
            btnAddNew.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataRow dRow = ds1.Tables["Workers"].NewRow();

            dRow[1] = textBox1.Text;
            dRow[2] = textBox2.Text;
            dRow[3] = textBox3.Text;
            dRow[4] = textBox4.Text;
            ds1.Tables["Workers"].Rows.Add(dRow);

            UpdateDB();
            textBox5.Text = "New employee record added.";

            MaxRows = MaxRows + 1;
            inc = MaxRows - 1;

            btnAddNew.Enabled = true;
            btnSave.Enabled = false;
        }

        private void UpdateDB()
        {
            System.Data.SqlServerCe.SqlCeCommandBuilder cb;
            cb = new System.Data.SqlServerCe.SqlCeCommandBuilder(da);
            cb.DataAdapter.Update(ds1.Tables["Workers"]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dRow2 = ds1.Tables["Workers"].Rows[inc];

            dRow2[1] = textBox1.Text;
            dRow2[2] = textBox2.Text;
            dRow2[3] = textBox3.Text;
            dRow2[4] = textBox4.Text;

            UpdateDB();
            textBox5.Text = "Employee data updated.";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ds1.Tables["Workers"].Rows[inc].Delete();
            UpdateDB();

            MaxRows = ds1.Tables["Workers"].Rows.Count;
            inc--;
            NavigateRecords();
            textBox5.Text = "Employee record deleted.";
        }

        private void RecCount()
        {
            label6.Text = "< Record " + (inc+1) + " of " + MaxRows + " >";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int result = 0; 
            string searchFor = textBox6.Text;
            DataRow[] returnedRows;

            returnedRows = ds1.Tables["Workers"].Select("last_name='" + searchFor + "'");
            result = returnedRows.Length;

            if (result != 0)
            {
                DataRow dr1 = returnedRows[0];
                textBox1.Text = dr1[1].ToString();
                textBox2.Text = dr1[2].ToString();
                textBox3.Text = dr1[3].ToString();
                textBox4.Text = dr1[4].ToString();
                textBox5.Text = "Last name match was found.";
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Text = "Search record not found.";
            }
        }
    }
}
