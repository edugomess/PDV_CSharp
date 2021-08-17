using Sistema_Vendas.BLLClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Vendas.DALdados
{

    class UserDal
    {

        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        #region selecionar dados do database
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM tbl_user";
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
        public bool Insert(UserBLL u)
        {
            bool isSucess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                String sql = "INSERT INTO tbl_user(first_name, email, username, password, contact, adress, gender, user_type, added_date, added_by, rg, cpf, city, bairro, num, nascimento, image) VALUES (@first_name, @email, @Username, @password, @contact, @adress, @gender, @user_type, @added_date, @added_by, @rg, @cpf, @city, @bairro, @num, @nascimento, @image)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@first_name", u.first_name);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@adress", u.adress);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                cmd.Parameters.AddWithValue("@rg", u.rg);
                cmd.Parameters.AddWithValue("@cpf", u.cpf);
                cmd.Parameters.AddWithValue("@city", u.city);
                cmd.Parameters.AddWithValue("@bairro", u.bairro);
                cmd.Parameters.AddWithValue("@num", u.num);
                cmd.Parameters.AddWithValue("@nascimento", u.nascimento);
                cmd.Parameters.AddWithValue("@image", u.Image);

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

        #region Atualizar os dados do banco de dados
        public bool Update(UserBLL u, bool novaFoto)
        {
            
            bool isSucess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {

                string sql = "UPDATE tbl_user SET first_name=@first_name, email=@email, username=@username, password=@password, contact=@contact, adress=@adress, gender=@gender, user_type=@user_type, added_date=@added_date, added_by=@added_by, rg=@rg, cpf=@cpf, city=@city, bairro=@bairro, num=@num, nascimento=@nascimento ";
                string where = "WHERE id=@id";

               
                if (novaFoto)
                {
                 sql += ", image = @image ";
                }

                SqlCommand cmd = new SqlCommand(sql + where, conn);


                cmd.Parameters.AddWithValue("@first_name", u.first_name);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@adress", u.adress);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                cmd.Parameters.AddWithValue("@rg", u.rg);
                cmd.Parameters.AddWithValue("@cpf", u.cpf);
                cmd.Parameters.AddWithValue("@city", u.city);
                cmd.Parameters.AddWithValue("@bairro", u.bairro);
                cmd.Parameters.AddWithValue("@num", u.num);
                cmd.Parameters.AddWithValue("@nascimento", u.nascimento);
                

                if(novaFoto){
                    cmd.Parameters.AddWithValue("@image", SqlDbType.Binary).Value = u.Image;
                }
                cmd.Parameters.AddWithValue("id", u.id);

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
           catch (Exception ex)
            {
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
                String sql = "SELECT * FROM tbl_user WHERE id LIKE '%" + keywords + "%' or first_name LIKE '%" + keywords + "%'";
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

        #region
        public bool SelectRG(string l)
        {
            bool isSucess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "SELECT rg from tbl_user where rg LIKE '%" + l + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
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
        #region
        public bool SelectCPF1(String l)
            {
                bool isSucess = false;
                SqlConnection conn = new SqlConnection(myconnstring);
                try
                {
                    string sql = "SELECT cpf from tbl_user where cpf LIKE '%" + l + "%'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                   

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
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

        #region
       

        public UserBLL Read(int id)
        {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM tbl_user WHERE id = @id ORDER BY id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                adapter.Fill(dt);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UserBLL student = new UserBLL((int)reader["Id"], (string)reader["first_name"], (string)reader["email"], 
                        (string)reader["username"], (string)reader["password"], (string)reader["contact"], (string)reader["adress"], 
                        (string)reader["gender"], (string)reader["user_type"], (DateTime)reader["added_date"], (int)reader["added_by"],
                        (string)reader["rg"], (string)reader["cpf"], (string)reader["city"], (string)reader["bairro"],
                        (string)reader["num"], (DateTime)reader["nascimento"], (Byte[])reader["image"]);

                    return student;
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;

        }
        #endregion
        #region
        public List<UserBLL> Read()
        {
            List<UserBLL> list = new List<UserBLL>();
            SqlConnection conn = new SqlConnection(myconnstring);
            
            try
            {
                String sql = "SELECT * FROM tbl_user ORDER BY id";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
              //  cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                //adapter.Fill(dt);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UserBLL student = new UserBLL((int)reader["Id"], (string)reader["first_name"], (string)reader["email"],
                        (string)reader["username"], (string)reader["password"], (string)reader["contact"], (string)reader["adress"],
                        (string)reader["gender"], (string)reader["user_type"], (DateTime)reader["added_date"], (int)reader["added_by"],
                        (string)reader["rg"], (string)reader["cpf"], (string)reader["city"], (string)reader["bairro"],
                        (string)reader["num"], (DateTime)reader["nascimento"], (Byte[])reader["image"]);

                     list.Add(student);
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
            return list;
        }
        #endregion

    }
}

