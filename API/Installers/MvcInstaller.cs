using CoreFlogger;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            string strApiName = configuration.GetSection("IDSS").GetSection("ApiName").Value;
            string strApiId = configuration.GetSection("IDSS").GetSection("ApiId").Value;
            string strTokenUrl = configuration.GetSection("IDSS").GetSection("TokenUrl").Value;
            string strAuthorityURL = configuration.GetSection("IDSS").GetSection("AuthorityURL").Value;
            string strAuthority = configuration.GetSection("IDSS").GetSection("Authority").Value;
            string strApiSecret = configuration.GetSection("IDSS").GetSection("ApiSecret").Value;
            string strIssuerUri = configuration.GetSection("IDSS").GetSection("IssuerUri").Value;
            bool strRequireHttpsMetadata = Convert.ToBoolean(configuration.GetSection("IDSS").GetSection("RequireHttpsMetadata").Value);

            //services.AddControllers();
            services.AddControllers(opt =>
            {
                opt.Filters.Add(new TrackPerformanceFilter("Tax Collector System", "Tax Collector API"));
                opt.Filters.Add(new TrackUsageFilter("Tax Collector System", "Tax Collector API"));
            });

            List<string> urlList = configuration.GetSection("WebClients:Links").Get<List<string>>();

            string[] clientUrls = urlList.Select(i => i.ToString()).ToArray();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.WithOrigins(clientUrls)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            services.Configure<JwtAuthentication>(configuration.GetSection("JwtAuthentication"));

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Boutique API",
                    Version = "v1",
                    Description = "Boutique System API",
                    Contact = new OpenApiContact
                    {
                        Name = "YIS",
                        Email = "somad.yessoufou@persol.net"//,
                        //Url = new Uri("http://www.persol.net/"),
                    }//,
                    //License = new OpenApiLicense
                    //{
                    //    Name = "Persol Systems Ltd",
                    //    Url = new Uri("http://www.persol.net/"),
                    //}
                });

                x.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            //AuthorizationUrl = new Uri(configuration["IDSS:AuthorityURL"]),
                            //TokenUrl = new Uri(configuration["IDSS:TokenUrl"]),
                            AuthorizationUrl = new Uri(strAuthorityURL),
                            TokenUrl = new Uri(strTokenUrl),
                            Scopes = new Dictionary<string, string>
                            {
                                { "boutiqueapi", "The Scope needed to Access Boutique System API" }
                            },
                        }
                    }
                });

                x.OperationFilter<OAuth2OperationFilter>();

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                        },
                        new[] { "boutiqueapi", "roles" }
                    }
                });
            });

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = strAuthority;
                    options.RequireHttpsMetadata = strRequireHttpsMetadata;
                    options.ApiName = strApiName;
                    options.SaveToken = true;
                    options.EnableCaching = true;
                    options.CacheDuration = TimeSpan.FromMinutes(10); // that's the default
                    options.ApiSecret = strApiSecret;
                });

            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.Authority = configuration["IDSS:Authority"];
            //        options.RequireHttpsMetadata = Convert.ToBoolean(configuration["IDSS:RequireHttpsMetadata"]);
            //        options.ApiName = configuration["IDSS:ApiId"];
            //        options.SaveToken = true;
            //        options.EnableCaching = true;
            //        options.CacheDuration = TimeSpan.FromMinutes(10); // that's the default
            //        options.ApiSecret = configuration["IDSS:ApiSecret"];
            //    });
        }
    }
}
