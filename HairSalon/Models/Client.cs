using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using HairSalon.Controllers;

namespace HairSalon.Models
{
    public class Client
    {
        public int id {get;set;}
        public string name {get;set;}
        public int stylistId {get;set;}


        public Client(int Id, int StylistId, string Name)
        {
            id = Id;
            stylistId = StylistId;
            name = Name;
        }
        public Client(int stylistId, string name)
        {
            stylistId = stylistId;
            name = name;
            System.Console.WriteLine("in 2nd");

        }
        public Client()
        {
          System.Console.WriteLine("in empty");
        }

        public int GetId()
        {
            return id;
        }

        public int GetStylistId()
        {
            return stylistId;
        }

        public string GetName()
        {
            return name;
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int Id = rdr.GetInt32(0);
                int StylistId = rdr.GetInt32(1);
                string Name = rdr.GetString(2);
                Client newClient = new Client(Id, StylistId, Name);
                allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClients;
        }

        public override bool Equals(System.Object otherClient)
        {

            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client)otherClient;
                bool idEquality = (this.GetId() == newClient.GetId());
                bool nameEquality = (this.GetName() == newClient.GetName());
                bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());
                return (idEquality && nameEquality && stylistIdEquality);
            }
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            System.Console.WriteLine(this.id);
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO `clients` (`id`, `stylist_id`, `name`) VALUES (@thisId, @thisStylistId, @thisName);";

            MySqlParameter clientId = new MySqlParameter();
            clientId.ParameterName = "@thisId";
            clientId.Value = this.id;

            MySqlParameter stylistid = new MySqlParameter();
            stylistid.ParameterName = "@thisStylistId";
            stylistid.Value = this.stylistId;

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@thisName";
            name.Value = this.name;

            cmd.Parameters.Add(clientId);
            cmd.Parameters.Add(stylistid);
            cmd.Parameters.Add(name);

            cmd.ExecuteNonQuery();
            id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DeleteClient(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients WHERE id = @thisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Client Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `clients` WHERE id = @thisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            int Id = 0;
            int StylistId = 0;
            string Name = "";

            while (rdr.Read())
            {
                Id = rdr.GetInt32(0);
                StylistId = rdr.GetInt32(1);
                Name = rdr.GetString(2);
            }

            Client foundClient = new Client(id, StylistId, Name);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundClient;


        }

        public void Edit(string newName, int stylistId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE clients SET name = @newName, stylist_id = @thisStylistId WHERE id = @thisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            MySqlParameter clientName = new MySqlParameter();
            clientName.ParameterName = "@newName";
            clientName.Value = newName;
            cmd.Parameters.Add(clientName);

            MySqlParameter stylistid = new MySqlParameter();
            stylistid.ParameterName = "@thisStylistId";
            stylistid.Value = stylistId;
            cmd.Parameters.Add(stylistid);

            cmd.ExecuteNonQuery();
            name = newName;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

        }
    }
}
