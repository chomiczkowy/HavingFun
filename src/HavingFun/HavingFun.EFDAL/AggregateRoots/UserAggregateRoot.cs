using HavingFun.Common.DDD;
using HavingFun.Common.Interfaces.BLL;
using HavingFun.Common.Models;
using HavingFun.EFDAL.Context;
using HavingFun.EFDAL.Entities;

namespace HavingFun.EFDAL.AggregateRoots
{
    public class UserAggregateRoot : AggregateRoot<User, MainDBContext>
    {
        public UserAggregateRoot(User user, MainDBContext context) : base(user, context) { }

        public int AddNew(EditUserModel userModel, IPasswordHasher passwordHasher)
        {
            var newUser = new User()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                PasswordHash = passwordHasher.HashPassword(userModel.Password),
                Username = userModel.Username,
                EmailAddress = userModel.EmailAddress,
                IsActivated = false
            };

            if (userModel.Claims != null)
            {
                foreach (var claim in userModel.Claims)
                {
                    newUser.UserClaims.Add(new UserClaims()
                    {
                        Claim = new EFDAL.Entities.Claim()
                        {
                            Type = claim.Type,
                            Value = claim.Value
                        }
                    });
                }
            }

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return newUser.Id;
        }
    }
}
