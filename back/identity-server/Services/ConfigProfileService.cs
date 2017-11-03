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
  public class ConfigProfileService : IProfileService {

    private List<TestUser> _testUsers;

    public ConfigProfileService(IConfiguration config) {
      if (config == null) throw new ArgumentNullException(nameof(config));

      _testUsers = config.GetTestUsers().ToList();
    }

    public Task GetProfileDataAsync(ProfileDataRequestContext context) {
      context.IssuedClaims = context.Subject.Claims.ToList();
      return Task.FromResult(0);
    }

    public Task IsActiveAsync(IsActiveContext context) {
      return Task.FromResult(0);
    }
  }
}