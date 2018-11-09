using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sitecore.Xdb.MarketingAutomation.SqlServer;
using Sitecore.Xdb.MarketingAutomation.SqlServer.Serialization;
using Sitecore.Xdb.Sql.Common;
using DefaultObjectSerializer =
  Sitecore.Support.Xdb.MarketingAutomation.SqlServer.Serialization.DefaultObjectSerializer;

namespace Sitecore.Support.Xdb.MarketingAutomation.SqlServer.Pool
{
  public class SqlServerAutomationPool : Sitecore.Xdb.MarketingAutomation.SqlServer.Pool.SqlServerAutomationPool
  {
    public SqlServerAutomationPool(IConfiguration configuration, ILogger<SqlServerAutomationPool> logger,
      IRetryManager retryManager) : this(
      SqlServerProviderConfigurationReader.ExtractConnectionStringOrName(configuration), logger, retryManager)
    {
    }

    public SqlServerAutomationPool(string connectionStringOrName, ILogger<SqlServerAutomationPool> logger,
      IRetryManager retryManager) : this(connectionStringOrName, logger, new DefaultObjectSerializer(), retryManager)
    {
    }

    public SqlServerAutomationPool(IConfiguration configuration, ILogger<SqlServerAutomationPool> logger,
      ITvpConverter tvpConverter, IRetryManager retryManager) : this(
      SqlServerProviderConfigurationReader.ExtractConnectionStringOrName(configuration), logger, tvpConverter,
      retryManager)
    {
    }

    public SqlServerAutomationPool(IConfiguration configuration, ILogger<SqlServerAutomationPool> logger,
      IObjectSerializer objectSerializer, IRetryManager retryManager) : this(
      SqlServerProviderConfigurationReader.ExtractConnectionStringOrName(configuration), logger, objectSerializer,
      retryManager)
    {
    }

    public SqlServerAutomationPool(string connectionStringOrName, ILogger<SqlServerAutomationPool> logger,
      ITvpConverter tvpConverter, IRetryManager retryManager) : this(connectionStringOrName, logger, tvpConverter,
      new DefaultObjectSerializer(), retryManager)
    {
    }

    public SqlServerAutomationPool(string connectionStringOrName, ILogger<SqlServerAutomationPool> logger,
      IObjectSerializer objectSerializer, IRetryManager retryManager) : this(connectionStringOrName, logger,
      new TvpConverter(objectSerializer), objectSerializer, retryManager)
    {
    }

    public SqlServerAutomationPool(IConfiguration configuration, ILogger<SqlServerAutomationPool> logger,
      ITvpConverter tvpConverter, IObjectSerializer objectSerializer, IRetryManager retryManager) : this(
      SqlServerProviderConfigurationReader.ExtractConnectionStringOrName(configuration), logger, tvpConverter,
      objectSerializer, retryManager)
    {
    }

    public SqlServerAutomationPool(string connectionStringOrName, ILogger<SqlServerAutomationPool> logger,
      ITvpConverter tvpConverter, IObjectSerializer objectSerializer, IRetryManager retryManager) : base(
      connectionStringOrName, logger, tvpConverter, objectSerializer, retryManager)
    {
    }
  }
}