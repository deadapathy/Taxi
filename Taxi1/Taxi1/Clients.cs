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
    }
}
