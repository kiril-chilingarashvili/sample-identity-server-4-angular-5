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
  public class ConfigClientsStore : IClientStore {

    private readonly InMemoryClientStore _innerStore;
    
    public ConfigClientsStore(IConfiguration config) {
      if (config == null) throw new ArgumentNullException(nameof(config));

      _innerStore = new InMemoryClientStore(
        config.GetClients()
      );
    }

    public Task<Client> FindClientByIdAsync(string clientId) =>
      _innerStore.FindClientByIdAsync(clientId);
  }
}