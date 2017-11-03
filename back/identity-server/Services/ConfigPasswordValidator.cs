using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Test;
using IdentityServer4.Validation;
using Microsoft.Extensions.Configuration;

namespace identity_server {
  public class ConfigPasswordValidator : IResourceOwnerPasswordValidator {

    private List<TestUser> _testUsers;

    public ConfigPasswordValidator(IConfiguration config) {
      if (config == null) throw new ArgumentNullException(nameof(config));

      _testUsers = config.GetTestUsers().ToList();
    }

    public Task ValidateAsync(ResourceOwnerPasswordValidationContext context) {
      var user = _testUsers.FirstOrDefault(
        x => x.Username == context.UserName && x.Password == context.Password
      );

      context.Result = user == null ? new GrantValidationResult(
        TokenRequestErrors.InvalidRequest, "Login Failed"
      ) : new GrantValidationResult(
        user.SubjectId, "password"
      );

      return Task.FromResult(0);
    }
  }
}