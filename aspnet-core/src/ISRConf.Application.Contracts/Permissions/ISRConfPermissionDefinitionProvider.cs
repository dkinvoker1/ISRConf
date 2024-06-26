﻿using ISRConf.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ISRConf.Permissions;

public class ISRConfPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ISRConfPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ISRConfPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ISRConfResource>(name);
    }
}
