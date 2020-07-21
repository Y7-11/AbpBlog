using AbpBlog.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpBlog.Permissions
{
    public class AbpBlogPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpBlogPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpBlogPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpBlogResource>(name);
        }
    }
}
