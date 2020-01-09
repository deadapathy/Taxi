using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Taxi1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Mex\Desktop\Таксопарк\Taxi1\Taxi1\bin\Debug\Таксопарк.accdb");
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT COUNT(*) FROM Пользователи where Логин = '" + textBox1.Text + "' and Пароль = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                MainForm f = new MainForm();
                f.Show();
            }

            else
            {
                MessageBox.Show("Неверные логин или пароль. Пожалуйста, проверьте их и повторите попытку");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewUser f = new NewUser();
            if(f.ShowDialog() == DialogResult.OK)
            {
                string login, pass;

                login = f.textBox1.Text;
                pass = f.textBox2.Text;

                this.пользователиTableAdapter.Insert(login, pass);
                this.пользователиTableAdapter.Fill(таксопаркDataSet.Пользователи);

                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "таксопаркDataSet.Пользователи". При необходимости она может быть перемещена или удалена.
            this.пользователиTableAdapter.Fill(this.таксопаркDataSet.Пользователи);

        }

        
    }
}
