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
    public partial class Auto : Form
    {
        public Auto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Auto_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "таксопаркDataSet.Авто". При необходимости она может быть перемещена или удалена.
            this.автоTableAdapter.Fill(this.таксопаркDataSet.Авто);

        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            AddNewAuto f = new AddNewAuto();

            if(f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string NumAuto, Mark, Color;
                    int idDriver;

                    NumAuto = f.textBox5.Text;
                    Mark = f.textBox6.Text;
                    Color = f.textBox7.Text;
                    idDriver = Convert.ToInt32(f.textBox8.Text);

                    this.автоTableAdapter.Insert(NumAuto, Mark, Color, idDriver);
                    this.автоTableAdapter.Fill(таксопаркDataSet.Авто);
                }
                catch (Exception)
                {
                    MessageBox.Show("Произошла ошибка");
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditAuto f = new EditAuto();

            string NumAuto, Mark, Color;
            int index, id, idDriver;

            if (dataGridView2.RowCount <= 1) return;
            index = dataGridView2.CurrentRow.Index;
            if (index == dataGridView2.RowCount - 1) return;

            id = (int)dataGridView2.Rows[index].Cells[0].Value;
            NumAuto = (string)dataGridView2.Rows[index].Cells[1].Value;
            Mark = (string)dataGridView2.Rows[index].Cells[2].Value;
            Color = (string)dataGridView2.Rows[index].Cells[3].Value;
            idDriver = (int)dataGridView2.Rows[index].Cells[4].Value;

            f.textBox5.Text = NumAuto;
            f.textBox6.Text = Mark;
            f.textBox7.Text = Color;
            f.textBox8.Text = Convert.ToString(idDriver);

            if(f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string sNumAuto, sMark, sColor;
                    int sidDriver;

                    sNumAuto = f.textBox5.Text;
                    sMark = f.textBox6.Text;
                    sColor = f.textBox7.Text;
                    sidDriver = Convert.ToInt32(f.textBox8.Text);

                    this.автоTableAdapter.Update(sNumAuto, sMark, sColor, sidDriver, id, NumAuto, Mark, Color, idDriver);
                    this.автоTableAdapter.Fill(таксопаркDataSet.Авто);
                }
                catch (Exception)
                {
                    MessageBox.Show("Произошла ошибка");
                }
            }
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string NumAuto, Mark, Color;
                int index, id, idDriver;

                index = dataGridView2.CurrentRow.Index;

                id = (int)dataGridView2.Rows[index].Cells[0].Value;
                NumAuto = (string)dataGridView2.Rows[index].Cells[1].Value;
                Mark = (string)dataGridView2.Rows[index].Cells[2].Value;
                Color = (string)dataGridView2.Rows[index].Cells[3].Value;
                idDriver = (int)dataGridView2.Rows[index].Cells[4].Value;

                if (MessageBox.Show("Вы действительно хотите удалить данную строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.автоTableAdapter.Delete(id, NumAuto, Mark, Color, idDriver);
                    this.автоTableAdapter.Fill(таксопаркDataSet.Авто);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка");
            }
        }

        private void eToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application Excel = new Application();
            XlReferenceStyle RefStyle = new XlReferenceStyle();
            Excel.Visible = true;
            Workbook wb = null;
            String TemplatePath = System.Windows.Forms.Application.StartupPath + @"\Шаблоны\Автопарк.xlsx";
            try
            {
                wb = Excel.Workbooks.Add(TemplatePath);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загурзить шаблон");

            }
            Worksheet ws = wb.Worksheets.get_Item(1) as Worksheet;
            for (int j = 0; j < dataGridView2.Columns.Count; ++j)
            {
                (ws.Cells[1, j + 1] as Range).Value2 = dataGridView2.Columns[j].HeaderText;
                for (int i = 0; i < dataGridView2.Rows.Count; ++i)
                {
                    object Val = dataGridView2.Rows[i].Cells[j].Value;
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

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.автоTableAdapter.Update(таксопаркDataSet.Авто);
            MessageBox.Show("Данные сохранены");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Номер авто")
                {
                    автоBindingSource.Filter = "[Номер авто] LIKE '" + textBox3.Text + "%'";
                }
                else if (comboBox1.Text == "Марка")
                {
                    автоBindingSource.Filter = "Марка LIKE '" + textBox3.Text + "%'";
                }
                else if (comboBox1.Text == "Цвет")
                {
                    автоBindingSource.Filter = "Цвет LIKE '" + textBox3.Text + "%'";
                }
               
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка");
            }
        }
    }
}
