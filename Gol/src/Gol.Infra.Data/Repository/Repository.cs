using Gol.Domain.Core.Entites;
using Gol.Domain.Interface;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gol.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        private readonly string _tableName;

        protected Repository(string tableName)
        {
            _tableName = tableName;
        }
        private SqlConnection SqlConnection()
        {
            //colocar em uma varivavel de ambiente seria mais interessante
            return new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Integrated Security=true;Initial Catalog=Gol;");
        }

        protected IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            conn.Open();
            return conn;
        }


        private IEnumerable<PropertyInfo> GetProperties => typeof(TEntity).GetProperties();

        public void Add(TEntity obj)
        {
            var insertQuery = GenerateInsertQuery();

            using (var connection = CreateConnection())
            {
                connection.Execute(insertQuery, obj);
            }
        }

        public void Update(TEntity obj)
        {
            var updateQuery = GenerateUpdateQuery();

            using (var connection = CreateConnection())
            {
                connection.Execute(updateQuery, obj);
            }
        }

        public void Remove(Guid id)
        {
            using (var connection = CreateConnection())
            {
                connection.Execute($"DELETE FROM {_tableName} WHERE Id=@Id", new { Id = id });
            }
        }

        public TEntity GetById(Guid id)
        {
            using (var connection = CreateConnection())
            {
                return connection.QuerySingleOrDefault<TEntity>($"SELECT * FROM {_tableName} WHERE Id=@Id", new { Id = id });

            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<TEntity>($"SELECT * FROM {_tableName}");
            }
        }

        public IEnumerable<TEntity> GetGenericWhere(string conditions)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<TEntity>($"SELECT * FROM {_tableName} WHERE {conditions}");
            }
        }

        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {

            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "IGNORE"
                    select prop.Name).ToList();
        }

        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);
            properties = properties.Where(p => p != "DateInsert").ToList();

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }

        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            return insertQuery.ToString();
        }

        public void Dispose()
        {
            //Dispose();
        }
    }
}