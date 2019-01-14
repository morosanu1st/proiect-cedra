using coreassign.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace coreassign.dbstuff
{
    public class Repo
    {
        BasicContext c;

        public Repo(BasicContext c)
        {
            this.c = c;
        }
        public void AddPackage(Package p)
        {

            using (MySqlConnection conn = c.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand
                {
                    CommandText = "insert into package (name, description, tracking, senderCity,destinationCity,sender,receiver) " +
                    "values (@name, @description, @tracking, @senderCity,@destinationCity,@senderId,@receiverId)",
                    Connection = conn
                };
                cmd.Parameters.Add("name", MySqlDbType.VarChar).Value = p.Name;
                cmd.Parameters.Add("description", MySqlDbType.VarChar).Value = p.Description;
                cmd.Parameters.Add("tracking", MySqlDbType.Bit).Value = p.Tracking;
                cmd.Parameters.Add("senderCity", MySqlDbType.VarChar).Value = p.SenderCity;
                cmd.Parameters.Add("destinationCity", MySqlDbType.VarChar).Value = p.DestinationCity;
                cmd.Parameters.Add("senderId", MySqlDbType.UInt32).Value = p.SenderId;
                cmd.Parameters.Add("receiverId", MySqlDbType.UInt32).Value = p.ReceiverId;

                cmd.ExecuteNonQuery();
            }
        }


        public void AddUser(User u)
        {
            using (MySqlConnection conn = c.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand
                {
                    CommandText = "insert into user (username,password) values (@username, @password)",
                    Connection = conn
                };
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = u.Username;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = u.Password;              

                cmd.ExecuteNonQuery();
            }
        }

        public void AddRoute(Route r)
        {
            using (MySqlConnection conn = c.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand
                {
                    CommandText = "insert into route (time,city,idpackage) values (@time, @city,@packageId);" +
                    "update package set tracking=1 where idPackage=@packageId",
                    Connection = conn
                };
                cmd.Parameters.Add("@time", MySqlDbType.VarChar).Value = r.Time;
                cmd.Parameters.Add("@city", MySqlDbType.VarChar).Value = r.City;
                cmd.Parameters.Add("@packageId", MySqlDbType.VarChar).Value = r.PackageId;

                cmd.ExecuteNonQuery();
            }
        }
    }
}

