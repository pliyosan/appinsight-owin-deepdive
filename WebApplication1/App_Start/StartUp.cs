﻿using ApplicationInsights.OwinExtensions;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using WebApplication1.App_Start;

[assembly: OwinStartup(typeof(StartUp))]

namespace WebApplication1.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            app.UseApplicationInsights();
            app.UseWebApi(config);
            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello, world.");
            });
        }
    }
}