using System;

using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Data.Entity.Core.Metadata.Edm;

using Npgsql;

namespace Npgsql
{
    public class CustomNpgsqlServices : NpgsqlServices
    {
        protected override string GetDbProviderManifestToken(DbConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");
            string serverVersion = "";
            UsingPostgresDBConnection((NpgsqlConnection)connection, conn =>
            {
                serverVersion = conn.ServerVersion;
            });
            return serverVersion;
        }
        
        protected override void DbCreateDatabase(DbConnection connection, int? commandTimeout, StoreItemCollection storeItemCollection)
        {
            // skip
        }
        
        private static void UsingPostgresDBConnection(NpgsqlConnection connection, Action<NpgsqlConnection> action)
        {
            var connectionBuilder = new NpgsqlConnectionStringBuilder(connection.ConnectionString);
            
            using (var masterConnection = new NpgsqlConnection(connectionBuilder.ConnectionString))
            {
                masterConnection.Open();
                action(masterConnection);
            }
        }
    }
    
    public class NpgsqlEFConfiguration : DbConfiguration
    {
        public NpgsqlEFConfiguration()
        {
            SetProviderServices("Npgsql", new CustomNpgsqlServices());
            SetProviderFactory("Npgsql", NpgsqlFactory.Instance);
            SetDefaultConnectionFactory(new NpgsqlConnectionFactory());
            SetMigrationSqlGenerator("Npgsql", () => new NpgsqlMigrationSqlGenerator());
            SetHistoryContext("Npgsql", (conn, schema) => CreateHistoryContext(conn, schema));
        }
        
        private HistoryContext CreateHistoryContext(DbConnection connection, String defaultSchema)
        {
            return new HistoryContext(connection, "public");
        }
    }
}