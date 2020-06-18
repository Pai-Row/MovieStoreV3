using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace MovieSelfHost
{
    class clsDbConnection
    {
        private static ConnectionStringSettings ConnectionStringSettings = 
                        ConfigurationManager.ConnectionStrings["MovieDatabase"];
        private static DbProviderFactory ProviderFactory =
                        DbProviderFactories.GetFactory(ConnectionStringSettings.ProviderName);
        private static string ConnectionStr = ConnectionStringSettings.ConnectionString;

        public static DataTable GetDataTable(string prSQL, Dictionary<string, Object> prPars)
        { 
            // for SELECT 
            using (DataTable lcDataTable = new DataTable("TheTable")) 
            using (DbConnection lcDataConnection = ProviderFactory.CreateConnection()) 
            using (DbCommand lcCommand = lcDataConnection.CreateCommand())
            { 
                lcDataConnection.ConnectionString = ConnectionStr;
                lcDataConnection.Open();
                lcCommand.CommandText = prSQL;
                setPars(lcCommand, prPars);
                using (DbDataReader lcDataReader = lcCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    lcDataTable.Load(lcDataReader);
                return lcDataTable; 
            } 
        } 
        public static int Execute(string prSQL, Dictionary<string, Object> prPars) 
        { 
            // for UPDATE, INSERT, DELETE 
            using (DbConnection lcDataConnection = ProviderFactory.CreateConnection()) 
            using (DbCommand lcCommand = lcDataConnection.CreateCommand()) 
            { 
                lcDataConnection.ConnectionString = ConnectionStr; 
                lcDataConnection.Open(); lcCommand.CommandText = prSQL;
                setPars(lcCommand, prPars); 
                return lcCommand.ExecuteNonQuery(); 
            } 
        } 
        private static void setPars(DbCommand prCommand, Dictionary<string, Object> prPars) 
        { 
            // For most DBMS using @Name1, @Name2, @Name3 etc. 
                if (prPars != null)
                    foreach (KeyValuePair<string, Object> lcItem in prPars)
                { 
                    DbParameter lcPar = ProviderFactory.CreateParameter(); 
                    lcPar.Value = lcItem.Value == null ? DBNull.Value : lcItem.Value; 
                    lcPar.ParameterName = '@' + lcItem.Key;
                    prCommand.Parameters.Add(lcPar); 
                } 
        }

    }
}



