using HappyPaws.API.Auth.Contracts.Model;
using HappyPaws.Core.Enums;
using Microsoft.AspNetCore.Authorization;

namespace HappyPaws.API.Auth.Handlers
{
    public class SameUserAuthorizationHandler : AuthorizationHandler<SameUserRequirement, IUserOwnedResource>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameUserRequirement requirement, IUserOwnedResource resource)
        {
            if (context.User.IsInRole(UserType.Admin.ToString()) || context.User.FindFirst("UserId")?.Value == resource.UserId.ToString())
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
    public record SameUserRequirement : IAuthorizationRequirement;
}
