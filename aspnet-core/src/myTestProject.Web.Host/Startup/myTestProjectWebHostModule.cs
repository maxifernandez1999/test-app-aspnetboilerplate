using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using myTestProject.Configuration;

namespace myTestProject.Web.Host.Startup
{
    [DependsOn(
       typeof(myTestProjectWebCoreModule))]
    public class myTestProjectWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public myTestProjectWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(myTestProjectWebHostModule).GetAssembly());
        }
    }
}
