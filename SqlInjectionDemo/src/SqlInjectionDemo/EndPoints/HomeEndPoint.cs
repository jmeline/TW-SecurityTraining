using System;
using System.Collections.Generic;
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
            var query = "Select * From Users.dbo.People Where UserName = '" + model.Username + "' And Password = '" + model.Password + "'";
            var cmd = new SqlCommand(query, myConnection);
            var myReader = cmd.ExecuteReader();
            var newModel = new LoginViewModel();
            if (!myReader.Read()) return newModel;
            newModel.Username = myReader["UserName"].ToString();
            newModel.Password = myReader["Password"].ToString();
            newModel.Firstname = myReader["FirstName"].ToString();
            newModel.Lastname = myReader["LastName"].ToString();
            return newModel;
        }
    }

    public class LoginInputModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }

    public class HomeInputModel
    {
    }

    public class HomeViewModel
    {
    }
}