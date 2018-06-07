using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary {
	public class User {

		public static string SelectAllStatement = "SELECT * from [User];";
		public static string SelectOneStatement = "SELECT * from [User] WHERE Id = @id;";
		public static string InsertStatement = "INSERT into [User] " +
				" (Username, Password, Firstname, Lastname, Phone, Email, IsReviewer, IsAdmin) " +
				" VALUES " +
				" (@Username, @Password, @Firstname, @Lastname, @Phone, @Email, @IsReviewer, @IsAdmin) ";
		public static string UpdateStatement = "UPDATE [User] Set " +
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
		public static string DeleteStatement = "DELETE from [User] WHERE Id = @id;";

		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public bool IsReviewer { get; set; }
		public bool IsAdmin { get; set; }
		public bool Active { get; set; }



		public User(SqlDataReader reader) {
			Id = reader.GetInt32(reader.GetOrdinal("Id"));
			Username = reader.GetString(reader.GetOrdinal("Username"));
			Password = reader.GetString(reader.GetOrdinal("Password"));
			Firstname = reader.GetString(reader.GetOrdinal("Firstname"));
			Lastname = reader.GetString(reader.GetOrdinal("Lastname"));
			Phone = reader.GetString(reader.GetOrdinal("Phone"));
			Email = reader.GetString(reader.GetOrdinal("Email"));
			IsReviewer = reader.GetBoolean(reader.GetOrdinal("IsReviewer"));
			IsAdmin = reader.GetBoolean(reader.GetOrdinal("IsAdmin"));
			Active = reader.GetBoolean(reader.GetOrdinal("Active"));
		}
		public User() {

		}
	}
}
