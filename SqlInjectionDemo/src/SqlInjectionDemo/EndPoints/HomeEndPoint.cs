using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SqlInjectionDemo.EndPoints
{
    public class HomeEndpoint
    {
        public HomeViewModel Index(HomeInputModel model)
        {
            return new HomeViewModel();
        }

        public HomeViewModel NewIndex(HomeInputModel2 model)
        {
            return new HomeViewModel();
        }
    }

    public class HomeInputModel
    {
    }

    public class HomeInputModel2
    {
    }

    public class HomeViewModel
    {
    }
}