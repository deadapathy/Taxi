using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop;



namespace Taxi1
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewClient f = new AddNewClient();

            if(f.ShowDialog() == DialogResult.OK)
            {
                string Sname, Name, Lname, Telephone, OtkudaKuda;

                Sname = f.textBox1.Text;
                Name = f.textBox2.Text;
                Lname = f.textBox3.Text;
                Telephone = f.textBox4.Text;
                OtkudaKuda = f.textBox5.Text;

                this.клиентыTableAdapter.Insert(Sname, Name, Lname, Telephone, OtkudaKuda);
                this.клиентыTableAdapter.Fill(this.таксопаркDataSet.Клиенты);
            }
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "таксопаркDataSet.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this.таксопаркDataSet.Клиенты);
            comboBox1.SelectedIndex = 1;

        }

        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditClient f = new EditClient();

            string Sname, Name, Lname, Telephone, OtkudaKuda;
            int id, index;

            if (dataGridView1.RowCount <= 1) return;
            index = dataGridView1.CurrentRow.Index;
            if (index == dataGridView1.RowCount - 1) return;

            id = (int)dataGridView1.Rows[index].Cells[0].Value;
            Sname = (string)dataGridView1.Rows[index].Cells[1].Value;
            Name = (string)dataGridView1.Rows[index].Cells[2].Value;
            Lname = (string)dataGridView1.Rows[index].Cells[3].Value;
            Telephone = (string)dataGridView1.Rows[index].Cells[4].Value;
            OtkudaKuda = (string)dataGridView1.Rows[index].Cells[5].Value;

            f.textBox1.Text = Sname;
            f.textBox2.Text = Name;
            f.textBox3.Text = Lname;
            f.textBox4.Text = Telephone;
            f.textBox5.Text = OtkudaKuda;

            if(f.ShowDialog() == DialogResult.OK)
            {
                string sSname, sName, sLname, sTelephone, sOtkudaKuda;

                sSname = f.textBox1.Text;
                sName = f.textBox2.Text;
                sLname = f.textBox3.Text;
                sTelephone = f.textBox4.Text;
                sOtkudaKuda = f.textBox5.Text;


                this.клиентыTableAdapter.Update(sSname, sName, sLname, sTelephone, sOtkudaKuda, id, Sname, Name, Lname, Telephone, OtkudaKuda);
                this.клиентыTableAdapter.Fill(таксопаркDataSet.Клиенты);
            }

        }

        private void kToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string Sname, Name, Lname, Telephone, OtkudaKuda;
                int id, index;

                index = dataGridView1.CurrentRow.Index;

                id = (int)dataGridView1.Rows[index].Cells[0].Value;
                Sname = (string)dataGridView1.Rows[index].Cells[1].Value;
                Name = (string)dataGridView1.Rows[index].Cells[2].Value;
                Lname = (string)dataGridView1.Rows[index].Cells[3].Value;
                Telephone = (string)dataGridView1.Rows[index].Cells[4].Value;
                OtkudaKuda = (string)dataGridView1.Rows[index].Cells[5].Value;

                if (MessageBox.Show("Вы действительно хотите удалить данную строку?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.клиентыTableAdapter.Delete(id, Sname, Name, Lname, Telephone, OtkudaKuda);
                    this.клиентыTableAdapter.Fill(таксопаркDataSet.Клиенты);
                }
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Невозможно удалить пустую строку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.клиентыTableAdapter.Update(таксопаркDataSet.Клиенты);
            MessageBox.Show("Данные сохранены");
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application Excel = new Application();
            XlReferenceStyle RefStyle = Excel.ReferenceStyle;
            Excel.Visible = true;
            Workbook wb = null;
            String TemplatePath = System.Windows.Forms.Application.StartupPath + @"\Клиенты.xlsx";
            try
            {
                wb = Excel.Workbooks.Add(TemplatePath); // !!! 
            }
            catch (System.Exception ex)
            {
                throw new Exception("Не удалось загрузить шаблон для экспорта " + TemplatePath + "\n" + ex.Message);
            }
            Worksheet ws = wb.Worksheets.get_Item(1) as Worksheet;
            for (int j = 0; j < dataGridView1.Columns.Count; ++j)
            {
                (ws.Cells[1, j + 1] as Range).Value2 = dataGridView1.Columns[j].HeaderText;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    object Val = dataGridView1.Rows[i].Cells[j].Value;
                    if (Val != null)
                        (ws.Cells[i + 2, j + 1] as Range).Value2 = Val.ToString();
                }
            }
            ws.Columns.EntireColumn.AutoFit();
            Excel.ReferenceStyle = RefStyle;
            ReleaseExcel(Excel as Object);
        }
        private void ReleaseExcel(object excel)
        {
            // Дестрой зис щит
            Marshal.ReleaseComObject(excel);
            // Вызываем мусорку
            GC.GetTotalMemory(true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
                if(comboBox1.Text == "Фамилия")
            {
                клиентыBindingSource.Filter = "Фамилия LIKE '" + textBox1.Text + "%'";
            }
                else if (comboBox1.Text == "Имя")
            {
                клиентыBindingSource.Filter = "Имя LIKE '" + textBox1.Text + "%'";
            }
                else if (comboBox1.Text == "Телефон")
            {
                клиентыBindingSource.Filter = "Телефон LIKE '" + textBox1.Text + "%'";
            }
            
        }
    }
}
