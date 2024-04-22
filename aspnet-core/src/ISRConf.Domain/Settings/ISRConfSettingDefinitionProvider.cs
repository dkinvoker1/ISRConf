using Volo.Abp.Settings;

namespace ISRConf.Settings;

public class ISRConfSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ISRConfSettings.MySetting1));
    }
}
