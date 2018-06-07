using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLibrary;

namespace CSharpToSqlLibary {
	class Program {
		static void Main(string[] args) {

			UsersController UserCtrl = new UsersController(@"dsi-workstation\SQLEXPRESS", "prssql");

			IEnumerable<User> users = UserCtrl.List();
			foreach(User user1 in users) {
				Console.WriteLine($"{user1.Firstname} {user1.Lastname}");
			}

			User user = UserCtrl.Get(6);
			if(user == null) {
				Console.WriteLine("User not found");
			} else {
				Console.WriteLine($"{user.Firstname} {user.Lastname}");
			}

			user = UserCtrl.Get(999);
			if (user == null) {
				Console.WriteLine("User not found");
			} else {
				Console.WriteLine($"{user.Firstname} {user.Lastname}");
			}

			User newUser = new User();
			newUser.Username = "newuser1";
			newUser.Password = "password";
			newUser.Firstname = "New";
			newUser.Lastname = "User";
			newUser.Phone = "513-555-1212";
			newUser.Email = "new@user.com";
			newUser.IsReviewer = false;
			newUser.IsAdmin = true;

			//bool success = UserCtrl.Create(newUser);

			user = UserCtrl.Get(6);
			user.Firstname = "Kimmie";
			//bool success = UserCtrl.Change(user);

			user = UserCtrl.Get(19);
			if(user != null)
				UserCtrl.Remove(user);

			UserCtrl.CloseConnection();

		}
	}
}
