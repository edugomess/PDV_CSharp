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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        categoriaDAL cdal = new categoriaDAL();
        productsBLL p = new productsBLL();
        productsDAL pdal = new productsDAL();
        private void frmProducts_Load(object sender, EventArgs e)
        {
            DataTable categoriesDT = cdal.Select();
            cmbCategoria.DataSource = categoriesDT;
            cmbCategoria.DisplayMember = "title";
            cmbCategoria.ValueMember = "title";

            DataTable dt = pdal.Select();
            dataGridView1.DataSource = dt;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            p.name = txtNome.Text;
            p.category = cmbCategoria.Text;
            p.description = txtDescricao.Text;
            p.rate = decimal.Parse(txtValor.Text);
            p.added_date = DateTime.Now;

            //String loggedUsr = frmLogin.loggedIn;
            //userBLL usr = udal.getIdFromUsername(loggedUser);
            //p.added_by = usr.id;

            bool sucess = pdal.Insert(p);
            if (sucess == true)
            {
                MessageBox.Show("USUÁRIO CADASTRADO COM SUCESSO");
                Limpar();
            }
            else
            {
                MessageBox.Show("Erro ao Cadastrar");
            }

            DataTable dt = pdal.Select();
            dataGridView1.DataSource = dt;
        }

        private void Limpar()
        {
            txtID.Text = "";
            txtNome.Text = "";
            cmbCategoria.Text = "";
            txtDescricao.Text = "";
            txtValor.Text = "";
     

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            p.id = Convert.ToInt32(txtID.Text);
            p.name = txtNome.Text;
            p.category = cmbCategoria.Text;
            p.description = txtDescricao.Text;
            p.rate = 0;
            p.added_date = DateTime.Now;

            //String loggedUsr = frmLogin.loggedIn;
            //userBLL usr = udal.getIdFromUsername(loggedUser);
            //p.added_by = usr.id;

            bool sucess = pdal.Update(p);
            if (sucess == true)
            {
                MessageBox.Show("Usuario atuliazado com sucesso");
                Limpar();
            }
            else
            {
                MessageBox.Show("Erro ao atualizar");
            }

            DataTable dt = pdal.Select();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtID.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtNome.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            cmbCategoria.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            txtDescricao.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            txtValor.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            p.id = Convert.ToInt32(txtID.Text);

            bool sucess = pdal.Delete(p);
            if (sucess == true)
            {
                MessageBox.Show("Usuario Deletado com sucesso");
                Limpar();
            }
            else
            {
                MessageBox.Show("Erro ao Deletar");
            }

            DataTable dt = pdal.Select();
            dataGridView1.DataSource = dt;
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtPesquisar.Text;
            if (keywords != null)
            {
                DataTable dt = pdal.Search(keywords);
                dataGridView1.DataSource = dt;
            }
            else
            {
                 DataTable dt = pdal.Search(keywords);
                 dataGridView1.DataSource = dt;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
