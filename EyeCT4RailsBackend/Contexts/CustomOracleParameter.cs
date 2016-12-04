using Oracle.ManagedDataAccess.Client;

namespace EyeCT4RailsBackend
{
	public sealed class CustomOracleParameter
	{
		public OracleDbType OracleDbType { get; private set; }
		public string Parametername { get; private set; }
		public object Parametervalue { get; private set; }

		public CustomOracleParameter(OracleDbType OracleDbType, string Parametername, object ParameterValue)
		{
			this.OracleDbType = OracleDbType;
			this.Parametername = Parametername;
			this.Parametervalue = ParameterValue;
		}
	}
}
