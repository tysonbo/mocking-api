using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CodeJellyApi.Models;


namespace CodeJellyApi.Services
{
    public class MockService
    {
        public List<Mock> GetAllMocks()
        {
            Mock mock = new Mock();
            List<Mock> list = new List<Mock>();


            try
            {
                string connectionString = "Data Source=SQL5047.site4now.net;Initial Catalog=DB_9F9D25_codejelly;User Id=DB_9F9D25_codejelly_admin;Password=Cleveland21!;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlText = "select * from Mock";

                    using (SqlCommand cmd = new SqlCommand(sqlText, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            mock = new Mock();
                            mock.Id = Convert.ToInt32(row["Id"].ToString());
                            mock.Name = row["Name"].ToString();
                            mock.RequestBody = row["RequestBody"].ToString();
                            mock.ResponseBody = row["ResponseBody"].ToString();
                            mock.UriParameter = row["UriParameter"].ToString();
                            mock.HeaderParameter = row["HeaderParameter"].ToString();
                            list.Add(mock);
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }

            return list;
        }

        public Mock GetMockbyName(string name)
        {
            Mock mock = new Mock();
            List<Mock> list = new List<Mock>();

            try
            {
                string connectionString = "Data Source=SQL5047.site4now.net;Initial Catalog=DB_9F9D25_codejelly;User Id=DB_9F9D25_codejelly_admin;Password=Cleveland21!;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlText = string.Format("select * from Mock where Name ='{0}'", name);

                    using (SqlCommand cmd = new SqlCommand(sqlText, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            mock.Id = Convert.ToInt32(row["Id"].ToString());
                            mock.Name = row["Name"].ToString();
                            mock.RequestBody = row["RequestBody"].ToString();
                            mock.ResponseBody = row["ResponseBody"].ToString();
                            mock.UriParameter = row["UriParameter"].ToString();
                            mock.HeaderParameter = row["HeaderParameter"].ToString();
                            list.Add(mock);
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }

            return mock;
        }

        public void AddMock(Mock mock)
        {
            try
            {
                string connectionString = "Data Source=SQL5047.site4now.net;Initial Catalog=DB_9F9D25_codejelly;User Id=DB_9F9D25_codejelly_admin;Password=Cleveland21!;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlText = BuildInsertSql(mock);

                    using (SqlCommand cmd = new SqlCommand(sqlText, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                string my = e.Message;
            }
        }

        public void DeleteEntryFromDatabase(string name)
        {
            try
            {
                string connectionString = "Data Source=SQL5047.site4now.net;Initial Catalog=DB_9F9D25_codejelly;User Id=DB_9F9D25_codejelly_admin;Password=Cleveland21!;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlText = string.Format("DELETE FROM dbo.Mock WHERE Name='{0}'", name);

                    using (SqlCommand cmd = new SqlCommand(sqlText, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        private string BuildInsertSql(Mock mock)
        {
            string sql = string.Format("INSERT INTO dbo.Mock VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                mock.Name, mock.ResponseBody, mock.UriParameter, mock.HeaderParameter, mock.RequestBody);
            return sql;
        }
    }

}

