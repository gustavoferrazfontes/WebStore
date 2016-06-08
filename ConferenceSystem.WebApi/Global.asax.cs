﻿using ConferenceSystem.WebApi.App_Start;
using System;
using System.Web.Http;

namespace ConferenceSystem.WebApi
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(SimpleInjectorWebApiInitializer.Initialize);
        }

      
    }
}