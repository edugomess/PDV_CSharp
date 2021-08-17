using Sistema_Vendas.BLLClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Vendas.DALdados
{
    class transaçõesDAL
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        #region selecionar dados do database
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM tbl_transaction";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region inserir dados no banco de dados
        //public bool Insert_Transaction(transaçõesBLL u, out int trasanctionID)
        public bool Insert_Transaction(transaçõesBLL u)

        {
            bool isSucess = false;
           // trasanctionID = -1;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "INSERT INTO tbl_transaction(dea_cust_id, grandTotal, transaction_date, tax, discount, added_by) VALUES ( @dea_cust_id, @grandTotal, @transaction_date, @tax, @discount, @added_by)";
                SqlCommand cmd = new SqlCommand(sql, conn);
               // cmd.Parameters.AddWithValue("@type", u.type);
                cmd.Parameters.AddWithValue("@dea_cust_id", u.dea_cust_id);
                cmd.Parameters.AddWithValue("@grandTotal", u.grandTotal);
                cmd.Parameters.AddWithValue("@transaction_date", u.transaction_date);
                cmd.Parameters.AddWithValue("@tax", u.tax);
                cmd.Parameters.AddWithValue("@discount", u.discount);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);

                conn.Open();
                 int rows = cmd.ExecuteNonQuery();
               // object o = cmd.ExecuteScalar();
                //if (o != null)
                if(rows > 0)
                {
                  //  trasanctionID = int.Parse(o.ToString());
                    isSucess = true;

                }
                else
                {
                    isSucess = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSucess;
        }
        #endregion

        #region Atualizar os dados do banco de dados
        public bool Update(UserBLL u)
        {
            bool isSucess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "UPDATE tbl_user SET first_name=@first_name, email=@email, username=@username, password=@password, contact=@contact, adress=@adress, gender=@gender, user_type=@user_type, added_date=@added_date, added_by=@added_by WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@first_name", u.first_name);
                // cmd.Parameters.AddWithValue("@last_name", u.last_name);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@adress", u.adress);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                cmd.Parameters.AddWithValue("@id", u.id);

                conn.Open();

                object o = cmd.ExecuteScalar();
                //int rows = cmd.ExecuteNonQuery();

                if (o != null)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSucess;
        }


        #endregion

        #region deletar osd dados do banco de dados
        public bool Delete(UserBLL u)
        {
            bool isSucess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "DELETE FROM tbl_user WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", u.id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSucess;
        }

        internal DataTable Search()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region metodo de pesquisa
        public DataTable Search(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM tbl_user WHERE id LIKE '%" + keywords + "%'";// or first_name'%" + keywords + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion
    }
}
