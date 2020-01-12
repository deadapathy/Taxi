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
using Microsoft.Office.Interop.Excel;
namespace Taxi1
{
    public partial class Dispatcher : Form
    {
        public Dispatcher()
        {
            InitializeComponent();
        }

        private void Dispatcher_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "таксопаркDataSet.Диспетчеры". При необходимости она может быть перемещена или удалена.
            this.диспетчерыTableAdapter.Fill(this.таксопаркDataSet.Диспетчеры);

        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewDispatcher f = new AddNewDispatcher();
            try
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    string Sname, Name, Lname, Telephone;

                    Sname = f.textBox1.Text;
                    Name = f.textBox2.Text;
                    Lname = f.textBox3.Text;
                    Telephone = f.textBox4.Text;

                    this.диспетчерыTableAdapter.Insert(Sname, Name, Lname, Telephone);
                    this.диспетчерыTableAdapter.Fill(таксопаркDataSet.Диспетчеры);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка");
            }
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EditDispatcher f = new EditDispatcher();
                string Sname, Name, Lname, Telephone;
                int id, index;

                if (dataGridView1.RowCount <= 1) return;
                index = dataGridView1.CurrentRow.Index;
                if (index == dataGridView1.RowCount - 1) return;

                id = (int)dataGridView1.Rows[index].Cells[0].Value;
                Sname = (string)dataGridView1.Rows[index].Cells[1].Value;
                Name = (string)dataGridView1.Rows[index].Cells[2].Value;
                Lname = (string)dataGridView1.Rows[index].Cells[3].Value;
                Telephone = (string)dataGridView1.Rows[index].Cells[4].Value;

                f.textBox1.Text = Sname;
                f.textBox2.Text = Name;
                f.textBox3.Text = Lname;
                f.textBox4.Text = Telephone;

                if (f.ShowDialog() == DialogResult.OK)
                {
                    string sSname, sName, sLname, sTelephone;

                    sSname = f.textBox1.Text;
                    sName = f.textBox2.Text;
                    sLname = f.textBox3.Text;
                    sTelephone = f.textBox4.Text;

                    this.диспетчерыTableAdapter.Update(sSname, sName, sLname, sTelephone, id, Sname, Name, Lname, Telephone);
                    this.диспетчерыTableAdapter.Fill(таксопаркDataSet.Диспетчеры);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка");
            }
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string Sname, Name, Lname, Telephone;
                int id, index;

                index = dataGridView1.CurrentRow.Index;

                id = (int)dataGridView1.Rows[index].Cells[0].Value;
                Sname = (string)dataGridView1.Rows[index].Cells[1].Value;
                Name = (string)dataGridView1.Rows[index].Cells[2].Value;
                Lname = (string)dataGridView1.Rows[index].Cells[3].Value;
                Telephone = (string)dataGridView1.Rows[index].Cells[4].Value;

                if (MessageBox.Show("Вы дейсвительно хотите удалить данную строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.диспетчерыTableAdapter.Delete(id, Sname, Name, Lname, Telephone);
                    this.диспетчерыTableAdapter.Fill(таксопаркDataSet.Диспетчеры);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка");
            }
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            диспетчерыTableAdapter.Update(таксопаркDataSet.Диспетчеры);
            MessageBox.Show("Данные сохранены");
        }

        private void exToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application Excel = new Application();
            XlReferenceStyle RefStyle = new XlReferenceStyle();
            Excel.Visible = true;
            Workbook wb = null;
            String TemplatePath = System.Windows.Forms.Application.StartupPath + @"\Водители.xlsx";
            try
            {
                wb = Excel.Workbooks.Add(TemplatePath);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загурзить шаблон");

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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Фамилия")
                {
                    диспетчерыBindingSource.Filter = "Фамилия LIKE '" + textBox1.Text + "%'";
                }
                else if (comboBox1.Text == "Имя")
                {
                    диспетчерыBindingSource.Filter = "Имя LIKE '" + textBox1.Text + "%'";
                }
                else if (comboBox1.Text == "Телефон")
                {
                    диспетчерыBindingSource.Filter = "Телефон LIKE '" + textBox1.Text + "%'";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка");
            }
        }
    }
}
