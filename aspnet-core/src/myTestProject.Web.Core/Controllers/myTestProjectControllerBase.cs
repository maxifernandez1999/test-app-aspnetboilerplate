using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace myTestProject.Controllers
{
    public abstract class myTestProjectControllerBase: AbpController
    {
        protected myTestProjectControllerBase()
        {
            LocalizationSourceName = myTestProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
