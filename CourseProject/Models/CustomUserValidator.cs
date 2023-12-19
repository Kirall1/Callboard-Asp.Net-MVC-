using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class CustomUserValidator<TUser> : UserValidator<TUser> where TUser : IdentityUser
{
    public override async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
    {
        var result = await base.ValidateAsync(manager, user);

        var phoneNumber = await manager.GetPhoneNumberAsync(user);
        if (!string.IsNullOrEmpty(phoneNumber))
        {
            var existingUser = await manager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            if (existingUser != null && !EqualityComparer<TUser>.Default.Equals(existingUser, user))
            {
                List<IdentityError> errors = new List<IdentityError>()
                {
                    new IdentityError
                {
                    Code = "DuplicatePhoneNumber",
                    Description = "Phone number is already in use.",
                }
                };
                result = IdentityResult.Failed(errors.ToArray());
            }
        }

        return result;
    }
}