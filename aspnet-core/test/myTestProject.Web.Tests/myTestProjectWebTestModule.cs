using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using myTestProject.EntityFrameworkCore;
using myTestProject.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace myTestProject.Web.Tests
{
    [DependsOn(
        typeof(myTestProjectWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class myTestProjectWebTestModule : AbpModule
    {
        public myTestProjectWebTestModule(myTestProjectEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(myTestProjectWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(myTestProjectWebMvcModule).Assembly);
        }
    }
}