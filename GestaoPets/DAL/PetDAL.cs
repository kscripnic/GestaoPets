using GestaoPets.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoPets.DAL
{
    public class PetDAL
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pets;Integrated Security=True;";

        public List<Pet> ListarPets()
        {
            List<Pet> listPets = new List<Pet>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Pets", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Pet pet = new Pet();
                    pet.CodigoPet = Convert.ToInt32(rdr["CodigoPet"]);
                    pet.Nome = Convert.ToString(rdr["Nome"]);
                    pet.Especie = rdr["Especie"].ToString();
                    pet.Idade = Convert.ToInt32(rdr["Idade"]);
                    listPets.Add(pet);
                }
                con.Close();
            }
            return listPets;
        }

        public void AddPet(Pet pet)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Insert into Pets (Nome,Idade,Especie) Values(@Nome, @idade, @especie)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", pet.Nome);
                cmd.Parameters.AddWithValue("@idade", pet.Idade);
                cmd.Parameters.AddWithValue("@especie", pet.Especie);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdatePet(Pet pet)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Update Pets set Nome = @nome, Idade = @idade, Especie = @especie where CodigoPet = @codigo";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@codigo", pet.CodigoPet);
                cmd.Parameters.AddWithValue("@nome", pet.Nome);
                cmd.Parameters.AddWithValue("@idade", pet.Idade);
                cmd.Parameters.AddWithValue("@especie", pet.Especie);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeletePet(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from Pets where CodigoPet = @codigo";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@codigo", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Pet ObterPet(int codigo)
        {
            Pet pet = new Pet();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from Pets where CodigoPet = @codigo", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@codigo", codigo);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    pet.CodigoPet = Convert.ToInt32(rdr["CodigoPet"]);
                    pet.Nome = rdr["Nome"].ToString();
                    pet.Especie = rdr["Especie"].ToString();
                    pet.Idade = Convert.ToInt32(rdr["Idade"]);
                }
                con.Close();
            }
            return pet;
        }
    }
}
