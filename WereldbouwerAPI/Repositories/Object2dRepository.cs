using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace WereldbouwerAPI
{
    public class Object2DRepository : IObject2DRepository
    {
        private readonly string sqlConnectionString;

        public Object2DRepository(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }

        public async Task<IEnumerable<Object2D>> GetByEnvironmentIdAsync(Guid environmentId)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                return await sqlConnection.QueryAsync<Object2D>(
                    "SELECT * FROM Object2D WHERE EnvironmentId = @EnvironmentId",
                    new { EnvironmentId = environmentId });
            }
        }

        public async Task<Object2D> AddObject2DAsync(Object2D object2D)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync(
                    "INSERT INTO Object2D (Id, EnvironmentId, PrefabId, PositionX, PositionY, ScaleX, ScaleY, RotationZ, SortingLayer) " +
                    "VALUES (@Id, @EnvironmentId, @PrefabId, @PositionX, @PositionY, @ScaleX, @ScaleY, @RotationZ, @SortingLayer)",
                    object2D);
                return object2D;
            }
        }


        public async Task DeleteAllByEnvironmentIdAsync(Guid environmentId)
        {
            using (var sqlConnection = new SqlConnection(sqlConnectionString))
            {
                await sqlConnection.ExecuteAsync("DELETE FROM Object2D WHERE EnvironmentId = @EnvironmentId", new { EnvironmentId = environmentId });
            }
        }
    }
}
