using Sistema_Vendas.UiForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_Vendas.BLLClasses;
using Sistema_Vendas.DALdados;

namespace Sistema_Vendas
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
        }
        CaixaDAL caixaDAL = new CaixaDAL();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers user = new frmUsers();
            user.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria categoria = new frmCategoria();
            categoria.Show();

        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            //setar usuario logado no textbox
            
            //label4.Text = caixaDAL.Search();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.lblLoggedInUser.Text = datetime.ToString();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducts DeaCust = new frmProducts();
            DeaCust.Show();

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeaCust DeaCust = new frmDeaCust();
            DeaCust.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usuáriosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmUsers DeaCust = new frmUsers();
            DeaCust.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void categoriaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmCategoria DeaCust = new frmCategoria();
            DeaCust.Show();
        }

        private void produtosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmProducts DeaCust = new frmProducts();
            DeaCust.Show();
        }

        private void transaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendas DeaCust = new frmVendas();
            DeaCust.Show();
        }

        private void clienteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDeaCust DeaCust = new frmDeaCust();
            DeaCust.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
