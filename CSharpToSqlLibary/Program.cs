using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLibrary;

namespace CSharpToSqlLibary {
	class Program {
		static void Main(string[] args) {

			VendorsController VendorCtrl = new VendorsController(@"dsi-workstation\SQLEXPRESS", "prssql");

			IEnumerable<Vendor> vendors = VendorCtrl.List();
			Vendor v1 = VendorCtrl.Get(1);
			int AmazonId = v1.Id;

			v1.Name = "Amazon, Inc.";
			VendorCtrl.Change(v1);

			v1.Id = 0;
			v1.Name = "Walmart";
			v1.Code = "WALM";
			VendorCtrl.Create(v1);

			v1.Id = 3;
			VendorCtrl.Remove(v1);

			VendorCtrl.CloseConnection();

/*
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

*/

		}
	}
}
