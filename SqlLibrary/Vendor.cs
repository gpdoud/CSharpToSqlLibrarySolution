using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary {
	public class Vendor {

		public enum SqlType { Get, Insert, Update, Delete };

		public static string SelectAllStatement = "SELECT * from [Vendor];";
		public static string SelectOneStatement = "SELECT * from [Vendor] WHERE Id=@Id;";
		public static string InsertStatement = "INSERT into [Vendor] (Code, Name, Address, City, State, Zip, Phone, Email, IsPreapproved) " +
												" VALUES (@Code, @Name, @Address, @City, @State, @Zip, @Phone, @Email, @IsPreapproved);";
		public static string UpdateStatement = "UPDATE [Vendor] set Code=@Code, Name=@Name, Address=@Address, City=@City, State=@State, " +
												" Zip=@Zip, Phone=@Phone, Email=@Email, IsPreapproved=@IsPreapproved, Active=@Active " +
												" WHERE Id=@Id;";
		public static string DeleteStatement = "DELETE from [Vendor] WHERE Id=@Id;";

		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public bool IsPreapproved { get; set; }
		public bool Active { get; set; }

		public static void AddParametersToCommand(int id, SqlCommand cmd, SqlType maintType) {
			cmd.Parameters.Add(new SqlParameter("@Id", id));
		}

		public static void AddParametersToCommand(Vendor vendor, SqlCommand cmd, SqlType maintType) {
			if(maintType == SqlType.Update || maintType == SqlType.Delete) {
				cmd.Parameters.Add(new SqlParameter("@Id", vendor.Id));
			}
			if(maintType == SqlType.Insert || maintType == SqlType.Update) {
				cmd.Parameters.Add(new SqlParameter("@Code", vendor.Code));
				cmd.Parameters.Add(new SqlParameter("@Name", vendor.Name));
				cmd.Parameters.Add(new SqlParameter("@Address", vendor.Address));
				cmd.Parameters.Add(new SqlParameter("@City", vendor.City));
				cmd.Parameters.Add(new SqlParameter("@State", vendor.State));
				cmd.Parameters.Add(new SqlParameter("@Zip", vendor.Zip));
				cmd.Parameters.Add(new SqlParameter("@Phone", vendor.Phone));
				cmd.Parameters.Add(new SqlParameter("@Email", vendor.Email));
				cmd.Parameters.Add(new SqlParameter("@IsPreapproved", vendor.IsPreapproved));
			}
			if(maintType == SqlType.Update) {
				cmd.Parameters.Add(new SqlParameter("@Active", vendor.Active));
			}
		}

		public Vendor(SqlDataReader reader) {
			Id = reader.GetInt32(reader.GetOrdinal("Id"));
			Code = reader.GetString(reader.GetOrdinal("Code"));
			Name = reader.GetString(reader.GetOrdinal("Name"));
			Address = reader.GetString(reader.GetOrdinal("Address"));
			City = reader.GetString(reader.GetOrdinal("City"));
			State = reader.GetString(reader.GetOrdinal("State"));
			Zip = reader.GetString(reader.GetOrdinal("Zip"));
			Phone = reader.GetString(reader.GetOrdinal("Phone"));
			Email = reader.GetString(reader.GetOrdinal("Email"));
			IsPreapproved = reader.GetBoolean(reader.GetOrdinal("IsPreapproved"));
			Active = reader.GetBoolean(reader.GetOrdinal("Active"));
		}
		public Vendor() { }
	}
}
