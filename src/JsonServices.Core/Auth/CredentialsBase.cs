﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace JsonServices.Auth
{
	public class CredentialsBase : ICredentials
	{
		public CredentialsBase()
		{
		}

		public CredentialsBase(string userName, string password)
		{
			UserName = userName;
			Password = password;
		}

		public string UserName
		{
			get { return Parameters[AuthRequest.UserNameKey] as string; }
			set { Parameters[AuthRequest.UserNameKey] = value; }
		}

		public string Password
		{
			get { return Parameters[AuthRequest.PasswordKey] as string; }
			set { Parameters[AuthRequest.PasswordKey] = value; }
		}

		public Dictionary<string, string> Parameters { get; } = new Dictionary<string, string>();

		public virtual async Task Authenticate(JsonClient client)
		{
			var authRequest = new AuthRequest
			{
				Parameters = Parameters,
			};

			await client.Call(authRequest);
		}
	}
}