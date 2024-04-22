using System;
using System.Collections.Generic;
using System.Text;
using ISRConf.Localization;
using Volo.Abp.Application.Services;

namespace ISRConf;

/* Inherit your application services from this class.
 */
public abstract class ISRConfAppService : ApplicationService
{
    protected ISRConfAppService()
    {
        LocalizationResource = typeof(ISRConfResource);
    }
}
