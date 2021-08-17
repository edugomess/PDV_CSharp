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
    public partial class frmVendas : Form
    {
        public frmVendas()
        {
            InitializeComponent();
        }

        DeaCustDAL dcDAL = new DeaCustDAL();
        productsDAL pDAL = new productsDAL();

        DataTable transactionDT = new DataTable();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVendas_Load(object sender, EventArgs e)
        {
            string type = frmUserDashboard.transactionType;
            primeiro.Text = type;

            transactionDT.Columns.Add("Nome Produto");
            transactionDT.Columns.Add("Valor");
            transactionDT.Columns.Add("Quantidade");
            transactionDT.Columns.Add("Total");

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtPesquisar.Text;
            if(keyword == "")
            {
                txtNome.Text = "";
                txtEmail.Text = "";
                txtContato.Text = "";
                txtEndereco.Text = "";
                return;

            }
            DeaCustBLL dc = dcDAL.SearchDealerCustomerforTransaction(keyword);
            txtNome.Text = dc.name;
            txtEmail.Text = dc.email;
            txtContato.Text = dc.contact;
            txtEndereco.Text = dc.adress;

        }

        private void txtPesquisar1_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtPesquisar1.Text;
            if (keyword == "")
            {
                txtNome2.Text = "";
                txtInventario.Text = "";
                txtQtde.Text = "";
                txtValor.Text = "";
                return;

            }
            productsBLL p = pDAL.GetProductsForTransaction(keyword);
            txtNome2.Text = p.name ;
            txtInventario.Text = p.qty.ToString();
            txtValor.Text = p.rate.ToString();


        }

        private void btnCadastrar1_Click(object sender, EventArgs e)
        {
            

        }

        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string value = txtDesconto.Text;
                if (value == "")
                {
                    MessageBox.Show("Favor Adicionar o desconto para esta venda");

                }
                else
                {
                    decimal subTotal = decimal.Parse(txtSubtotal.Text);
                    decimal discount = decimal.Parse(txtDesconto.Text);

                    decimal grandTotal = ((100 - discount) / 100) * subTotal;
                    txtGrand.Text = grandTotal.ToString();
                }
            }catch(Exception ex) { }
        }

        private void txtImposto_TextChanged(object sender, EventArgs e)
        {
            string check = txtGrand.Text;
            if (check == "")
            {
                MessageBox.Show("Imposto deve ser informado");

            }
            else
            {
                decimal previous = decimal.Parse(txtGrand.Text);
                decimal vat = decimal.Parse(txtImposto.Text);

                decimal grandTotal1 = ((100 + vat) / 100) * previous;
                txtGrand.Text = grandTotal1.ToString();
               

            }
        }

        private void txtTotalPago_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal grandTotal = decimal.Parse(txtGrand.Text);
                decimal paidAmount = decimal.Parse(txtTotalPago.Text);

                decimal returnAmount = paidAmount - grandTotal;

                txtTroco.Text = returnAmount.ToString();
            }catch(Exception ex) { }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string productName = txtNome2.Text;
                decimal rate = decimal.Parse(txtValor.Text);
                decimal qty = decimal.Parse(txtQtde.Text);
                decimal total = rate * qty;

                decimal subtotal = decimal.Parse(txtSubtotal.Text);
                subtotal = subtotal + total;

                if (productName == "")
                {
                    MessageBox.Show("Digite o Nome do Produto");
                }
                else
                {
                    transactionDT.Rows.Add(productName, rate, qty, total);
                    dataGridView1.DataSource = transactionDT;
                    txtSubtotal.Text = subtotal.ToString();
                    txtPesquisar1.Text = "";
                    txtNome2.Text = "";
                    txtInventario.Text = "0.00";
                    txtValor.Text = "0.00";
                    txtQtde.Text = "";
                }

            }
            catch (Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            transaçõesBLL u = new transaçõesBLL();
            transaçõesDAL dal = new transaçõesDAL();

            try
            {
                u.discount = decimal.Parse(txtDesconto.Text);
                u.grandTotal = decimal.Parse(txtGrand.Text);
                u.tax = decimal.Parse(txtImposto.Text);
                u.transaction_date = DateTime.Now;




                bool sucess = dal.Insert_Transaction(u);
                if (sucess == true)
                {
                    MessageBox.Show("VENDA REALIZADA COM SUCESSO");
                }
                else
                {
                    MessageBox.Show("ERRO AO REALIZAR VENDA");

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
    }
}
