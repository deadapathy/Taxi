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
    public partial class Tariff : Form
    {
        public Tariff()
        {
            InitializeComponent();
        }

        private void Tariff_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "таксопаркDataSet.Тарифы". При необходимости она может быть перемещена или удалена.
            this.тарифыTableAdapter.Fill(this.таксопаркDataSet.Тарифы);

        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Name;
            int Cost;

            AddNewTariff f = new AddNewTariff();

            if(f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Name = f.textBox1.Text;
                    Cost = Convert.ToInt32(f.textBox2.Text);

                    this.тарифыTableAdapter.Insert(Name, Cost);
                    this.тарифыTableAdapter.Fill(this.таксопаркDataSet.Тарифы);
                }
                catch(Exception)
                {
                    MessageBox.Show("Произошла ошибка");
                }
            }
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditTariff f = new EditTariff();

            string Name;
            int id, index, Cost;

            if (dataGridView1.RowCount <= 1) return;
            index = dataGridView1.CurrentRow.Index;
            if (index == dataGridView1.RowCount - 1) return;

            id = (int)dataGridView1.Rows[index].Cells[0].Value;
            Name = (string)dataGridView1.Rows[index].Cells[1].Value;
            Cost = (int)dataGridView1.Rows[index].Cells[2].Value;

            f.textBox1.Text = Name;
            f.textBox2.Text = Convert.ToString(Cost);

            if(f.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string sName;
                    int sCost;

                    sName = f.textBox1.Text;
                    sCost = Convert.ToInt32(f.textBox2.Text);

                    this.тарифыTableAdapter.Update(sName, sCost, id, Name, Cost);
                    this.тарифыTableAdapter.Fill(таксопаркDataSet.Тарифы);
                }
                catch (Exception)
                {
                    MessageBox.Show("Произоша ошибка");
                }
            }


        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Name;
            int Cost, index, id;

            index = dataGridView1.CurrentRow.Index;

            id = (int)dataGridView1.Rows[index].Cells[0].Value;
            Name = (string)dataGridView1.Rows[index].Cells[1].Value;
            Cost = (int)dataGridView1.Rows[index].Cells[2].Value;

            if(MessageBox.Show("Вы действительно хотите удалить данную строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.тарифыTableAdapter.Delete(id, Name, Cost);
                this.тарифыTableAdapter.Fill(таксопаркDataSet.Тарифы);
            }
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.тарифыTableAdapter.EndEdit();
            this.тарифыTableAdapter.Update(таксопаркDataSet.Тарифы);
            MessageBox.Show("Данные сохранены");
        }
    }
}
