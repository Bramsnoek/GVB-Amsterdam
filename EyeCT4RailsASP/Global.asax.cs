using AutoMapper;
using EyeCT4RailsASP.App_Start;
using EyeCT4RailsBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace EyeCT4RailsASP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
			Mapper.Initialize(c => c.AddProfile<MappingProfile>());
			GlobalConfiguration.Configure(WebApiConfig.Register);
			AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

		protected void Session_Start(object sender, EventArgs e)
		{
			Session["Remise"] = new Remise();
			Session["ValidateUser"] = new ValidateUser();
		}
	}
}
