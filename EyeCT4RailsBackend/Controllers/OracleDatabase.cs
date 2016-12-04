using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace EyeCT4RailsBackend
{
	public sealed class OracleDatabase
	{
		public static string ConnString { get; set; }

		public OracleDatabase()
		{
//#if (DEBUG)
			ConnString = ConfigurationManager.ConnectionStrings["OracleDBConnection"].ConnectionString;
//#else
			//ConnString = "Data Source=192.168.0.2/xe;User Id=SYSTEM;Password=Passw0rd;";
//#endif
		}

		public DataTable SelectData(OracleCommand command, OracleParameter[] parameters = null)
		{
			try
			{
				DataTable dataTable = new DataTable();

				using (OracleConnection connection = new OracleConnection())
				{
					connection.ConnectionString = ConnString;
					connection.Open();

					command.Connection = connection;

					if (parameters != null)
						command.Parameters.AddRange(parameters);

					OracleDataReader reader = command.ExecuteReader();
					dataTable.Load(reader);

					return dataTable;
				}
			}
			catch (OracleException e)
			{
				Console.Write(e.Message);
				return null;
			}
		}

		public int CallFunction(OracleCommand command, OracleDbType returnType, string returnVarName, CustomOracleParameter[] parameters)
		{
			try
			{
				using (OracleConnection connection = new OracleConnection())
				{
					connection.ConnectionString = ConnString;
					connection.Open();

					command.Connection = connection;
					command.CommandType = CommandType.StoredProcedure;

					command.Parameters.Add(returnVarName, returnType);
					command.Parameters[returnVarName].Direction = ParameterDirection.ReturnValue;

					foreach(CustomOracleParameter parameter in parameters)
					{
						command.Parameters.Add(parameter.Parametername, parameter.OracleDbType);
						command.Parameters[parameter.Parametername].Value = parameter.Parametervalue;
					}

					command.ExecuteNonQuery();
					return int.Parse(command.Parameters[returnVarName].Value.ToString());
				}
			}
			catch(OracleException)
			{
				throw;
				//Console.WriteLine(e);
				//return -1;
			}
		}

		public bool InsertData(OracleCommand command, OracleParameter[] parameters)
		{
			try
			{
				using (OracleConnection connection = new OracleConnection(ConnString))
				{
					connection.Open();

					OracleCommand cmd = connection.CreateCommand();
					OracleTransaction transaction;

					transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);

					cmd.Transaction = transaction;

					cmd.CommandText = command.CommandText;

					cmd.BindByName = true;
					cmd.Parameters.AddRange(parameters);

					int check = cmd.ExecuteNonQuery();
					transaction.Commit();

					if (check > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (OracleException e)
			{
				//throw;
				Console.Write(e.Message);
				return false;
			}
		}

	}
}