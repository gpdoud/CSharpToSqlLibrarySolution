using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary {

	public class UsersController {

		SqlConnection conn = null;
		SqlCommand cmd = new SqlCommand();

		private void SetupCommand(SqlConnection conn, string sql) {
			cmd.Connection = conn;
			cmd.CommandText = sql;
			cmd.Parameters.Clear();
		}
		public IEnumerable<User> List() {
			string sql = "SELECT * from [User];";
			SetupCommand(conn, sql);
			SqlDataReader reader = cmd.ExecuteReader();
			List<User> users = new List<User>();
			while(reader.Read()) {
				// users.Add(new User(reader));
				User user = new User(reader);
				users.Add(user);
			}
			reader.Close();
			return users;
		}
		public User Get(int id) {
			string sql = "SELECT * from [User] where Id = @id";
			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@id", id));
			SqlDataReader reader = cmd.ExecuteReader();
			if(reader.HasRows == false) {
				reader.Close();
				return null;
			}
			reader.Read();
			User user = new User(reader);
			reader.Close();
			return user;
		}
		public bool Create(User user) {
			// string sql = User.SelectStatement;
			string sql = "INSERT into [User] " +
				" (Username, Password, Firstname, Lastname, Phone, Email, IsReviewer, IsAdmin) " +
				" VALUES " +
				" (@Username, @Password, @Firstname, @Lastname, @Phone, @Email, @IsReviewer, @IsAdmin) ";
			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@Username", user.Username));
			cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
			cmd.Parameters.Add(new SqlParameter("@Firstname", user.Firstname));
			cmd.Parameters.Add(new SqlParameter("@Lastname", user.Lastname));
			cmd.Parameters.Add(new SqlParameter("@Phone", user.Phone));
			cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
			cmd.Parameters.Add(new SqlParameter("@IsReviewer", user.IsReviewer));
			cmd.Parameters.Add(new SqlParameter("@IsAdmin", user.IsAdmin));
			int recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
		}
		public bool Change(User user) {
			// string sql = User.SelectStatement;
			string sql = "UPDATE [User] Set " +
						" Username = @Username, " +
						" Password = @Password, " +
						" Firstname = @Firstname, " +
						" Lastname = @Lastname, " +
						" Phone = @Phone, " +
						" Email = @Email, " +
						" IsReviewer = @IsReviewer, " +
						" IsAdmin = @IsAdmin, " +
						" Active = @Active " +
						" WHERE Id = @id;";

			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@id", user.Id));
			cmd.Parameters.Add(new SqlParameter("@Username", user.Username));
			cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
			cmd.Parameters.Add(new SqlParameter("@Firstname", user.Firstname));
			cmd.Parameters.Add(new SqlParameter("@Lastname", user.Lastname));
			cmd.Parameters.Add(new SqlParameter("@Phone", user.Phone));
			cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
			cmd.Parameters.Add(new SqlParameter("@IsReviewer", user.IsReviewer));
			cmd.Parameters.Add(new SqlParameter("@IsAdmin", user.IsAdmin));
			cmd.Parameters.Add(new SqlParameter("@Active", user.Active));
			int recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
		}
		public bool Remove(User user) {
			string sql = "DELETE From [User] Where Id = @id;";
			SetupCommand(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@id", user.Id));

			int recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
		}

		private SqlConnection CreateAndOpenConnection(string server, string database) {
			string connStr = $"server={server};database={database};Trusted_connection=true;";
			SqlConnection conn = new SqlConnection(connStr);
			conn.Open();
			if(conn.State != System.Data.ConnectionState.Open) {
				throw new ApplicationException("Sql Connection did not open");
			}
			return conn;
		}
		public void CloseConnection() {
			if(conn != null && conn.State == System.Data.ConnectionState.Open) {
				conn.Close();
			}
		}

		public UsersController(string server, string database) {
			conn = CreateAndOpenConnection(server, database);
		}
		public UsersController() {

		}
	}
}
