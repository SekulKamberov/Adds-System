namespace AddsSystem.Client
{
    using AddsSystem.Client.App_Start;
    using AddsSystem.Client.Mappings;
    using AddsSystem.Common.Constants;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.DataServices));
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperConfig>());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
