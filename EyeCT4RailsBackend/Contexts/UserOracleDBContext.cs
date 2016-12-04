using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using ExtendedObservableCollection;

namespace EyeCT4RailsBackend
{
    public sealed class UserOracleDBContext : IUserContext
	{
        private OracleDatabase database;

        public UserOracleDBContext()
        {
            database = new OracleDatabase();
        }

        public void Remove(User user)
        {
            throw new NotSupportedException();
        }

        public ExtendedObservableCollection<User> Get()
        {
            List<User> Users = new List<User>();

            foreach (DataRow row in database.SelectData(new OracleCommand("SELECT * FROM SYSTEMUser")).Rows)
            {
                User User = null;
                User = new User(
                    Convert.ToInt32(row["id"].ToString()),
                    row["Username"].ToString(),
                    row["firstname"].ToString(),
                    row["lastname"].ToString(),
                    row["email"].ToString(),
                    new Group(Convert.ToInt32(row["UserGROUP_ID"].ToString()))
                );

                foreach (DataRow dr in database.SelectData(new OracleCommand("SELECT LOGIN_DATE FROM User_LOGIN WHERE User_ID=" + row["id"])).Rows)
                {
                    User.Logins.Add(Convert.ToDateTime(dr["LOGIN_DATE"].ToString()));
                }

                Users.Add(User);
            }

            return new ExtendedObservableCollection<User>(Users);
        }

        public string GetPassword(string Username)
        {
            return database.SelectData(new OracleCommand("SELECT PASSWORD FROM SYSTEMUser WHERE UserNAME=:UserNAME")
                , new OracleParameter[]
            {
                    new OracleParameter("UserNAME", Username)
            }).Rows[0]["PASSWORD"].ToString();
        }

        public int Insert(User User)
        {
            return (database.CallFunction(new OracleCommand("INSERTUser"), OracleDbType.Int32, "RETURNV", new CustomOracleParameter[]
            {
                new CustomOracleParameter(OracleDbType.Int32, "GroupID", User.Group.ID),
                new CustomOracleParameter(OracleDbType.Varchar2, "Name", User.Username),
                new CustomOracleParameter(OracleDbType.Varchar2, "First", User.FirstName),
                new CustomOracleParameter(OracleDbType.Varchar2, "Last", User.LastName),
                new CustomOracleParameter(OracleDbType.Varchar2, "Pass", User.Password),
                new CustomOracleParameter(OracleDbType.Varchar2, "Email", User.Email),
                new CustomOracleParameter(OracleDbType.Int32, "attempts", 0)
            }));
        }

        public bool insertLogin(User User)
        {
            return database.InsertData(new OracleCommand("INSERT INTO User_LOGIN (User_ID) VALUES (:ID)"),
                 new OracleParameter[] {
                    new OracleParameter("ID", User.ID),
                });
        }

        public bool SetPassword(User User)
        {
            return database.InsertData(
                new OracleCommand("UPDATE SYSTEMUser SET PASSWORD=:PASS WHERE UserNAME=:UNAME"),
                new OracleParameter[] {
                    new OracleParameter("PASS", User.Password),
                    new OracleParameter("UNAME", User.Username)
                }
            );
        }

        public void Update(User User)
        {
            if (User.Group != null)
            {
                database.InsertData(new OracleCommand("UPDATE SYSTEMUser SET UserGROUP_ID=:GroupID, FIRSTNAME=:First, LASTNAME=:Last, UserNAME=:Name,  EMAIL=:Email WHERE ID=:ID"),
                new OracleParameter[]
                {
                    new OracleParameter("ID", User.ID),
                    new OracleParameter("First", User.FirstName),
                    new OracleParameter("Last", User.LastName),
                    new OracleParameter("Name", User.Username),
                    new OracleParameter("GroupID", User.Group.ID),
                    new OracleParameter("Email", User.Email)
                });

            }
            else
            {
                database.InsertData(new OracleCommand("UPDATE SYSTEMUser SET FIRSTNAME = :First, LASTNAME = :Last, UserNAME= :Name, EMAIL= :Email WHERE ID = :ID"),
                new OracleParameter[]
                {
                    new OracleParameter("ID", User.ID),
                    new OracleParameter("First", User.FirstName),
                    new OracleParameter("Last", User.LastName),
                    new OracleParameter("Name", User.Username),
                    new OracleParameter("Email", User.Email)
                });
            }
        }
    }
}
