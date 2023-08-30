using Mitrajeet_MVC.Models;
using Mitrajeet_MVC.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Mitrajeet_MVC.DataAccess
{
    public class MitrajeetDataAccessLayer
    {

        string connectionString = ConnectionString.conn;

        public IEnumerable<MitrajeetModel> GetAllMitrajeet()
        {
            List<MitrajeetModel> modal = new List<MitrajeetModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_GetAll_Mitrajeets", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    MitrajeetModel model = new MitrajeetModel();
                    model.Id = Convert.ToInt32(rdr["Id"]);
                    model.Name = rdr["Name"].ToString();
                    model.Age = Convert.ToInt32(rdr["Age"]);
                    model.Gender = rdr["Gender"].ToString();
                    model.Email = rdr["Email"].ToString();
                    model.PhoneNumber = rdr["PhoneNumber"].ToString();
                    model.Country = rdr["Country"].ToString();
                    model.State = rdr["State"].ToString();

                    //public string Name { get; set; }
                    //public int Age { get; set; }
                    //public string Gender { get; set; }
                    //public string Email { get; set; }
                    //public int PhoneNumber { get; set; }
                    //public string Country { get; set; }
                    //public string State { get; set; }

                    modal.Add(model);
                }
                con.Close();
            }
            return modal;
        }

        public void AddMitrajeet(MitrajeetModel param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_Add_Mitrajeets", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", param.Name);
                cmd.Parameters.AddWithValue("@Age", param.Age);
                cmd.Parameters.AddWithValue("@Gender", param.Gender);
                cmd.Parameters.AddWithValue("@Email", param.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", param.PhoneNumber);
                cmd.Parameters.AddWithValue("@Country", param.Country);
                cmd.Parameters.AddWithValue("@State", param.State);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public MitrajeetModel GetMitrajeetDataById(int?id)
        {
            MitrajeetModel model = new MitrajeetModel();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tbl_Mitrajeets WHERE Id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    model.Id = Convert.ToInt32(rdr["Id"]);
                    model.Name = rdr["Name"].ToString();
                    model.Age = Convert.ToInt32(rdr["Age"]);
                    model.Gender = rdr["Gender"].ToString();
                    model.Email = rdr["Email"].ToString();
                    model.PhoneNumber = rdr["PhoneNumber"].ToString();
                    model.Country = rdr["Country"].ToString();
                    model.State = rdr["State"].ToString();
                }
            }
            return model;
        }

        public void UpdateMitrajeet(MitrajeetModel param)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_Update_Mitrajeets", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", param.Id);
                cmd.Parameters.AddWithValue("@Name", param.Name);
                cmd.Parameters.AddWithValue("@Age", param.Age);
                cmd.Parameters.AddWithValue("@Gender", param.Gender);
                cmd.Parameters.AddWithValue("@Email", param.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", param.PhoneNumber);
                cmd.Parameters.AddWithValue("@Country", param.Country);
                cmd.Parameters.AddWithValue("@State", param.State);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<string> GetCountries()
        {
            //MitrajeetModel model = new MitrajeetModel();
            List<string> countries = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT Country FROM tbl_Mitrajeets";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    //model.Country = rdr["Country"].ToString();
                    countries.Add(rdr["Country"].ToString());

                }
            }
            return countries;
        }

        public List<string> GetStates()
        {
            //MitrajeetModel model = new MitrajeetModel();
            List<string> states = new List<string>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT State FROM tbl_Mitrajeets";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    states.Add(rdr["State"].ToString());

                }
            }
            return states;
        }

        public void DeleteMitrajeet(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_Delete_Mitrajeets", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
