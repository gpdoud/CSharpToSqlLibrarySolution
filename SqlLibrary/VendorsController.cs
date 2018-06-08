using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary {

	public class VendorsController {

		SqlConnection conn = null;
		SqlCommand cmd = new SqlCommand();

		private void SetupCommand(SqlConnection conn, string sql) {
			cmd.Connection = conn;
			cmd.CommandText = sql;
			cmd.Parameters.Clear();
		}
		public IEnumerable<Vendor> List() {
			string sql = Vendor.SelectAllStatement;
			SetupCommand(conn, sql);
			SqlDataReader reader = cmd.ExecuteReader();
			List<Vendor> users = new List<Vendor>();
			while (reader.Read()) {
				// users.Add(new Vendor(reader));
				Vendor vendor = new Vendor(reader);
				users.Add(vendor);
			}
			reader.Close();
			return users;
		}
		public Vendor Get(int id) {
			string sql = Vendor.SelectOneStatement;
			SetupCommand(conn, sql);
			Vendor.AddParametersToCommand(id, cmd, Vendor.SqlType.Get);
			SqlDataReader reader = cmd.ExecuteReader();
			if (reader.HasRows == false) {
				reader.Close();
				return null;
			}
			reader.Read();
			Vendor vendor = new Vendor(reader);
			reader.Close();
			return vendor;
		}
		public bool Create(Vendor vendor) {
			// string sql = Vendor.SelectStatement;
			string sql = Vendor.InsertStatement;
			SetupCommand(conn, sql);
			Vendor.AddParametersToCommand(vendor, cmd, Vendor.SqlType.Insert);
			int recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
		}
		public bool Change(Vendor vendor) {
			// string sql = Vendor.SelectStatement;
			string sql = Vendor.UpdateStatement;

			SetupCommand(conn, sql);
			Vendor.AddParametersToCommand(vendor, cmd, Vendor.SqlType.Update);
			int recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
		}
		public bool Remove(Vendor vendor) {
			string sql = Vendor.DeleteStatement;
			SetupCommand(conn, sql);
			Vendor.AddParametersToCommand(vendor, cmd, Vendor.SqlType.Delete);

			int recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
		}

		private SqlConnection CreateAndOpenConnection(string server, string database) {
			string connStr = $"server={server};database={database};Trusted_connection=true;";
			SqlConnection conn = new SqlConnection(connStr);
			conn.Open();
			if (conn.State != System.Data.ConnectionState.Open) {
				throw new ApplicationException("Sql Connection did not open");
			}
			return conn;
		}
		public void CloseConnection() {
			if (conn != null && conn.State == System.Data.ConnectionState.Open) {
				conn.Close();
			}
		}

		public VendorsController(string server, string database) {
			conn = CreateAndOpenConnection(server, database);
		}
		public VendorsController() {

		}
	}
}
