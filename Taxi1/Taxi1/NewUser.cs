using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi1.ТаксопаркDataSetTableAdapters;

namespace Taxi1
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.пользователиTableAdapter.Update(this.таксопаркDataSet.Пользователи);
            this.Hide();
           
            MessageBox.Show("Регистрация завершена");
        }


        private void NewUser_Load(object sender, EventArgs e)
        {

        }
    }
}
