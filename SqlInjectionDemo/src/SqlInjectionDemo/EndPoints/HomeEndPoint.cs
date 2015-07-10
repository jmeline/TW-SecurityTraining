using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SqlInjectionDemo.EndPoints
{
    // Endpoint... not EndPoint
    public class HomeEndpoint
    {
        public HomeViewModel Index(HomeInputModel model)
        {
            return new HomeViewModel();
        }

        public LoginViewModel post_login(LoginInputModel model)
        {
            var myConnection = new SqlConnection(@"Data Source=SLV-JACMELI01;Initial Catalog=Users;Integrated Security=True");
            myConnection.Open();

            //// Safer route
            //SqlParameter paramUsername = new SqlParameter("@Param1", SqlDbType.VarChar, 50);
            //SqlParameter paramPassword = new SqlParameter("@Param2", SqlDbType.VarChar, 50);

            //paramUsername.Value = model.Username;
            //paramPassword.Value = model.Password;
            
            //var query = "Select * From Users.dbo.People Where UserName = @Param1 And Password = @Param2";
            //var cmd = new SqlCommand(query, myConnection);
            //cmd.Parameters.Add(paramUsername);
            //cmd.Parameters.Add(paramPassword);

            var query = "Select * From Users.dbo.People Where UserName = '" + model.Username + "' And Password = '" + model.Password + "'";
            var cmd = new SqlCommand(query, myConnection);
            var myReader = cmd.ExecuteReader();
            var newModel = new LoginViewModel { Users = null};

            //newModel.UserName = myReader["UserName"].ToString();
            //newModel.Password = myReader["Password"].ToString();
            //newModel.FirstName = myReader["FirstName"].ToString();
            //newModel.LastName = myReader["LastName"].ToString();
            var users = new List<User>();
            while (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    var user = new User()
                    {
                        UserName = myReader["UserName"].ToString(),
                        Password = myReader["Password"].ToString(),
                        FirstName = myReader["FirstName"].ToString(),
                        LastName = myReader["LastName"].ToString()

                    };
                    users.Add(user);
                }
                myReader.NextResult();
            }

            if(users.Count > 0)
                newModel.Users = users;

            myConnection.Close();

            return newModel;
        }
    }

    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class LoginInputModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginViewModel
    {
        public List<User> Users { get; set; }
    }

    public class HomeInputModel
    {
    }

    public class HomeViewModel
    {
    }
}