using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary {

	public class UsersController {

		public IEnumerable<User> List() {
			return new List<User>();
		}
		public User Get(int id) {
			return null;
		}
		public bool Create(User user) {
			return false;
		}
		public bool Change(User user) {
			return false;
		}
		public bool Remove(User user) {
			return false;
		}
	}
}
