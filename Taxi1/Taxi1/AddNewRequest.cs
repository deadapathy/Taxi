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
    public partial class AddNewRequest : Form
    {
        public AddNewRequest()
        {
            InitializeComponent();
        }

        private void AddNewRequest_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "таксопаркDataSet.Диспетчеры". При необходимости она может быть перемещена или удалена.
            this.диспетчерыTableAdapter.Fill(this.таксопаркDataSet.Диспетчеры);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "таксопаркDataSet.Тарифы". При необходимости она может быть перемещена или удалена.
            this.тарифыTableAdapter.Fill(this.таксопаркDataSet.Тарифы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "таксопаркDataSet.Авто". При необходимости она может быть перемещена или удалена.
            this.автоTableAdapter.Fill(this.таксопаркDataSet.Авто);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "таксопаркDataSet.Водители". При необходимости она может быть перемещена или удалена.
            this.водителиTableAdapter.Fill(this.таксопаркDataSet.Водители);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "таксопаркDataSet.Клиенты". При необходимости она может быть перемещена или удалена.
            this.клиентыTableAdapter.Fill(this.таксопаркDataSet.Клиенты);

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
