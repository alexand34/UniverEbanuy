using lab2.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.DataAdapters
{
    public class CinemasDataAdapter
    {
        private SqlConnection CreateConnection()
        {
            var nw = ConfigurationManager.ConnectionStrings["lab8Entities"];
            var connection = new SqlConnection(nw.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }

        public void InsertData(int id, string name)
        {
            var connection = CreateConnection();

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Id,Name from Cinemas";

            var da = new SqlDataAdapter(cmd);
            var nwSet = new DataSet("lab8Entities");
            var bldr = new SqlCommandBuilder(da);

            da.Fill(nwSet, "Cinemas");
            var countriesTable = nwSet.Tables["Cinemas"];
            DataRow workRow = countriesTable.NewRow();
            workRow["Id"] = id;
            workRow["Name"] = name;
            countriesTable.Rows.Add(workRow);

            da.Update(nwSet, "Cinemas");

        }

        public void DeleteData(int id)
        {
            var connection = CreateConnection();

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Cinemas";

            var da = new SqlDataAdapter(cmd);
            var nwSet = new DataSet("lab8Entities");
            var bldr = new SqlCommandBuilder(da);

            da.Fill(nwSet, "Cinemas");
            var cinemasTable = nwSet.Tables["Cinemas"];

            var delRow = cinemasTable.Select($"Id = {id}")[0];
            delRow.Delete();

            da.Update(nwSet, "Cinemas");
        }

        public void UpdateData(int id, string name)
        {
            var connection = CreateConnection();

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Cinemas";

            var da = new SqlDataAdapter(cmd);
            var nwSet = new DataSet("lab8Entities");
            var bldr = new SqlCommandBuilder(da);
            da.Fill(nwSet, "Cinemas");
            var countriesTable = nwSet.Tables["Cinemas"];

            var updRow = countriesTable.Select($"Id = {id}")[0];

            updRow["Name"] = name;

            da.Update(nwSet, "Cinemas");
        }

        public List<Cinema> GetData()
        {
            var cinemas = new List<Cinema>();

            var connection = CreateConnection();

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Cinemas";

            var da = new SqlDataAdapter(cmd);
            var nwSet = new DataSet("lab8Entities");
            da.Fill(nwSet, "Cinemas");

            foreach (DataRow row in nwSet.Tables["Cinemas"].Rows)
            {
                cinemas.Add(new Cinema()
                {
                    Id = (int)row[0],
                    Name = (string)row[1],
                    CityId = (int)row[2]
                });
            }
            return cinemas;
        }
    }
}
