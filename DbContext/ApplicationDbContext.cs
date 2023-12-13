using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RentARide.DbContext
{
    public class ApplicationDbContext
    {
        public SQLiteAsyncConnection Database;

        // Application Database
        public readonly static string nameSpace = "RentARide.DbContext";


        private async Task Init()
        {

            
        }
        public ApplicationDbContext()
        {
                         if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            Database.CreateTableAsync<Membre>();
            Database.CreateTableAsync<Auto>();
            Database.CreateTableAsync<Moto>();
            Database.CreateTableAsync<Station>();
            Database.CreateTableAsync<Vehicule>();
            Database.CreateTableAsync<Velo>();
        }

        public async Task<int> CreateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await Database.InsertAsync(entity);
        }

        public async Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await Database.UpdateAsync(entity);
        }
        public async Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            return await Database.DeleteAsync(entity);
        }

        public List<T> GetTableRows<T>(string tableName)
        {
            object[] obj = new object[] { };
            TableMapping map = new TableMapping(Type.GetType(nameSpace + tableName));
            string query = "SELECT * FROM [" + tableName + "]";

            return Database.QueryAsync(map, query, obj).Result.Cast<T>().ToList();
        }

        public object GetTableRow(string tableName, string column, string value)
        {
            object[] obj = new object[] { };
            TableMapping map = new TableMapping(Type.GetType(nameSpace + tableName));
            string query = "SELECT * FROM " + tableName + " WHERE " + column + "='" + value + "'";

            return Database.QueryAsync(map, query, obj).Result.FirstOrDefault();

        }
    }
}

