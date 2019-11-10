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
    public class CountriesDataAdapter
    {
        private SqlConnection CreateConnection()
        {
            var nw = ConfigurationManager.ConnectionStrings["lab8Entities"];
            var connection = new SqlConnection(nw.ConnectionString);

            if (connection.State != ConnectionState.Open)
                connection.Open();

            return connection;
        }

        public void InsertData(int id, string country)
        {
            var connection = CreateConnection();

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Id,Name from Countries";

            var da = new SqlDataAdapter(cmd);
            var nwSet = new DataSet("lab8Entities");
            var bldr = new SqlCommandBuilder(da);

            da.Fill(nwSet, "Countries");
            var countriesTable = nwSet.Tables["Countries"];
            DataRow workRow = countriesTable.NewRow();
            workRow["Id"] = id;
            workRow["Name"] = country;
            countriesTable.Rows.Add(workRow);

            da.Update(nwSet, "Countries");

        }

        public void DeleteData(int id)
        {
            var connection = CreateConnection();

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Countries";

            var da = new SqlDataAdapter(cmd);
            var nwSet = new DataSet("lab8Entities");
            var bldr = new SqlCommandBuilder(da);

            da.Fill(nwSet, "Countries");
            var countriesTable = nwSet.Tables["Countries"];

            var delRow = countriesTable.Select($"Id = {id}")[0];
            delRow.Delete();

            da.Update(nwSet, "Countries");
        }

        public void UpdateData(int id, string name)
        {
            var connection = CreateConnection();

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Countries";

            var da = new SqlDataAdapter(cmd);
            var nwSet = new DataSet("lab8Entities");
            var bldr = new SqlCommandBuilder(da);
            da.Fill(nwSet, "Countries");
            var countriesTable = nwSet.Tables["Countries"];

            var updRow = countriesTable.Select($"Id = {id}")[0];

            updRow["Name"] = name;

            da.Update(nwSet, "Countries");
        }

        public List<Country> GetData()
        {
            var countries = new List<Country>();

            var connection = CreateConnection();

            var cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Countries";

            var da = new SqlDataAdapter(cmd);
            var nwSet = new DataSet("lab8Entities");
            da.Fill(nwSet, "Countries");

            foreach(DataRow row in nwSet.Tables["Countries"].Rows   )
            {
                countries.Add(new Country()
                {
                    Id = (int)row[0],
                    Name = (string)row[1]
                });
            }
            return countries;
        }
    }
}
