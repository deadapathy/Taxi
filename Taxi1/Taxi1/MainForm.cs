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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clients f = new Clients();
            f.Show();
        }

        private void водителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Drivers f = new Drivers();
            f.Show();
        }

        private void диспетчерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispatcher f = new Dispatcher();
            f.Show();
        }

        private void тарифыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tariff f = new Tariff();
            f.Show();

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 f = new AboutBox1();
            f.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            // TODO: данная строка кода позволяет загрузить данные в таблицу "таксопаркDataSet.Заказы". При необходимости она может быть перемещена или удалена.
            this.заказыTableAdapter.Fill(this.таксопаркDataSet.Заказы);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            AddNewRequest f = new AddNewRequest();



            if (f.ShowDialog() == DialogResult.OK)
            {
                DateTime date;
                string OtkudaKuda, Client, Driver, NumAuto, Tariff;
                int idClient, idNumAuto, idTariff, idDispatcher, Kolvo;
                bool Status;

                date = f.dateTimePicker1.Value;
                OtkudaKuda = f.textBox7.Text;
                Client = f.comboBox3.Text;
                Tariff = f.comboBox2.Text;
                Driver = "";
                NumAuto = f.comboBox1.Text;
                Status = f.checkBox1.Checked;

                idClient = Convert.ToInt32(f.textBox1.Text);
                idNumAuto = Convert.ToInt32(f.textBox6.Text);
                idTariff = Convert.ToInt32(f.textBox2.Text);
                idDispatcher = Convert.ToInt32(f.comboBox4.Text);
                Kolvo = Convert.ToInt32(f.textBox5.Text);

                this.заказыTableAdapter.Insert(date, OtkudaKuda, Client, Driver, NumAuto, Tariff, idClient, idNumAuto, idTariff, idDispatcher, Status, Kolvo);
                this.заказыTableAdapter.Fill(таксопаркDataSet.Заказы);

            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            EditRequest f = new EditRequest();

            DateTime date;
            string OtkudaKuda, Client, Driver, NumAuto, Tariff;
            int id, idClient, idNumAuto, idTariff, idDispatcher, Kolvo, index;
            bool Status;

            if (dataGridView1.RowCount <= 1) return;
            index = dataGridView1.CurrentRow.Index;
            if (index == dataGridView1.RowCount - 1) return;

            id = (int)dataGridView1.Rows[index].Cells[0].Value;
            date = (DateTime)dataGridView1.Rows[index].Cells[1].Value;
            OtkudaKuda = (string)dataGridView1.Rows[index].Cells[2].Value;
            Client = (string)dataGridView1.Rows[index].Cells[3].Value;
            Driver = (string)dataGridView1.Rows[index].Cells[4].Value;
            NumAuto = (string)dataGridView1.Rows[index].Cells[5].Value;
            Tariff = (string)dataGridView1.Rows[index].Cells[6].Value;


            idClient = (int)dataGridView1.Rows[index].Cells[7].Value;
            idNumAuto = (int)dataGridView1.Rows[index].Cells[8].Value;
            idTariff = (int)dataGridView1.Rows[index].Cells[9].Value;
            idDispatcher = (int)dataGridView1.Rows[index].Cells[10].Value;
            Status = (bool)dataGridView1.Rows[index].Cells[11].Value;
            Kolvo = Convert.ToInt32(dataGridView1.Rows[index].Cells[12].Value);




            f.dateTimePicker1.Value = date;
            f.textBox7.Text = OtkudaKuda;
            f.comboBox3.Text = Client;
            f.comboBox1.Text = NumAuto;
            f.comboBox2.Text = Tariff;
            f.checkBox1.Checked = Convert.ToBoolean(Status);
            f.textBox5.Text = Convert.ToString(Kolvo);

            f.textBox1.Text = Convert.ToString(idClient);
            f.textBox6.Text = Convert.ToString(idNumAuto);
            f.textBox2.Text = Convert.ToString(idTariff);
            f.comboBox4.Text = Convert.ToString(idDispatcher);


            if (f.ShowDialog() == DialogResult.OK)
            {

                DateTime sdate;
                string sOtkudaKuda, sClient, sDriver, sNumAuto, sTariff;
                int sidClient, sidNumAuto, sidTariff, sidDispatcher, sKolvo;
                bool sStatus;

                sdate = f.dateTimePicker1.Value;
                sOtkudaKuda = f.textBox7.Text;
                sClient = f.comboBox3.Text;
                sDriver = "";
                sNumAuto = f.comboBox1.Text;
                sTariff = f.comboBox2.Text;
                sStatus = f.checkBox1.Checked;
                sKolvo = Convert.ToInt32(f.textBox5.Text);

                sidClient = Convert.ToInt32(f.textBox1.Text);
                sidNumAuto = Convert.ToInt32(f.textBox6.Text);
                sidTariff = Convert.ToInt32(f.textBox2.Text);
                sidDispatcher = Convert.ToInt32(f.comboBox4.Text);

                this.заказыTableAdapter.Update(sdate, sOtkudaKuda, sClient, sDriver, sNumAuto, sTariff, sidClient, sidNumAuto, sidTariff, sidDispatcher, sStatus, sKolvo,
                                                id, date, OtkudaKuda, Client, Driver, NumAuto, Tariff, idClient, idNumAuto, idTariff, idDispatcher, Status, Kolvo);
                this.заказыTableAdapter.Fill(таксопаркDataSet.Заказы);
            }


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DateTime date;
            string OtkudaKuda, Client, Driver, NumAuto, Tariff;
            int id, idClient, idNumAuto, idTariff, idDispatcher, Kolvo, index;
            bool Status;

            index = dataGridView1.CurrentRow.Index;

            id = (int)dataGridView1.Rows[index].Cells[0].Value;
            date = (DateTime)dataGridView1.Rows[index].Cells[1].Value;
            OtkudaKuda = (string)dataGridView1.Rows[index].Cells[2].Value;
            Client = (string)dataGridView1.Rows[index].Cells[3].Value;
            Driver = (string)dataGridView1.Rows[index].Cells[4].Value;
            NumAuto = (string)dataGridView1.Rows[index].Cells[5].Value;
            Tariff = (string)dataGridView1.Rows[index].Cells[6].Value;


            idClient = (int)dataGridView1.Rows[index].Cells[7].Value;
            idNumAuto = (int)dataGridView1.Rows[index].Cells[8].Value;
            idTariff = (int)dataGridView1.Rows[index].Cells[9].Value;
            idDispatcher = (int)dataGridView1.Rows[index].Cells[10].Value;
            Status = (bool)dataGridView1.Rows[index].Cells[11].Value;
            Kolvo = Convert.ToInt32(dataGridView1.Rows[index].Cells[12].Value);

            if (MessageBox.Show("Вы действительно хотите удалить данную строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.заказыTableAdapter.Delete(id, date, OtkudaKuda, Client, Driver, NumAuto, Tariff, idClient, idNumAuto, idTariff, idDispatcher, Status, Kolvo);
                this.заказыTableAdapter.Fill(таксопаркDataSet.Заказы);
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application Excel = new Application();
            XlReferenceStyle RefStyle = new XlReferenceStyle();
            Excel.Visible = true;
            Workbook wb = null;
            String TemplatePath = System.Windows.Forms.Application.StartupPath + @"\Шаблоны\Водители.xlsx";
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
            ReleaseExcel(Excel as Object);
        }
        private void ReleaseExcel(object excel)
        {
            // Дестрой зис щит
            Marshal.ReleaseComObject(excel);
            // Вызываем мусорку
            GC.GetTotalMemory(true);
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                заказыBindingSource.Filter = String.Format("[Дата заказа] >= '{0}'", dateTimePicker1.Value.ToString("dd.MM.yyyy"));
            }
            else if (checkBox1.Checked == false)
            {
                заказыBindingSource.Filter = string.Empty;
            }
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
          
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Клиент") 
            {
                заказыBindingSource.Filter = "Клиент LIKE '" + textBox1.Text + "%'";
            }
            else if (comboBox1.Text == "Номер авто")
            {
                заказыBindingSource.Filter = "[Номер авто] LIKE '" + textBox1.Text + "%'";
            }
            else if (comboBox1.Text == "Тариф")
            {
                заказыBindingSource.Filter = "Тариф LIKE '" + textBox1.Text + "%'";
            }
            else if (comboBox1.Text == "Откуда-Куда")
            {
                заказыBindingSource.Filter = "[Откуда-Куда] LIKE '" + textBox1.Text + "%'";
            }
        }

        private void настройкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

       

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }


} 

