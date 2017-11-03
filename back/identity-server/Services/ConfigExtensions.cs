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

  internal static class ConfigExtensions {
    private class ClientConfig : Client {
      public List<string> Secrets {
        get { return ClientSecrets.Select(x => x.Value).ToList(); }
        set { ClientSecrets = value.Select(x => new Secret(x.Sha256())).ToHashSet();  }
      }
    }

    private static IEnumerable<T> Get<T>(this IConfiguration config, string section) {
      if (config == null) throw new ArgumentException(nameof(config));
      if (section == null) throw new ArgumentException(nameof(section));
      var configSection = config.GetSection($"identityServer:{section}");
      if (configSection.Exists()) return configSection.Get<IEnumerable<T>>();
      throw new ArgumentException($"Invalid configuration section {section}");
    }

    internal static IEnumerable<IdentityResource> GetIdentities(this IConfiguration config) =>
      new IdentityResource[] {
          new IdentityResources.OpenId(),
          new IdentityResources.Email()
      };
    
    internal static IEnumerable<ApiResource> GetApis(this IConfiguration config) =>
      config.Get<ApiResource>("apis");
    
    internal static IEnumerable<Client> GetClients(this IConfiguration config) =>
      config.Get<ClientConfig>("clients");
    
    internal static IEnumerable<TestUser> GetTestUsers(this IConfiguration config) =>
      config.Get<TestUser>("testUsers");
  }
}