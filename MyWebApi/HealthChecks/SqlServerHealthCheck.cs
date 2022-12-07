using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MyWebApi.HealthChecks
{
	public class SqlServerHealthCheck : IHealthCheck
	{
		private readonly IConfiguration configuration;

		public SqlServerHealthCheck(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
		{
			var connectionString = configuration.GetConnectionString("Default");

			var connection = new SqlConnection(connectionString);

			try
			{
				connection.Open();

				return Task.FromResult(HealthCheckResult.Healthy("Everything is OK"));
			}
			catch (Exception ex)
			{
				return Task.FromResult(HealthCheckResult.Degraded("Can not open database"));
			}
			finally { connection.Close(); }
		}
	}
}
