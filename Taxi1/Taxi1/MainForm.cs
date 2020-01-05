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
    }
}
