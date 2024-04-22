using ISRConf.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ISRConf.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ISRConfController : AbpControllerBase
{
    protected ISRConfController()
    {
        LocalizationResource = typeof(ISRConfResource);
    }
}
