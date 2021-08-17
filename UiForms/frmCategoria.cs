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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        categoriaBLL c = new categoriaBLL();
        categoriaDAL dal = new categoriaDAL();
        UserDal udal = new UserDal();
        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            c.title = txtTitulo.Text;
            c.description = txtDescricao.Text;
            c.added_date = DateTime.Now;

            //pegando o valor do id logado
         //   string loggedUser = frmLogin.loggedIn;
          //  UserBLL usr = udal.GetIdFromUsername(loggedUser);
          //  c.added_by = usr.id;

            bool sucess = dal.Insert(c);
            if (sucess == true)
            {
                MessageBox.Show("CATEGORIA CADASTRADO COM SUCESSO");
                Limpar();
            }
            else
            {
                MessageBox.Show("Erro ao Cadastrar");
            }

            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
        }

        private void Limpar()
        {
            txtID.Text = "";
            txtDescricao.Text = "";
            txtTitulo.Text = "";
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;
            txtID.Text = dataGridView1.Rows[RowIndex].Cells[0].Value.ToString();
            txtTitulo.Text = dataGridView1.Rows[RowIndex].Cells[1].Value.ToString();
            txtDescricao.Text = dataGridView1.Rows[RowIndex].Cells[2].Value.ToString();

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            c.id = Convert.ToInt32(txtID.Text);
            c.title = txtTitulo.Text;
            c.description = txtDescricao.Text;
            c.added_date = DateTime.Now;

            //pegando o valor do id logado
            //   string loggedUser = frmLogin.loggedIn;
            //  UserBLL usr = udal.GetIdFromUsername(loggedUser);
            //  c.added_by = usr.id;


            bool sucess = dal.Update(c);
            if (sucess == true)
            {
                MessageBox.Show("Categoria atualizado com sucesso");
                Limpar();


                DataTable dt = dal.Select();
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Erro ao atualizar");
            }

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            c.id = Convert.ToInt32(txtID.Text);

            bool sucess = dal.Delete(c);
            if (sucess == true)
            {
                MessageBox.Show("Categoria Deletada com sucesso");
                Limpar();
            }
            else
            {
                MessageBox.Show("Erro ao Deletar");
            }

            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
