using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Product_API.MyHealthChecks
{
    public class CheckSQLServer : IHealthCheck
    {
        private readonly IConfiguration _configuration;

        public CheckSQLServer(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var connectionString = _configuration.GetConnectionString("Default");

           /* using*/ var conection = new SqlConnection(connectionString); 

            try
            {
                conection.Open();

                return Task.FromResult(HealthCheckResult.Healthy("Sql server ok")); 

            }
            catch (Exception)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("Can not open Database")); 
            }
            finally { conection.Close(); }
        }
    }
}
