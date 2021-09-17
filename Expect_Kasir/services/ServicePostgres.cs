using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Expect_Kasir.services
{
    class ServicePostgres
    {
        public void connectToDB()
        {
            try
            {
                var config = "Host=localhost;Username=postgres;Password=2002;Database=open_music";
                var con = new NpgsqlConnection(config);
                con.Open();

                var sql = "SELECT * FROM songs";
                var cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.Write($"{rdr.GetValue(0)} | {rdr.GetValue(1)} | {rdr.GetValue(2)} | {rdr.GetValue(3)} | {rdr.GetValue(4)}");
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
