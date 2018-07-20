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

        public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty)otherSpecialty;
                bool idEquality = (this.id.Equals(newSpecialty.id));
                bool nameEquality = (this.name == newSpecialty.name);
                return (idEquality && nameEquality);
            }
        }
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
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

        public static void CreateSpecialtyStylistPairing(int stylistId, int[] selectedSpecialties)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            for (int i = 0; i < selectedSpecialties.Count(); i++)
            {
                MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO specialties_stylists (specialties_id, stylists_id) VALUES ( @SpecialtyId, @StylistId);";

                cmd.Parameters.AddWithValue("@StylistId", stylistId);
                cmd.Parameters.AddWithValue("@SpecialtyId", selectedSpecialties[i]);

                cmd.ExecuteNonQuery();
                //id = (int)cmd.LastInsertedId;
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static int[] SaveListOfSpecialties(string[] specialtiesList)
        {

            MySqlConnection conn = DB.Connection();
            conn.Open();
            List<int> specialtiesIds = new List<int>();

            for (int i = 0; i < specialtiesList.Count(); i++)
            {

                MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"INSERT INTO specialties (Name) VALUES ( @SpecialtyName);SELECT id FROM specialties ORDER BY id DESC LIMIT 1";

                cmd.Parameters.AddWithValue("@SpecialtyName", specialtiesList[i]);
                cmd.ExecuteNonQuery();

                MySqlCommand cmdTwo = conn.CreateCommand() as MySqlCommand;
                cmdTwo.CommandText = @"SELECT id FROM specialties ORDER BY id DESC LIMIT 1";
                MySqlDataReader rdr = cmdTwo.ExecuteReader() as MySqlDataReader;
                while (rdr.Read())
                {
                    int specialtyId = rdr.GetInt32(0);
                    specialtiesIds.Add(specialtyId);

                }
                rdr.Dispose();
            }

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return specialtiesIds.ToArray();
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}