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

  public class ConfigResourceStore : IResourceStore {

    private readonly InMemoryResourcesStore _innerStore;

    public ConfigResourceStore(IConfiguration config) {
      if (config == null) throw new ArgumentNullException(nameof(config));

      _innerStore = new InMemoryResourcesStore(
        config.GetIdentities(),
        config.GetApis()
      );
    }

    public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames) =>
      _innerStore.FindIdentityResourcesByScopeAsync(scopeNames);

    public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames) =>
      _innerStore.FindApiResourcesByScopeAsync(scopeNames);

    public Task<ApiResource> FindApiResourceAsync(string name) =>
      _innerStore.FindApiResourceAsync(name);

    public Task<Resources> GetAllResourcesAsync() =>
      _innerStore.GetAllResourcesAsync();
  }
}