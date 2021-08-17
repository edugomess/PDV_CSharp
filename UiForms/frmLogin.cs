using Sistema_Vendas.BLLClasses;
using Sistema_Vendas.DALdados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Vendas.UiForms
{
    
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        LoginBLL l = new LoginBLL();
        LoginDAL dal = new LoginDAL();
        CaixaDAL dal1 = new CaixaDAL();


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            l.username = txtLogin.Text.Trim();
            l.password = txtSenha.Text.Trim();
            l.user_type = cmbUserType.Text.Trim();

            bool Sucess = dal.LoginCheck(l);
            if(Sucess == true)
            {
                MessageBox.Show("Login feito com sucesso");
                switch (l.user_type)
                {
                   case "Administrador":
                        {
                            frmAdminDashboard admin = new frmAdminDashboard();
                            admin.Show();

                            this.Hide();
                        }
                        break;
                    case "Normal":
                        {
                            frmUserDashboard user = new frmUserDashboard();
                            user.Show();
                            this.Hide();
                        }
                        break;
                    case "Padrão":
                        {
                            MessageBox.Show("Tipo de usuário Inválido");
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Erro ao fazer Login ");

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            l.username = txtLogin.Text.Trim();
            l.password = txtSenha.Text.Trim();
            l.user_type = cmbUserType.Text.Trim();

            bool Sucess = dal.LoginCheck(l);
            if (Sucess == true)
            {
             // MessageBox.Show("Login feito com sucesso");
                switch (l.user_type)
                {
                    case "Administrador":
                        {
                            frmAdminDashboard admin = new frmAdminDashboard();
                            admin.Show();
                            CaixaBLL u = new CaixaBLL();
                            u.username = txtLogin.Text.Trim();
                            u.data_abertura = DateTime.Now;
                            dal1.Insert(u);
                            this.Hide();

                        }
                        break;
                    case "Normal":
                        {
                            frmUserDashboard user = new frmUserDashboard();
                            user.Show();
                            CaixaBLL u = new CaixaBLL();
                            u.username = txtLogin.Text.Trim();
                            u.data_abertura = DateTime.Now;
                            dal1.Insert(u);
                            this.Hide();
                        }
                        break;
                    case "Padrão":
                        {
                            MessageBox.Show("Tipo de usuário Inválido");
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Erro ao fazer Login ");

            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
