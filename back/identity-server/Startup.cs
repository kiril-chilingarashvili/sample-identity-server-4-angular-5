using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace identity_server {
  
  public class Startup {

    public void ConfigureServices(IServiceCollection services) {
      services.AddIdentityServer()
        
        // Uncomment the following line in production, also implement GetSigningCertificate
        // .AddSigningCredential(GetSigningCertificate())
        
        // Comment the following line in production
        .AddDeveloperSigningCredential()

        .AddClientStore<ConfigClientsStore>()
        .AddResourceStore<ConfigResourceStore>()
        .AddProfileService<ConfigProfileService>()
        .AddResourceOwnerValidator<ConfigPasswordValidator>();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }

      app.UseIdentityServer();
    }

    // public static RsaSecurityKey GetSigningCertificate() {
    //  var filename = Path.Combine(Directory.GetCurrentDirectory(), "certificateKey.rsa");

    //     if (File.Exists(filename))
    //     {
    //         var keyFile = File.ReadAllText(filename);
    //         var tempKey = JsonConvert.DeserializeObject<TemporaryRsaKey>(keyFile, new JsonSerializerSettings() { ContractResolver = new RsaKeyContractResolver() });

    //         return CreateRsaSecurityKey(tempKey.Parameters, tempKey.KeyId);
    //     }
    //     else
    //     {
    //         var key = CreateRsaSecurityKey();

    //         RSAParameters parameters;

    //         if (key.Rsa != null)
    //             parameters = key.Rsa.ExportParameters(includePrivateParameters: true);
    //         else
    //             parameters = key.Parameters;

    //         var tempKey = new TemporaryRsaKey
    //         {
    //             Parameters = parameters,
    //             KeyId = key.KeyId
    //         };

    //         File.WriteAllText(filename, JsonConvert.SerializeObject(tempKey, new JsonSerializerSettings() { ContractResolver = new RsaKeyContractResolver() }));

    //         return CreateRsaSecurityKey(tempKey.Parameters, tempKey.KeyId);
    //     }
    // }
  }
}