using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using myTestProject.Authorization;

namespace myTestProject
{
    [DependsOn(
        typeof(myTestProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class myTestProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<myTestProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(myTestProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
