using CodeJellyApi.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CodeJellyApi.Services
{

    public class CustomerService
    {
        public List<Customer> GetAllCustomers()
        {
            Customer customer = new Customer();
            List<Customer> list = new List<Customer>();


            try
            {
                string connectionString = "Data Source=SQL5047.site4now.net;Initial Catalog=DB_9F9D25_codejelly;User Id=DB_9F9D25_codejelly_admin;Password=Cleveland21!;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlText = "select * from Customer";

                    using (SqlCommand cmd = new SqlCommand(sqlText, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            customer = new Customer();
                            customer.Id = Convert.ToInt32(row["Id"].ToString());
                            customer.PolicyNumber = row["CustomerPolicy"].ToString();
                            customer.FirstName = row["FirstName"].ToString();
                            customer.LastName = row["LastName"].ToString();
                            customer.DateOfBirth = row["DOB"].ToString();
                            customer.Address = row["Address"].ToString();
                            customer.City = row["City"].ToString();
                            customer.State = row["State"].ToString();
                            customer.ZipCode = row["Zip"].ToString();
                            customer.PhoneNumber = row["PhoneNumber"].ToString();
                            customer.Email = row["Email"].ToString();
                            list.Add(customer);

                        }
                    }
                }
            }
            catch (Exception e)
            {

            }

            return list;
        }


        public Customer GetCustomerById(int id)
        {
            Customer customer = new Customer();
            List<Customer> list = new List<Customer>();

            try
            {
                string connectionString = "Data Source=SQL5047.site4now.net;Initial Catalog=DB_9F9D25_codejelly;User Id=DB_9F9D25_codejelly_admin;Password=Cleveland21!;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlText = string.Format("select * from Customer where Id='{0}'", id);

                    using (SqlCommand cmd = new SqlCommand(sqlText, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        connection.Open();
                        DataTable dt = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            customer.Id = Convert.ToInt32(row["Id"].ToString());
                            customer.PolicyNumber = row["CustomerPolicy"].ToString();
                            customer.FirstName = row["FirstName"].ToString();
                            customer.LastName = row["LastName"].ToString();
                            customer.DateOfBirth = row["DOB"].ToString();
                            customer.Address = row["Address"].ToString();
                            customer.City = row["City"].ToString();
                            customer.State = row["State"].ToString();
                            customer.ZipCode = row["Zip"].ToString();
                            customer.PhoneNumber = row["PhoneNumber"].ToString();
                            customer.Email = row["Email"].ToString();
                            list.Add(customer);
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }

            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                string connectionString = "Data Source=SQL5047.site4now.net;Initial Catalog=DB_9F9D25_codejelly;User Id=DB_9F9D25_codejelly_admin;Password=Cleveland21!;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlText = BuildInsertSql(customer);

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

        public void DeleteEntryFromDatabase(int id)
        {
            try
            {
                string connectionString = "Data Source=SQL5047.site4now.net;Initial Catalog=DB_9F9D25_codejelly;User Id=DB_9F9D25_codejelly_admin;Password=Cleveland21!;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlText = string.Format("DELETE FROM dbo.Customer WHERE Id='{0}'", id);

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

        private string BuildInsertSql(Customer customer)
        {
            string sql = string.Format("INSERT INTO dbo.Customer VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', " +
                "'{7}', '{8}', '{9}')", customer.PolicyNumber, customer.FirstName, customer.LastName, customer.DateOfBirth,
                customer.Address, customer.City, customer.State, customer.ZipCode, customer.PhoneNumber, customer.Email);
            return sql;
        }
    }
}