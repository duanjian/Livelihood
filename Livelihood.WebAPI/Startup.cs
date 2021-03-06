﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Microsoft.Owin.Security.OAuth;
using Microsoft.OData.Edm;
using Livelihood.Model;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(Livelihood.WebAPI.Startup))]

namespace Livelihood.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            HttpConfiguration config = new HttpConfiguration();

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            #region Wep API 配置

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //移除XML格式支持
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            #endregion

            #region OData配置

            //启用OData支持
            config.MapODataServiceRoute(routeName: "OData", routePrefix: "odata", model: GetEdmModel());
            app.UseWebApi(config);

            #endregion

            #region 跨域配置

            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);
             

            #endregion

        }

        /// <summary>
        /// OData查询对象配置
        /// </summary>
        /// <returns></returns>
        private IEdmModel GetEdmModel()
        {

            var modelBuilder = new ODataConventionModelBuilder();

            modelBuilder.EntitySet<Todo>("Todo");

            return modelBuilder.GetEdmModel();
        }
    }
}
