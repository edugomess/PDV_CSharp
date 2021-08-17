using Sistema_Vendas.BLLClasses;
using Sistema_Vendas.DALdados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Vendas.UiForms
{
    public partial class frmUsers : Form
    {
        private string pathImage = string.Empty;
        private int id = -1;
        private byte[] image;
        Bitmap bmp;
        bool novaFoto = false;
        public frmUsers()
        {
            InitializeComponent();
        }
        UserBLL u = new UserBLL();
        UserDal dal = new UserDal();
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //tratamento dos campos Obrigatorios
            if (txtTipoUsuario.SelectedItem == null || !txtCpf.MaskCompleted || !txtRg.MaskCompleted || txtNome.Text.Equals("") || txtLogin.Text.Equals("") || txtSenha.Text.Equals(""))
            {
                MessageBox.Show("ATENTE-SE AO CAMPOS COM '*', NÃO DEVEM FICAR VAZIOS");
                return;
            }

            //Tratamento Validar CPF
            if (!IsCpf(txtCpf.Text))
            {
                MessageBox.Show("CPF INVÁLIDO");
                return;
            }
            else //verifica se o cpf já existe
            {
                    bool Sucess = dal.SelectCPF1(txtCpf.Text);
                    if (Sucess == true) { 
                        MessageBox.Show("CPF Já CADASTRADO");
                        return;
                    }
            }

            //verifica se o rg já existe
            bool Sucess1 = dal.SelectRG(txtRg.Text);
            if (Sucess1 == true)
            {
                MessageBox.Show("RG Já CADASTRADO");
                return;
            }

            //tratamento data
            DateTime date = DateTime.Now.Date;
            DateTime pDate = dateTimePicker1.Value.Date;

            if (date <= pDate)
            {
                MessageBox.Show("DATA MAIOR OU IGUAL A DATA ATUAL");
                //MessageBox.Show(date + "date");
               // MessageBox.Show(date + "pDate");
                return;
            }

            try
            {
                u.first_name = txtNome.Text.ToUpper();
                u.email = txtEmail.Text.ToUpper();
                u.username = txtLogin.Text;
                u.password = txtSenha.Text;
                u.contact = txtContato.Text;
                u.adress = txtEndereco.Text.ToUpper();
                u.gender = txtSexo.Text;
                u.user_type = txtTipoUsuario.Text;
                u.added_date = DateTime.Now;
                u.added_by = 1;
                u.cpf = txtCpf.Text;
                u.rg = txtRg.Text;
                u.city = txtCidade.Text.ToUpper();
                u.bairro = txtBairro.Text.ToUpper();
                u.num = txtNum.Text;
                u.nascimento = dateTimePicker1.Value.Date;

                    FileStream stream = new FileStream(pathImage, FileMode.Open, FileAccess.Read);
                    BinaryReader reader = new BinaryReader(stream);
                    image = reader.ReadBytes((int)stream.Length);
                    reader.Close();
                    stream.Close();
                    u.Image = image;
              

                bool sucess = dal.Insert(u);
                if (sucess == true)
                {
                    MessageBox.Show("USUÁRIO CADASTRADO COM SUCESSO");
                    Limpar();
                }
                else
                {
                    MessageBox.Show("ERRO AO CADASTRAR");

                }

                DataTable dt = dal.Select();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("ALGUNS CAMPOS E IMAGEM NÃO DEVEM ESTAR VAZIOS");
                return;
            }
         }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "ID Usuário";
            dataGridView1.Columns[1].HeaderText = "Nome";
            dataGridView1.Columns[2].HeaderText = "Email";
            dataGridView1.Columns[3].HeaderText = "Usuário";
            dataGridView1.Columns[4].HeaderText = "Senha";
            dataGridView1.Columns[5].HeaderText = "Telefone";
            dataGridView1.Columns[6].HeaderText = "Endereço";
            dataGridView1.Columns[7].HeaderText = "Sexo";
            dataGridView1.Columns[8].HeaderText = "Tipo de Usuário";
            dataGridView1.Columns[9].HeaderText = "Data Cadastrada";
            dataGridView1.Columns[10].HeaderText = "Cadastrado por";
            dataGridView1.Columns[11].HeaderText = "RG";
            dataGridView1.Columns[12].HeaderText = "CPF";
            dataGridView1.Columns[13].HeaderText = "Cidade";
            dataGridView1.Columns[14].HeaderText = "Bairro";
            dataGridView1.Columns[15].HeaderText = "Número(Endereço)";
            dataGridView1.Columns[16].HeaderText = "Nascimento";
            dataGridView1.Columns[17].HeaderText = "Imagem";

            txtCpf.Mask = "000,000,000-00";
        }

        private void Limpar()
        {
            txtID.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtContato.Text = "";
            txtEndereco.Text = "";
            txtSexo.Text = "";
            txtTipoUsuario.Text = "";
            txtCidade.Text = "";
            txtRg.Text = "";
            txtCpf.Text = "";
            txtBairro.Text = "";
            txtNum.Text = "";
            pathImage = String.Empty;
            pcbImage.Image = Properties.Resources.quadro_com_foto_imagem_personalizada;
            image = null;
            txtRg.Enabled = true;
            txtCpf.Enabled = true;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtID.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtNome.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            txtLogin.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            txtSenha.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            txtContato.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            txtEndereco.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            txtSexo.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
            txtTipoUsuario.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();

            txtRg.Text = dataGridView1.Rows[rowIndex].Cells[11].Value.ToString();
            txtCpf.Text = dataGridView1.Rows[rowIndex].Cells[12].Value.ToString();
            txtCidade.Text = dataGridView1.Rows[rowIndex].Cells[13].Value.ToString();
            txtBairro.Text = dataGridView1.Rows[rowIndex].Cells[14].Value.ToString();
            txtNum.Text = dataGridView1.Rows[rowIndex].Cells[15].Value.ToString();
            txtRg.Enabled = false;
            txtCpf.Enabled = false;
            try
            {
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString());
            }catch(Exception ex) { }
            

            try
            {
                int id = Convert.ToInt32(txtID.Text);
                //carregar a imagem a partir do banco.
                UserDal studentDao = new UserDal();
                UserBLL Student = studentDao.Read(id);

             MemoryStream ms = new MemoryStream(Student.Image);

                pcbImage.Image = Image.FromStream(ms);
                image = Student.Image;
                novaFoto = false;
            }
            catch (Exception ex) { }
         }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try { 
            //tratamento dos campos Obrigatorios
            if (txtTipoUsuario.SelectedItem == null || !txtCpf.MaskCompleted || !txtRg.MaskCompleted || txtNome.Text.Equals("") || txtLogin.Text.Equals("") || txtSenha.Text.Equals(""))
            {
                MessageBox.Show("ATENTE-SE AO CAMPOS COM '*', NÃO DEVEM FICAR VAZIOS");
                return;
            }

            //tratamento data
            DateTime date = DateTime.Now.Date;
            DateTime pDate = dateTimePicker1.Value.Date;

            if (date <= pDate)
            {
                MessageBox.Show("DATA MAIOR OU IGUAL A DATA ATUAL");
                return;
            }

            u.id = int.Parse(txtID.Text);
            u.first_name = txtNome.Text.ToUpper();
            u.email = txtEmail.Text.ToUpper();
            u.username = txtLogin.Text;
            u.password = txtSenha.Text;
            u.contact = txtContato.Text;
            u.adress = txtEndereco.Text.ToUpper();
            u.gender = txtSexo.Text;
            u.user_type = txtTipoUsuario.Text;
            u.added_date = DateTime.Now;
            u.added_by = 1;
            u.cpf = txtCpf.Text;
            u.rg = txtRg.Text;
            u.city = txtCidade.Text.ToUpper();
            u.bairro = txtBairro.Text.ToUpper();
            u.num = txtNum.Text;
            u.nascimento = dateTimePicker1.Value.Date;
            
                if (!String.IsNullOrEmpty(pathImage)){
                FileStream stream = new FileStream(pathImage, FileMode.Open, FileAccess.Read);
                   BinaryReader reader = new BinaryReader(stream);
                   image = reader.ReadBytes((int)stream.Length);
                   reader.Close();
                   stream.Close();
                   u.Image = image;
                   novaFoto = true;
                 }

                bool sucess = dal.Update(u, novaFoto);
                if (sucess == true)
                {
                    MessageBox.Show("USUÁRIO ATUALIZADO COM SUCESSO");
                    Limpar();
                }
                else
                {
                    MessageBox.Show("ERRO AO ATUALIZAR");
                    
                }

                DataTable dt = dal.Select();
                dataGridView1.DataSource = dt;
        }catch(Exception ex) { MessageBox.Show(ex + ""); }   

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
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
            }catch(Exception ex) { }
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;

            string digito;

            int soma;

            int resto;

            cpf = cpf.Trim();

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)

                return false;

            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        private void date_Leave(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            pathImage = string.Empty;
            if(ofdImage.ShowDialog() == DialogResult.OK)
            {
                pathImage = ofdImage.FileName;
                if(pcbImage.Image != null)
                {
                    pcbImage.Image.Dispose();
                    pcbImage.Image = null;
                }

                //Carrega a imagem na picture box
                pcbImage.Image = Image.FromFile(pathImage);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ofdImage_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
