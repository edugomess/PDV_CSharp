using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Vendas.BLLClasses
{
    class UserBLL
    {
        public UserBLL(string first_name, string email, string username, string password, string contact, string adress, string gender, string user_type, DateTime added_date, int added_by, string rg, string cpf, string city, string bairro, string num, DateTime nascimento, byte[] image)
        {
            this.id = id;
            this.first_name = first_name;
            this.email = email;
            this.username = username;
            this.password = password;
            this.contact = contact;
            this.adress = adress;
            this.gender = gender;
            this.user_type = user_type;
            this.added_date = added_date;
            this.added_by = added_by;
            this.rg = rg;
            this.cpf = cpf;
            this.city = city;
            this.bairro = bairro;
            this.num = num;
            this.nascimento = nascimento;
            Image = image;
        }

        public UserBLL(int id, string first_name, string email, string username, string password, string contact, string adress, string gender, string user_type, DateTime added_date, int added_by, string rg, string cpf, string city, string bairro, string num, DateTime nascimento, byte[] image) 
            : this (first_name, email, username, password, contact, adress, gender, user_type, added_date, added_by, rg, cpf, city, bairro, num, nascimento, image)
        {
            this.id = id;
        }

        public UserBLL()
        {
            this.id = id;
            this.first_name = first_name;
            this.email = email;
            this.username = username;
            this.password = password;
            this.contact = contact;
            this.adress = adress;
            this.gender = gender;
            this.user_type = user_type;
            this.added_date = added_date;
            this.added_by = added_by;
            this.rg = rg;
            this.cpf = cpf;
            this.city = city;
            this.bairro = bairro;
            this.num = num;
            this.nascimento = nascimento;
            this.Image = Image;
        }

        public int id { get; set; }
        public string first_name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string contact { get; set; }
        public string adress { get; set; }
        public string gender { get; set; }
        public string user_type { get; set; }
        public DateTime added_date { get; set; }
        public int added_by { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string city { get; set; }
        public string bairro { get; set; }
        public string num { get; set; }
        public DateTime nascimento { get; set; }

        public byte[] Image { get; set; }


    }
}
