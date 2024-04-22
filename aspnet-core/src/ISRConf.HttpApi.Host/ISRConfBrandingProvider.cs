using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ISRConf;

[Dependency(ReplaceServices = true)]
public class ISRConfBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ISRConf";
}
