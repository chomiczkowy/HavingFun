using HavingFun.Common.DDD;
using HavingFun.Common.Exceptions;
using HavingFun.Common.Interfaces.BLL;
using HavingFun.Common.Models;
using HavingFun.EFDAL.Context;
using HavingFun.EFDAL.Entities;
using System;
using System.Linq;

namespace HavingFun.EFDAL.AggregateRoots
{
    public class UserAggregateRoot : AggregateRoot<User, MainDBContext>
    {
        public UserAggregateRoot(User user, MainDBContext context) : base(user, context) { }

        public int AddNew(EditUserModel userModel, IPasswordHasher passwordHasher)
        {
            ValidateBeforeAddingNew(userModel);

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

        private void ValidateBeforeAddingNew(EditUserModel userModel)
        {
            if (userModel == null)
            {
                throw new ArgumentException("userModel is null");
            }

            if (string.IsNullOrWhiteSpace(userModel.Username))
            {
                throw new HavingFunBusinessValidationException("Username is required");
            }

            if (string.IsNullOrWhiteSpace(userModel.EmailAddress))
            {
                throw new HavingFunBusinessValidationException("Email Address is required");
            }

            var existingUserByUserName = _context.Users.FirstOrDefault(x => x.Username != null &&
                    x.Username.ToUpper().Equals(userModel.Username.ToUpper()));
            if (existingUserByUserName != null)
            {
                throw new HavingFunBusinessValidationException($"There is already user with given username: {userModel.Username}");
            }

            var existingUserByEmail = _context.Users.FirstOrDefault(x => x.EmailAddress != null &&
                    x.EmailAddress.ToUpper().Equals(userModel.EmailAddress.ToUpper()));
            if (existingUserByEmail != null)
            {
                throw new HavingFunBusinessValidationException($"There is already user with given email: {userModel.EmailAddress}");
            }
        }
    }
}
