using model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace data.services
{
    public class UserService
    {
        public List<User> GetData()
        {
            List<User> list = new List<User>();
            DataTable table = new DataTable("Users");
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KurdistanroadWebsite;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Users";
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                
                foreach (DataRow row in table.Rows)
                {
                    User instance = new User();
                    instance.FirstName = row["Name"].ToString();
                    instance.LastName = row["LastName"].ToString();
                    instance.NationalCode = row["NationalCode"].ToString();
                    list.Add(instance);
                }
            }
            return list;
        }

        public void DeleteUser(User selectedUser)
        {
            throw new NotImplementedException();
        }
    }
}
