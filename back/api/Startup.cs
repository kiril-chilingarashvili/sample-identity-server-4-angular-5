using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace api {
  
  public class Startup {

    public void ConfigureServices(IServiceCollection services) {
      services.AddCors();
      services.AddMvc();
      
      services
        .AddAuthentication("Bearer")
        .AddIdentityServerAuthentication(options => {
          options.Authority = "http://localhost:5000";
          options.RequireHttpsMetadata = false;
          options.ApiName = "webApi";
        });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }

      // check if token is supplied with cookies or query string
      // and move it to Authorization header prefixed with Bearer
      app.Use(async (context, next) => {
        const string cookieKey = "token";
        const string qsKey = "access_token";
        const string headerKey = "Authorization";
        
        if (context.Request.Cookies.ContainsKey(cookieKey)) {
          context.Request.Headers[headerKey] = $"Bearer {context.Request.Cookies[cookieKey]}";
        }
        
        if (context.Request.Query.ContainsKey(qsKey)) {
          context.Request.Headers[headerKey] = $"Bearer {context.Request.Query[qsKey]}";
        }

        await next.Invoke();
      });
      
      app.UseAuthentication();
      
      app.UseCors(builder => {
  		  builder.WithOrigins("*");
        builder.WithMethods("*");
		    builder.WithHeaders("*");
	    });

      app.UseMvc();
    }
  }
}