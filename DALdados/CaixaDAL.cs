using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_Vendas.BLLClasses;


namespace Sistema_Vendas.DALdados
{
    class CaixaDAL
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        #region metodo de selecionar
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Caixa";
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
        public bool Insert(CaixaBLL c)
        {
            bool isSucess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "INSERT INTO Caixa(username, data_abertura) VALUES (@username, @data_abertura)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", c.username);
                cmd.Parameters.AddWithValue("@data_abertura", c.data_abertura);


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
        #endregion



        #region metodo de pesquisa
        public bool SearchUsername()
        {
            SqlConnection conn = new SqlConnection(myconnstring);
           // DataTable dt = new DataTable();
           // try
            //{
                String sql = "SELECT username from Caixa where username = (select max(id) from Caixa)";
                //SELECT LAST(column_name) AS LAST_CUSTOMER FROM table_name
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                //   adapter.Fill(dt);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
                else
                    return false;
            //}
            //catch (Exception e)
            //{
              //  MessageBox.Show(e.Message);
            //}
            //finally
            //{
                conn.Close();
            //}
            //return true;
           
        }
        #endregion

        
    }
}
