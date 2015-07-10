using System;
using System.Collections.Generic;
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

            return new LoginViewModel();
        }
    }

    public class LoginInputModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginViewModel
    {
    }

    public class HomeInputModel
    {
    }

    public class HomeViewModel
    {
    }
}