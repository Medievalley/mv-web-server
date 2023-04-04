using Dapper;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace DataAccess.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(IConfiguration configuration, ILogger<UserRepository> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> CreateUser(UserEntity userEntity)
        {
            try
            {
                using var connection = new NpgsqlConnection(_configuration.GetConnectionString("Default"));
                int rowsAffected = await connection.ExecuteAsync
                    ("INSERT INTO users (id, login, ip) VALUES (@Id, @Login, @Ip)",
                    new { userEntity.Id, userEntity.Login, userEntity.Ip });

                return rowsAffected;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while CreateUser query");
                return -1;
            }
        }

        public async Task<int> UpdateUser(UserEntity userEntity)
        {

            try
            {
                using var connection = new NpgsqlConnection(_configuration.GetConnectionString("Default"));
                int rowsAffected = await connection.ExecuteAsync
                    ("UPDATE users SET login = @Login, ip = @Ip WHERE id = @Id",
                    new { userEntity.Id, userEntity.Login, userEntity.Ip });

                return rowsAffected;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while UpdateUser query");
                return -1;
            }
        }

        public async Task<int> DeleteUser(string userId)
        {
            try
            {
                var connection = new NpgsqlConnection(_configuration.GetConnectionString("Default"));
                var rowsAffected = await connection.ExecuteAsync
                    ("DELETE FROM users WHERE id = @Id", new { Id = userId });

                return rowsAffected;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while DeleteUser query");
                return -1;
            }
        }

        public async Task<UserEntity> GetUserById(string userId)
        {
            try
            {
                using var connection = new NpgsqlConnection(_configuration.GetConnectionString("Default"));
                var user = await connection.QuerySingleAsync<UserEntity>
                    (@"SELECT id, login, ip FROM 
                   users WHERE id = @Id",
                    new { Id = userId });

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while GetUserById query");
                return new UserEntity();
            }
        }
    }
}
