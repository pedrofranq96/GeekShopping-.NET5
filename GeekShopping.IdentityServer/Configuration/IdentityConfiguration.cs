using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System.Collections.Generic;

namespace GeekShopping.IdentityServer.Configuration
{
	public static class IdentityConfiguration
	{
		public const string Admin = "Admin";
		public const string Client = "Client";

		public static IEnumerable<IdentityResource> IdentityResources =>
			new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Email(),
				new IdentityResources.Profile()
			};

		public static IEnumerable<ApiScope> apiScopes =>
			new List<ApiScope>
			{
				new ApiScope("geek_shooping", "GeekShopping Server"),
				new ApiScope(name: "read", "Read data."),
				new ApiScope(name: "write", "Write data."),
				new ApiScope(name: "delete", "Delete data.")
			};
		public static IEnumerable<Client> Clients =>
			new List<Client>
			{
				new Client
				{
					ClientId = "client",
					ClientSecrets = { new Secret("my_super_secret".Sha256())},
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					AllowedScopes = {"read", "write", "profile" }
				},

				new Client
				{
					ClientId = "geek_shooping",
					ClientSecrets = { new Secret("my_super_secret".Sha256())},
					AllowedGrantTypes = GrantTypes.Code,
					RedirectUris = {"https://localhost:4430/signin-oidc"},
					PostLogoutRedirectUris = {"http://localhost:4430/signout-callback-oidc"},
					AllowedScopes = new List<string>
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Email,
						IdentityServerConstants.StandardScopes.Profile,
						"geek_shooping"
					}
				},
			};
	}
}
