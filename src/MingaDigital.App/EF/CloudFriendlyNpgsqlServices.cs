using System;

using System.Data.Common;
using System.Data.Entity.Core.Metadata.Edm;

namespace Npgsql
{
    public class CloudFriendlyNpgsqlServices : NpgsqlServices
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
}