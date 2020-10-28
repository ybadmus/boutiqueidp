// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace src
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.Email(),
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
                   };

        public static IEnumerable<ApiResource> GetApiResources =>
            new ApiResource[]
            {
                new ApiResource("boutiqueapi", "Boutique System API")
                {
                    ApiSecrets = { new Secret("03B2C4354FF046F99F53F95D0792AAD9".Sha256()) }
                },
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("boutiqueapi")
            };

        public static IEnumerable<Client> GetClients(IConfiguration configuration) =>
            new Client[]
            {
                // Client for the Boutique API application
                new Client
                {
                    ClientId = "BoutiqueCode",
                    ClientName = "Boutique Code",

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RequireConsent = false,
                    RedirectUris = new []
                    {
                        "http://localhost/BoutiqueAPI/signin-oidc",
                        "http://localhost/BoutiqueAPI/swagger/signin-oidc"
                    },

                    PostLogoutRedirectUris = new []
                    {
                        "http://localhost/BoutiqueAPI/signout-callback-oidc",
                        "http://localhost/BoutiqueAPI/swagger/signout-callback-oidc"
                    },
                    AllowedCorsOrigins = new []
                    {
                        "http://localhost"
                    },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "boutiqueapi"
                    }
                },

                //Client for the Boutique Swagger API application
                new Client
                {
                    ClientId = "BoutiqueImplicit",
                    ClientName = "Boutique Implicit",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new [] {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "boutiqueapi"
                    },
                    RequireConsent = false,
                    AllowAccessTokensViaBrowser = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowOfflineAccess = true,
                    AllowedCorsOrigins = new []
                    {
                        "http://localhost",
                        "http://localhost/BoutiqueAPI"
                    },
                    RedirectUris =  new []
                    {
                        "http://localhost/BoutiqueAPI",
                        "http://localhost/BoutiqueAPI/swagger/oauth2-redirect.html"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost/BoutiqueAPI/swagger",
                        "http://localhost/BoutiqueAPI"
                    }
                },

                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "boutiqueapi" }
                }
            };
    }
}
