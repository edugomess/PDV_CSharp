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
    public partial class frmDeaCust : Form
    {
        public frmDeaCust()
        {
            InitializeComponent();
        }

        DeaCustBLL u = new DeaCustBLL();
        DeaCustDAL dal = new DeaCustDAL();
        UserDal uDal = new UserDal();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            u.type = txtTipo.Text;
            u.name = txtNome.Text;
            u.email = txtEmail.Text;
            u.contact = txtContato.Text;
            u.adress = txtEndereco.Text;
            u.added_date = DateTime.Now;

           // string loggedUsr = frmLogin.loggedIn;
           // UserBLL usr = uDal.getIDFromUsername(loggedUsr);
           // u.added_by = usr.id;

            bool sucess = dal.Insert(u);
            if (sucess == true)
            {
                MessageBox.Show("USUÁRIO CADASTRADO COM SUCESSO");
                Limpar();
            }
            else
            {
                MessageBox.Show("Erro ao Cadastrar");
            }

            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            u.type = txtTipo.Text;
            u.name = txtNome.Text;
            u.email = txtEmail.Text;
            u.contact = txtContato.Text;
            u.adress = txtEndereco.Text;
            u.added_date = DateTime.Now;

            // string loggedUsr = frmLogin.loggedIn;
            // UserBLL usr = uDal.getIDFromUsername(loggedUsr);
            // u.added_by = usr.id;


            bool sucess = dal.Update(u);
            if (sucess == true)
            {
                MessageBox.Show("Usuario atuliazado com sucesso");
                Limpar();
            }
            else
            {
                MessageBox.Show("Erro ao atualizar");
            }

            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txtID.Text);

            bool sucess = dal.Delete(u);
            if (sucess == true)
            {
                MessageBox.Show("Usuario Deletado com sucesso");
                Limpar();
            }
            else
            {
                MessageBox.Show("Erro ao Deletar");
            }

            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }

        private void Limpar()
        {
            txtID.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtContato.Text = "";
            txtEndereco.Text = "";
            txtTipo.Text = "";
         

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtPesquisar.Text;
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dataGridView1.DataSource = dt;
            }
            else
            {
                 DataTable dt = dal.Search();
                 dataGridView1.DataSource = dt;

            }
        }

        private void frmDeaCust_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtID.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtTipo.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            txtNome.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            txtContato.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            txtEndereco.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
