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
    public partial class Drivers : Form
    {
        public Drivers()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewDriver f = new AddNewDriver();
            if (f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string Sname, Name, Lname, Telephone;
                    bool Status;
                    string NumAuto, Marka, Color;
                    int idDrive;

                    Sname = f.textBox1.Text;
                    Name = f.textBox2.Text;
                    Lname = f.textBox3.Text;
                    Telephone = f.textBox4.Text;
                    Status = f.checkBox1.Checked;

                    NumAuto = f.textBox5.Text;
                    Marka = f.textBox6.Text;
                    Color = f.textBox7.Text;
                    idDrive = Convert.ToInt32(f.textBox8.Text);

                    this.водителиTableAdapter.Insert(Sname, Name, Lname, Telephone, Status);
                    this.водителиTableAdapter.Fill(таксопаркDataSet1.Водители);

                    this.автоTableAdapter.Insert(NumAuto, Marka, Color, idDrive);
                    this.автоTableAdapter.Fill(таксопаркDataSet1.Авто);
                }
                catch(Exception)
                {
                    MessageBox.Show("Произошла ошибка");
                }
            }
        }

        private void Drivers_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "таксопаркDataSet1.Авто". При необходимости она может быть перемещена или удалена.
            this.автоTableAdapter.Fill(this.таксопаркDataSet1.Авто);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "таксопаркDataSet1.Водители". При необходимости она может быть перемещена или удалена.
            this.водителиTableAdapter.Fill(this.таксопаркDataSet1.Водители);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditDriver f = new EditDriver();

            string Sname, Name, Lname, Telephone, NumAuto, Marka, Color;
            int Id, idDriver, index, index1, idAuto;
            bool Status;

            if (dataGridView1.RowCount <= 1) return;
            index = dataGridView1.CurrentRow.Index;
            if (index == dataGridView1.RowCount - 1) return;

            if (dataGridView2.RowCount <= 1) return;
            index1 = dataGridView2.CurrentRow.Index;
            if (index1 == dataGridView2.RowCount - 1) return;

            Id = (int)dataGridView1.Rows[index].Cells[0].Value;
            Sname = (string)dataGridView1.Rows[index].Cells[1].Value;
            Name = (string)dataGridView1.Rows[index].Cells[2].Value;
            Lname = (string)dataGridView1.Rows[index].Cells[3].Value;
            Telephone = (string)dataGridView1.Rows[index].Cells[4].Value;
            Status = (bool)dataGridView1.Rows[index].Cells[5].Value;

            idAuto = (int)dataGridView2.Rows[index1].Cells[0].Value;
            NumAuto = (string)dataGridView2.Rows[index1].Cells[1].Value;
            Marka = (string)dataGridView2.Rows[index1].Cells[2].Value;
            Color = (string)dataGridView2.Rows[index1].Cells[3].Value;
            idDriver = (int)dataGridView2.Rows[index1].Cells[4].Value;

            f.textBox1.Text = Sname;
            f.textBox2.Text = Name;
            f.textBox3.Text = Lname;
            f.textBox4.Text = Telephone;
            f.checkBox1.Checked = Status;

            f.textBox5.Text = NumAuto;
            f.textBox6.Text = Marka;
            f.textBox7.Text = Color;
            f.textBox8.Text = Convert.ToString(idDriver);
            

            if(f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string sSname, sName, sLname, sTelephone, sNumAuto, sMarka, sColor;
                    bool sStatus;
                    int sidDriver;

                    sSname = f.textBox1.Text;
                    sName = f.textBox2.Text;
                    sLname = f.textBox3.Text;
                    sTelephone = f.textBox4.Text;

                    sNumAuto = f.textBox5.Text;
                    sMarka = f.textBox6.Text;
                    sColor = f.textBox7.Text;
                    sidDriver = Convert.ToInt32(f.textBox8.Text);
                    sStatus = f.checkBox1.Checked;

                    this.водителиTableAdapter.Update(sSname, sName, sLname, sTelephone, sStatus, Id, Sname, Name, Lname, Telephone, Status);
                    this.водителиTableAdapter.Fill(таксопаркDataSet1.Водители);

                    this.автоTableAdapter.Update(sNumAuto, sMarka, sColor, sidDriver, idAuto, NumAuto, Marka, Color, idDriver);
                    this.автоTableAdapter.Fill(таксопаркDataSet1.Авто);
                }
                catch(Exception)
                {
                    MessageBox.Show("Произошла ошибка");
                }
            }

        }

        private void kToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Sname, Name, Lname, Telephone, NumAuto, Marka, Color;
            int id, idAuto, idDriver, index, index1;
            bool Status;

            try
            {
                if (dataGridView2.RowCount <= 1) return;
                index = dataGridView1.CurrentRow.Index;
                index1 = dataGridView2.CurrentRow.Index;
                if (index1 == dataGridView2.RowCount - 1) return;


                id = (int)dataGridView1.Rows[index].Cells[0].Value;
                Sname = (string)dataGridView1.Rows[index].Cells[1].Value;
                Name = (string)dataGridView1.Rows[index].Cells[2].Value;
                Lname = (string)dataGridView1.Rows[index].Cells[3].Value;
                Telephone = (string)dataGridView1.Rows[index].Cells[4].Value;
                Status = (bool)dataGridView1.Rows[index].Cells[5].Value;

                idAuto = (int)dataGridView2.Rows[index1].Cells[0].Value;
                NumAuto = (string)dataGridView2.Rows[index1].Cells[1].Value;
                Marka = (string)dataGridView2.Rows[index1].Cells[2].Value;
                Color = (string)dataGridView2.Rows[index1].Cells[3].Value;
                idDriver = (int)dataGridView2.Rows[index1].Cells[4].Value;

                if (MessageBox.Show("Вы действительно хотите удалить данную строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.водителиTableAdapter.Delete(id, Sname, Name, Lname, Telephone, Status);
                    this.водителиTableAdapter.Fill(таксопаркDataSet1.Водители);

                    this.автоTableAdapter.Delete(idAuto, NumAuto, Marka, Color, idDriver);
                    this.автоTableAdapter.Fill(таксопаркDataSet1.Авто);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Произошла ошибка");
            }

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
            this.автоTableAdapter.EndEdit();
            this.автоTableAdapter.Update(таксопаркDataSet1.Авто);
            MessageBox.Show("Данные сохранены!");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Application Excel = new Application();
            XlReferenceStyle RefStyle = new XlReferenceStyle();
            Excel.Visible = true;
            Workbook wb = null;
            String TemplatePath = System.Windows.Forms.Application.StartupPath + @"\Авто.xlsx";
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text == "Фамилия")
                {
                    водителиBindingSource.Filter = "Фамилия LIKE '" + textBox1.Text + "%'";
                }
                else if (comboBox2.Text == "Имя")
                {
                    водителиBindingSource.Filter = "Имя LIKE '" + textBox1.Text + "%'";
                }
                else if (comboBox2.Text == "Телефон")
                {
                    водителиBindingSource.Filter = "Телефон LIKE '" + textBox1.Text + "%'";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int id, index;

            index = dataGridView1.CurrentRow.Index;

            id = (int)dataGridView1.Rows[index].Cells[0].Value;
            автоBindingSource.Filter = "[Код водителя] = " + id.ToString();
           

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int id, index;

            index = dataGridView1.CurrentRow.Index;

            id = (int)dataGridView1.Rows[index].Cells[0].Value;
            автоBindingSource.Filter = "[Код водителя] = " + id.ToString();
        }
    }
}
