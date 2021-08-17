using Sistema_Vendas.UiForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Vendas
{
    public partial class frmUserDashboard : Form
    {
        public frmUserDashboard()
        {
            InitializeComponent();
        }
        public static string transactionType;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comprarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmVendas vendas = new frmVendas();
            vendas.Show();
            
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transactionType = "compras";
            frmVendas sale = new frmVendas();
            sale.Show();
            
        }

        private void frmUserDashboard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
