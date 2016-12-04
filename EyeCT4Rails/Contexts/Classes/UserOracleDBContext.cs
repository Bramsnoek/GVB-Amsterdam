using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace EyeCT4Rails
{
    public sealed class UserOracleDBContext : IGenericContext<User>
	{
        private OracleDatabase database;

		public UserOracleDBContext()
        {
            database = new OracleDatabase();
        }

        public List<User> Get()
        {
            List<User> users = new List<User>();

            foreach (DataRow row in database.SelectData(new OracleCommand("SELECT * FROM SYSTEMUSER")).Rows)
            {
                User user = null;
                user = new User(
                    Convert.ToInt32(row["id"].ToString()),
                    row["username"].ToString(),
                    row["firstname"].ToString(),
                    row["lastname"].ToString(),
                    row["email"].ToString(),
                    new Group(Convert.ToInt32(row["USERGROUP_ID"].ToString()))
                );

                foreach(DataRow dr in database.SelectData(new OracleCommand("SELECT LOGIN_DATE FROM USER_LOGIN WHERE USER_ID="+row["id"])).Rows)
                {
                    user.Logins.Add(Convert.ToDateTime(dr["LOGIN_DATE"].ToString()));
                }

                users.Add(user);
            }
           
            return users;
        }

        public string GetPassword(string username)
        {
            return database.SelectData(new OracleCommand("SELECT PASSWORD FROM SYSTEMUSER WHERE USERNAME=:USERNAME")
				, new OracleParameter[]
            {
					new OracleParameter("USERNAME", username)
			}).Rows[0]["PASSWORD"].ToString();
        }

        public int Insert(User user)
        {
            return (database.CallFunction(new OracleCommand("INSERTUSER"), OracleDbType.Int32, "RETURNV", new CustomOracleParameter[]
            {
                new CustomOracleParameter(OracleDbType.Int32, "GroupID", user.Group.ID),
                new CustomOracleParameter(OracleDbType.Varchar2, "Name", user.Username),
                new CustomOracleParameter(OracleDbType.Varchar2, "First", user.FirstName),
                new CustomOracleParameter(OracleDbType.Varchar2, "Last", user.LastName),
                new CustomOracleParameter(OracleDbType.Varchar2, "Pass", user.Password),
                new CustomOracleParameter(OracleDbType.Varchar2, "Email", user.Email),
				new CustomOracleParameter(OracleDbType.Int32, "attempts", 0)
            }));
        }

		public bool insertLogin(User user)
		{
			return database.InsertData(new OracleCommand("INSERT INTO USER_LOGIN (USER_ID) VALUES (:ID)"),
				 new OracleParameter[] {
					new OracleParameter("ID", user.ID),
				});
		}

		public bool SetPassword(User user)
        {
            return database.InsertData(
                new OracleCommand("UPDATE SYSTEMUSER SET PASSWORD=:PASS WHERE USERNAME=:UNAME"), 
                new OracleParameter[] {
                    new OracleParameter("PASS", user.Password),
                    new OracleParameter("UNAME", user.Username)
                }
            );
        }

        public bool Update(User user)
		{
            if (user.Group != null)
			{
				return database.InsertData(new OracleCommand("UPDATE SYSTEMUSER SET USERGROUP_ID=:GroupID, FIRSTNAME=:First, LASTNAME=:Last, USERNAME=:Name,  EMAIL=:Email WHERE ID=:ID"),
				new OracleParameter[]
				{
					new OracleParameter("ID", user.ID),
					new OracleParameter("First", user.FirstName),
					new OracleParameter("Last", user.LastName),
					new OracleParameter("Name", user.Username),
					new OracleParameter("GroupID", user.Group.ID),
					new OracleParameter("Email", user.Email)
				});

			}
			else
			{
				return database.InsertData(new OracleCommand("UPDATE SYSTEMUSER SET FIRSTNAME = :First, LASTNAME = :Last, USERNAME= :Name, EMAIL= :Email WHERE ID = :ID"),
				new OracleParameter[]
				{
					new OracleParameter("ID", user.ID),
					new OracleParameter("First", user.FirstName),
					new OracleParameter("Last", user.LastName),
					new OracleParameter("Name", user.Username),
					new OracleParameter("Email", user.Email)
				});
			}
		}
    }
}
