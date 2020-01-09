using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

           

            if(f.ShowDialog() == DialogResult.OK)
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

            if(MessageBox.Show("Вы действительно хотите удалить данную строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.заказыTableAdapter.Delete(id, date, OtkudaKuda, Client, Driver, NumAuto, Tariff, idClient, idNumAuto, idTariff, idDispatcher, Status, Kolvo);
                this.заказыTableAdapter.Fill(таксопаркDataSet.Заказы);
            }

        }
    }

       
}

