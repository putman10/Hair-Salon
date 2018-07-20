using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using HairSalon.Controllers;

namespace HairSalon.Models
{
    public class Specialty
    {
        public int id { get; set; }
        public string name { get; set; }

        public Specialty(string specialtyName, int specialtyId = 0)
        {
            id = specialtyId;
            name = specialtyName;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties (Name) VALUES ( @SpecialtyName);";

            cmd.Parameters.AddWithValue("@SpecialtyName", name);

            cmd.ExecuteNonQuery();
            id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialties = new List<Specialty> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int Id = rdr.GetInt32(0);
                string Name = rdr.GetString(1);
                Specialty newClient = new Specialty(Name, Id);
                allSpecialties.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSpecialties;
        }

        public static Specialty Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `specialties` WHERE id = @thisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int Id = 0;
            string Name = "";

            while (rdr.Read())
            {
                Id = rdr.GetInt32(0);
                Name = rdr.GetString(1);
            }

            Specialty foundSpecialty = new Specialty(Name, Id);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundSpecialty;


        }
    }
}