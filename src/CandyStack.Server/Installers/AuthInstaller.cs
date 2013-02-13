using Funq;
using ServiceStack.ServiceInterface.Auth;

namespace CandyStack.Server.Installers
{
	public class AuthInstaller : IFunqInstaller
	{
		public void Install(Container container)
		{
			var userRepo = new InMemoryAuthRepository();

			container.Register<IUserAuthRepository>(userRepo);

			//HACK: Add default users
			var users = new[]
				{
					new User("Admin", "AdminPassword"),
					new User("cyberzed", "cyberzed")
				};

			foreach (var user in users)
			{
				string hash;
				string salt;

				new SaltedHash().GetHashAndSaltString(user.Password, out hash, out salt);

				userRepo.CreateUserAuth(
					new UserAuth
						{
							DisplayName = user.Username,
							UserName = user.Username,
							PasswordHash = hash,
							Salt = salt
						},
					user.Password);
			}
		}

		private class User
		{
			public User(string username, string password)
			{
				Username = username;
				Password = password;
			}

			public string Username { get; set; }
			public string Password { get; set; }
		}
	}
}