using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JestJob.Util
{
    public class ConfigBuilder
    {
        private IConfiguration Configuration { get; set; }
        
        public string GetConfig(string item)
        {
            var builder = new ConfigurationBuilder()
                      .SetBasePath(AppContext.BaseDirectory)
                      .AddJsonFile("appsettings.json")
                      .AddJsonFile("appsettings.Development.json", optional: true);
            Configuration = builder.Build();
            string connectionString;
            string DataSource = Environment.GetEnvironmentVariable("MSSQL_HOST");
            string InitialCatalog = Environment.GetEnvironmentVariable("MSSQL_DB");
            string UserID = Environment.GetEnvironmentVariable("MSSQL_USER");
            string Password = Environment.GetEnvironmentVariable("MSSQL_PASS");
            if (DataSource != null && InitialCatalog != null && UserID != null && Password != null)
            {
                connectionString = "Data Source =" + DataSource + "; Initial Catalog =" + InitialCatalog + "; User ID = " + UserID + "; Password = " + Password;
            }
            else
            {
                connectionString = Configuration.GetConnectionString("MSSqlServer");
            }
            return connectionString;

        }


    }
}
