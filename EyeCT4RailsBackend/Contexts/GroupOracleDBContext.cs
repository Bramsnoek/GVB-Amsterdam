using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
    public sealed class GroupOracleDBContext : IGenericContext<Group>
	{
        private OracleDatabase database;

        public GroupOracleDBContext()
        {
            database = new OracleDatabase();
        }

        /// <summary>
        ///     Get all groups from the database
        /// </summary>
        /// 
        /// <returns>
        ///     A list of groups
        /// </returns>
        public ExtendedObservableCollection<Group> Get()
        {
            List<Group> groups = new List<Group>();
			foreach (DataRow row in database.SelectData(new OracleCommand("SELECT * FROM USER_GROUP")).Rows)
			{
                groups.Add(new Group(
                    Convert.ToInt32(row["ID"]),
                    row["GROUP"].ToString(),
                    Convert.ToInt32(row["PERMISSION"])    
                ));
			}
            return new ExtendedObservableCollection<Group>(groups);
        }

        /// <summary>
        ///     Insert a group in the database
        /// </summary>
        /// 
        /// <param name="group">
        ///     The group that will be parsed into the database
        /// </param>
        /// 
        /// <returns>
        ///     int : 0 if it didn't work.
        /// </returns>
        public int Insert(Group group)
        {
            return (database.CallFunction(new OracleCommand("INSERTGROUP"), OracleDbType.Int32, "RETURNV", new CustomOracleParameter[]
			{
				new CustomOracleParameter(OracleDbType.Varchar2, "GName", group.Name),
				new CustomOracleParameter(OracleDbType.Int32, "PrmID", group.Permission)
            }));
        }

        /// <summary>
        ///     Update a group in the database
        /// </summary>
        /// 
        /// <param name="group">
        ///     All attributes from this group object will be used as new information
        /// </param>
        /// 
        /// <returns>
        ///     bool
        /// </returns>
        public void Update(Group group)
		{
			if (database.SelectData(new OracleCommand("SELECT * FROM USER_GROUP WHERE ID="+group.ID)).Rows.Count > 0)
            {
                database.InsertData(
                    new OracleCommand(
                    "UPDATE USER_GROUP SET PERMISSION_ID = :PrmID, \"GROUP\" = :GName WHERE ID=:ID"),
                    new OracleParameter[]
                    {
                        new OracleParameter("ID", group.ID),
                        new OracleParameter("PrmID", group.Permission),
                        new OracleParameter("GName", group.Name)
                    }
                );
            }
            else
            {

            }
        }

        public void Remove(Group group)
        {
            throw new NotSupportedException();
        }
    }
}
