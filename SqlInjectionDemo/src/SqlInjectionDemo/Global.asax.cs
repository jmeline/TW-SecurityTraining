using System;
using System.Web;

namespace SqlInjectionDemo
{
	public class Global : HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
	    	new App().BuildApplication().Bootstrap();
		}
	}	
}